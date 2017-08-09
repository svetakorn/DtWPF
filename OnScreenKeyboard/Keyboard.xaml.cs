using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OnScreenKeyboard
{
    /// <summary>
    /// Interaction logic for Keyboard.xaml
    /// </summary>
    public partial class Keyboard : UserControl
    {
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text",typeof(string),typeof(Keyboard),new UIPropertyMetadata(null));
        public string Text{get{return (string)this.GetValue(TextProperty);}set{this.SetValue(TextProperty, value);}}

        public Keyboard()
        {
            InitializeComponent();
            UpdateContents();
        }

        int shiftState = 1;
        int langState = 1;
        int symState = 0;

        private void KeyClick(object sender, RoutedEventArgs e)
        {
            usercontrol.Text += (sender as Button).Content.ToString();
        }

        void UpdateContents()
        {
            int layout = Math.Min(shiftState + langState*2 + symState*4, 4);
            Q.Content = Q.Tag.ToString().Substring(layout, 1);
            W.Content = W.Tag.ToString().Substring(layout, 1);
            E.Content = E.Tag.ToString().Substring(layout, 1);
            R.Content = R.Tag.ToString().Substring(layout, 1);
            T.Content = T.Tag.ToString().Substring(layout, 1);
            Y.Content = Y.Tag.ToString().Substring(layout, 1);
            U.Content = U.Tag.ToString().Substring(layout, 1);
            I.Content = I.Tag.ToString().Substring(layout, 1);
            O.Content = O.Tag.ToString().Substring(layout, 1);
            P.Content = P.Tag.ToString().Substring(layout, 1);
            p1.Content=p1.Tag.ToString().Substring(layout, 1);
            p2.Content=p2.Tag.ToString().Substring(layout, 1);
            A.Content = A.Tag.ToString().Substring(layout, 1);
            S.Content = S.Tag.ToString().Substring(layout, 1);
            D.Content = D.Tag.ToString().Substring(layout, 1);
            F.Content = F.Tag.ToString().Substring(layout, 1);
            G.Content = G.Tag.ToString().Substring(layout, 1);
            H.Content = H.Tag.ToString().Substring(layout, 1);
            J.Content = J.Tag.ToString().Substring(layout, 1);
            K.Content = K.Tag.ToString().Substring(layout, 1);
            L.Content = L.Tag.ToString().Substring(layout, 1);
            l1.Content=l1.Tag.ToString().Substring(layout, 1);
            l2.Content=l2.Tag.ToString().Substring(layout, 1);
            Z.Content = Z.Tag.ToString().Substring(layout, 1);
            X.Content = X.Tag.ToString().Substring(layout, 1);
            C.Content = C.Tag.ToString().Substring(layout, 1);
            V.Content = V.Tag.ToString().Substring(layout, 1);
            B.Content = B.Tag.ToString().Substring(layout, 1);
            N.Content = N.Tag.ToString().Substring(layout, 1);
            M.Content = M.Tag.ToString().Substring(layout, 1);
            m1.Content=m1.Tag.ToString().Substring(layout, 1);
            m2.Content=m2.Tag.ToString().Substring(layout, 1);
            m3.Content=m3.Tag.ToString().Substring(layout, 1);

        }

        private void ShiftClick(object sender, RoutedEventArgs e)
        {
            shiftState = 1 - int.Parse(Shift1.Tag.ToString());
            Shift1.Tag = shiftState.ToString();
            UpdateContents();
        }

        private void BackspaceClick(object sender, RoutedEventArgs e)
        {
            if (usercontrol.Text.Length > 0)
                usercontrol.Text = usercontrol.Text.Substring(0, usercontrol.Text.Length - 1);
        }

        private void SpaceClick(object sender, RoutedEventArgs e)
        {
            usercontrol.Text += " ";
        }

        private void ToggleLang(object sender, RoutedEventArgs e)
        {
            langState = 1 - int.Parse(LangBtn.Tag.ToString());
            LangBtn.Tag = langState.ToString();
            UpdateContents();
        }

        private void ToggleSym(object sender, RoutedEventArgs e)
        {
            symState = 1 - int.Parse(SymBtn.Tag.ToString());
            SymBtn.Tag = symState.ToString();
            UpdateContents();
        }
    }
}
