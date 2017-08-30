using Datatron.Networking;
using FFT.External;
using Fourier;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Datatron.Networking
{
    class SendAudioData
    {
        NetworkingSingleton networking = NetworkingSingleton.getInstance();

        Node dataList = new Node(new ComplexNumber(0, 0));
        int distance2Node = 0;
        int[] chunk_freq = { 10, 100, 2048 };
        int[] chunk_freq_jump = { 1, 10, 20 };
        int N_FFT = 2048;
        Node endingNode;
        private const int samplingFrequency = 44100;
        double[] sourceData;
        double[] transformedData;
        WaveIn waveInStream;
        double MasterScaleFFT = 100;

        private double[] FFT(double[] lastData)
        {
            DateTime chkpoint1 = DateTime.Now;
            if (dataList == null)
                return null;
            int actualN = distance2Node + 1;

            if (actualN < N_FFT)
                return new double[0];

            bool transformed = false;
            if (lastData == null || lastData.Length == 0)
            {
                lastData = new double[N_FFT];
            }
            else
            {
                transformed = true;
            }
            ComplexNumber[] data = new ComplexNumber[N_FFT];
            var runningNode = endingNode;
            for (int i = 0; i < N_FFT; i++)
            {
                data[i] = runningNode.Value;
                if (runningNode.PrevNode == null)
                {
                }
                runningNode = runningNode.PrevNode;
            }
            var result = FFTProcessor.FFT(data);
            double N2 = result.Length / 2;
            double[] finalresult = new double[lastData.Length];
            int k = 1, transformedDataIndex = 0;
            double value = 0;

            double refFeq = 250;

            int i_ref = (int)(refFeq * N2 / 22050);
            for (int i = 0; i < N2; i += k)
            {
                value = 0;
                //k = i / i_ref;
                //k = k == 0 ? 1 : k;
                var mappedFreq = i * samplingFrequency / 2 / N2;
                for (int l = 0; l < chunk_freq.Length; l++)
                {
                    if (mappedFreq < chunk_freq[l] || l == chunk_freq.Length - 1)
                    {
                        k = chunk_freq_jump[l];//chunk_freq[l] / chunk_freq[0];
                        break;
                    }
                }

                for (int j = i; j < i + k && j < N2; j++)
                {
                    value += result[j].Manigtude;
                }


                value = value * MasterScaleFFT;
                finalresult[transformedDataIndex] = value;
                transformedDataIndex++;
            }


            if (!transformed)
                Array.Resize<double>(ref finalresult, transformedDataIndex);


            DateTime chkpoint1_end = DateTime.Now;
            return finalresult;

        }

        public double[] wavesScaling = new double[18];
        public float loudness = 0;

        public void tick(Object source, ElapsedEventArgs e)
        {
            //            if (comboboxDevices.SelectedItem != null)
            //          {
            //        var device = (MMDevice)comboboxDevices.SelectedItem;
            NAudio.CoreAudioApi.MMDeviceEnumerator devEnum = new NAudio.CoreAudioApi.MMDeviceEnumerator();
            NAudio.CoreAudioApi.MMDevice defaultDevice = devEnum.GetDefaultAudioEndpoint(NAudio.CoreAudioApi.DataFlow.Render, NAudio.CoreAudioApi.Role.Multimedia);
            loudness = defaultDevice.AudioMeterInformation.MasterPeakValue * 255;
            transformedData = FFT(transformedData);
            int bandWidth = transformedData.Length / 18;
            for (int i = 0; i < 18; i++)
            {
                double sum = 0;
                for (int j = 0; j < bandWidth; j++)
                {
                    sum += transformedData[j * 18 + i];
                }
                wavesScaling[i] = sum;
            }
            //string concatenated = string.Join("#", loudBandData);

            //try
            //{
              //  if (networking.client.Connected)
                //{
                    //networking.SendMessage("L" + concatenated + "#");
                //}
            //}
            //catch { }

        }

        private void AppendData(double[] newData)
        {
            int N = 10000;
            //double[] data = new double[N];

            var prevNode = dataList;
            var shiftNode = dataList;


            for (int j = 0; j < newData.Length; j++)
            {
                endingNode.NextNode = new Node(new ComplexNumber(newData[j], 0));
                endingNode.NextNode.PrevNode = endingNode;
                endingNode = endingNode.NextNode;
                if (j == newData.Length - 1)
                    endingNode.isEndPoint = true;
                // data[thresholdCounter] = runningNode.Value;
                distance2Node++;
            }
            if (distance2Node > N)
            {
                for (int j = 0; j < newData.Length; j++)
                {
                    dataList = dataList.NextNode;
                }
                dataList.isStartPoint = true;
                dataList.PrevNode = null;
                distance2Node = distance2Node - newData.Length;
            }

        }

        private void waveInStream_DataAvailable(object sender, WaveInEventArgs e)
        {
            if (sourceData == null)
                sourceData = new double[e.BytesRecorded / 2];

            for (int i = 0; i < e.BytesRecorded; i += 2)
            {
                short sampleL = (short)((e.Buffer[i + 1] << 8) | e.Buffer[i + 0]);
                //  short sampleR = (short)((e.Buffer[i + 1+2] << 8) | e.Buffer[i + 2]);
                double sample32 = (sampleL) / 32722d;
                sourceData[i / 2] = sample32;// (double)(e.Buffer[i]) / 255;
            }

            AppendData(sourceData);
        }

        public SendAudioData()
        {
            try
            {
                endingNode = dataList;
                waveInStream = new WaveIn();
                waveInStream.NumberOfBuffers = 5;
                waveInStream.BufferMilliseconds = 10;
                waveInStream.WaveFormat = new WaveFormat(samplingFrequency, 2);
                waveInStream.DataAvailable += new EventHandler<WaveInEventArgs>(waveInStream_DataAvailable);
                waveInStream.StartRecording();
//                networking.tmr2.Elapsed += tick;
            }
            catch (Exception ex) { Debug.WriteLine(ex); }
        }

    }
}
