using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Threading;

namespace KeyboardTrainer
{
    internal sealed partial class MainWindow : Window
    {
        List<string> words = new List<string>();
        DispatcherTimer timer = null;
        int tempTimer = 0;
        int fails = 0;
        public MainWindow()
        {
            InitializeComponent();

            timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1000);

            using (StreamReader sr = new StreamReader("words.txt", Encoding.UTF8))
            {
                while (!sr.EndOfStream)
                {
                    string word;
                    word = sr.ReadLine();
                    words.Add(word);
                }
            }

            sliderDiff.Minimum = 1;
            sliderDiff.Maximum = 10;
            btnStop.IsEnabled = false;

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            tempTimer++;
            Speed();
        }

        public int[] randArray(int size)
        {
            Random rand = new Random();
            int[] mas = new int[size];
            for (int i = 0; i < size; i++)
            {
                int a = rand.Next(0, words.Count);
                if (!mas.Contains(a))
                {
                    mas[i] = a;
                }
                else
                    i--;
            }
            return mas;
        }

        private void EnableButtons(bool is_start)
        {
            if (is_start)
            {
                btnStart.IsEnabled = false;
                btnStop.IsEnabled = true;
                btnStart.Opacity = 0.5;
                btnStop.Opacity = 1.0;
            }
            else
            {
                btnStart.IsEnabled = true;
                btnStop.IsEnabled = false;
                btnStart.Opacity = 1.0;
                btnStop.Opacity = 0.5;
            }
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            int sizeDiff = Convert.ToInt32(txtDiff.Text);
            int k = 0;
            int[] mas = randArray(sizeDiff);
            int step = 0;
            while (step != sizeDiff)
            {
                int i = mas[k];
                if (step != sizeDiff - 1)
                    txtBlockUp.Text += words[i] + " ";
                else
                    txtBlockUp.Text += words[i];
                step++;
                k++;
            }
            tempTimer = 0;
            EnableButtons(true);
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            txtBlockUp.Text = "";
            sliderDiff.Value = 1;
            EnableButtons(false);
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {

            switch (e.Key)
            {

                case Key.Back:
                    break;
                case Key.Tab:

                    break;
                case Key.Enter:
                    break;
                case Key.CapsLock:
                    break;
                case Key.Escape:
                    break;
                case Key.Space:
                    break;
                case Key.D0:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift)
                    {
                        bdrRightScob.Opacity = 0.5;
                        txtBlockDown.Text += ")";
                    }
                    else
                    {
                        if (e.Key != Key.LeftShift)
                        {
                            bdr0.Opacity = 0.5;
                            txtBlockDown.Text += "0";
                        }
                    }
                    break;
                case Key.D1:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift)
                    {
                        bdrVosklec.Opacity = 0.5;
                        txtBlockDown.Text += "!";
                    }
                    else
                    {
                        if (e.Key != Key.LeftShift)
                        {
                            bdr1.Opacity = 0.5;
                            txtBlockDown.Text += "1";
                        }
                    }
                    break;
                case Key.D2:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift)
                    {
                        bdrSobaka.Opacity = 0.5;
                        txtBlockDown.Text += "@";
                    }
                    else
                    {
                        if (e.Key != Key.LeftShift)
                        {
                            bdr2.Opacity = 0.5;
                            txtBlockDown.Text += "2";
                        }
                    }
                    break;
                case Key.D3:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift)
                    {
                        bdrSharp.Opacity = 0.5;
                        txtBlockDown.Text += "#";
                    }
                    else
                    {
                        if (e.Key != Key.LeftShift)
                        {
                            bdr3.Opacity = 0.5;
                            txtBlockDown.Text += "3";
                        }
                    }
                    break;
                case Key.D4:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift)
                    {
                        bdrDollar.Opacity = 0.5;
                        txtBlockDown.Text += "$";
                    }
                    else
                    {
                        if (e.Key != Key.LeftShift)
                        {
                            bdr4.Opacity = 0.5;
                            txtBlockDown.Text += "4";
                        }
                    }
                    break;
                case Key.D5:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift)
                    {
                        bdrProc.Opacity = 0.5;
                        txtBlockDown.Text += "%";
                    }
                    else
                    {
                        if (e.Key != Key.LeftShift)
                        {
                            bdr5.Opacity = 0.5;
                            txtBlockDown.Text += "5";
                        }
                    }
                    break;
                case Key.D6:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift)
                    {
                        bdrPtichka.Opacity = 0.5;
                        txtBlockDown.Text += "^";
                    }
                    else
                    {
                        if (e.Key != Key.LeftShift)
                        {
                            bdr6.Opacity = 0.5;
                            txtBlockDown.Text += "6";
                        }
                    }
                    break;
                case Key.D7:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift)
                    {
                        bdrAmpers.Opacity = 0.5;
                        txtBlockDown.Text += "&";
                    }
                    else
                    {
                        if (e.Key != Key.LeftShift)
                        {
                            bdr7.Opacity = 0.5;
                            txtBlockDown.Text += "7";
                        }
                    }
                    break;
                case Key.D8:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift)
                    {
                        bdrStar.Opacity = 0.5;
                        txtBlockDown.Text += "*";
                    }
                    else
                    {
                        if (e.Key != Key.LeftShift)
                        {
                            bdr8.Opacity = 0.5;
                            txtBlockDown.Text += "8";
                        }
                    }
                    break;
                case Key.D9:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift)
                    {
                        bdrLeftScob.Opacity = 0.5;
                        txtBlockDown.Text += "(";
                    }
                    else
                    {
                        if (e.Key != Key.LeftShift)
                        {
                            bdr9.Opacity = 0.5;
                            txtBlockDown.Text += "9";
                        }
                    }
                    break;
                case Key.A:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift)
                    {
                        bdrAUp.Opacity = 0.5;
                        txtBlockDown.Text += e.Key.ToString();
                    }
                    else
                    {
                        if (e.Key != Key.LeftShift)
                        {
                            bdrA.Opacity = 0.5;
                            txtBlockDown.Text += Convert.ToChar(Convert.ToChar(e.Key.ToString()) + 32);
                        }
                    }
                    break;
                case Key.B:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift)
                    {
                        bdrBUp.Opacity = 0.5;
                        txtBlockDown.Text += e.Key.ToString();
                    }
                    else
                    {
                        if (e.Key != Key.LeftShift)
                        {
                            bdrB.Opacity = 0.5;
                            txtBlockDown.Text += Convert.ToChar(Convert.ToChar(e.Key.ToString()) + 32);
                        }
                    }
                    break;
                case Key.C:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift)
                    {
                        bdrCUp.Opacity = 0.5;
                        txtBlockDown.Text += e.Key.ToString();
                    }
                    else
                    {
                        if (e.Key != Key.LeftShift)
                        {
                            bdrC.Opacity = 0.5;
                            txtBlockDown.Text += Convert.ToChar(Convert.ToChar(e.Key.ToString()) + 32);
                        }
                    }
                    break;
                case Key.D:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift)
                    {
                        bdrDUp.Opacity = 0.5;
                        txtBlockDown.Text += e.Key.ToString();
                    }
                    else
                    {
                        if (e.Key != Key.LeftShift)
                        {
                            bdrD.Opacity = 0.5;
                            txtBlockDown.Text += Convert.ToChar(Convert.ToChar(e.Key.ToString()) + 32);
                        }
                    }
                    break;
                case Key.E:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift)
                    {
                        bdrEUp.Opacity = 0.5;
                        txtBlockDown.Text += e.Key.ToString();
                    }
                    else
                    {
                        if (e.Key != Key.LeftShift)
                        {
                            bdrE.Opacity = 0.5;
                            txtBlockDown.Text += Convert.ToChar(Convert.ToChar(e.Key.ToString()) + 32);
                        }
                    }
                    break;
                case Key.F:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift)
                    {
                        bdrFUp.Opacity = 0.5;
                        txtBlockDown.Text += e.Key.ToString();
                    }
                    else
                    {
                        if (e.Key != Key.LeftShift)
                        {
                            bdrF.Opacity = 0.5;
                            txtBlockDown.Text += Convert.ToChar(Convert.ToChar(e.Key.ToString()) + 32);
                        }
                    }
                    break;
                case Key.G:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift)
                    {
                        bdrGUp.Opacity = 0.5;
                        txtBlockDown.Text += e.Key.ToString();
                    }
                    else
                    {
                        if (e.Key != Key.LeftShift)
                        {
                            bdrG.Opacity = 0.5;
                            txtBlockDown.Text += Convert.ToChar(Convert.ToChar(e.Key.ToString()) + 32);
                        }
                    }
                    break;
                case Key.H:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift)
                    {
                        bdrHUp.Opacity = 0.5;
                        txtBlockDown.Text += e.Key.ToString();
                    }
                    else
                    {
                        if (e.Key != Key.LeftShift)
                        {
                            bdrH.Opacity = 0.5;
                            txtBlockDown.Text += Convert.ToChar(Convert.ToChar(e.Key.ToString()) + 32);
                        }
                    }
                    break;
                case Key.I:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift)
                    {
                        bdrIUp.Opacity = 0.5;
                        txtBlockDown.Text += e.Key.ToString();
                    }
                    else
                    {
                        if (e.Key != Key.LeftShift)
                        {
                            bdrI.Opacity = 0.5;
                            txtBlockDown.Text += Convert.ToChar(Convert.ToChar(e.Key.ToString()) + 32);
                        }
                    }
                    break;
                case Key.J:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift)
                    {
                        bdrJUp.Opacity = 0.5;
                        txtBlockDown.Text += e.Key.ToString();
                    }
                    else
                    {
                        if (e.Key != Key.LeftShift)
                        {
                            bdrJ.Opacity = 0.5;
                            txtBlockDown.Text += Convert.ToChar(Convert.ToChar(e.Key.ToString()) + 32);
                        }
                    }
                    break;
                case Key.K:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift)
                    {
                        bdrKUp.Opacity = 0.5;
                        txtBlockDown.Text += e.Key.ToString();
                    }
                    else
                    {
                        if (e.Key != Key.LeftShift)
                        {
                            bdrK.Opacity = 0.5;
                            txtBlockDown.Text += Convert.ToChar(Convert.ToChar(e.Key.ToString()) + 32);
                        }
                    }
                    break;
                case Key.L:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift)
                    {
                        bdrLUp.Opacity = 0.5;
                        txtBlockDown.Text += e.Key.ToString();
                    }
                    else
                    {
                        if (e.Key != Key.LeftShift)
                        {
                            bdrL.Opacity = 0.5;
                            txtBlockDown.Text += Convert.ToChar(Convert.ToChar(e.Key.ToString()) + 32);
                        }
                    }
                    break;
                case Key.M:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift)
                    {
                        bdrMUp.Opacity = 0.5;
                        txtBlockDown.Text += e.Key.ToString();
                    }
                    else
                    {
                        if (e.Key != Key.LeftShift)
                        {
                            bdrM.Opacity = 0.5;
                            txtBlockDown.Text += Convert.ToChar(Convert.ToChar(e.Key.ToString()) + 32);
                        }
                    }
                    break;
                case Key.N:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift)
                    {
                        bdrNUp.Opacity = 0.5;
                        txtBlockDown.Text += e.Key.ToString();
                    }
                    else
                    {
                        if (e.Key != Key.LeftShift)
                        {
                            bdrN.Opacity = 0.5;
                            txtBlockDown.Text += Convert.ToChar(Convert.ToChar(e.Key.ToString()) + 32);
                        }
                    }
                    break;
                case Key.O:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift)
                    {
                        bdrOUp.Opacity = 0.5;
                        txtBlockDown.Text += e.Key.ToString();
                    }
                    else
                    {
                        if (e.Key != Key.LeftShift)
                        {
                            bdrO.Opacity = 0.5;
                            txtBlockDown.Text += Convert.ToChar(Convert.ToChar(e.Key.ToString()) + 32);
                        }
                    }
                    break;
                case Key.P:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift)
                    {
                        bdrPUp.Opacity = 0.5;
                        txtBlockDown.Text += e.Key.ToString();
                    }
                    else
                    {
                        if (e.Key != Key.LeftShift)
                        {
                            bdrP.Opacity = 0.5;
                            txtBlockDown.Text += Convert.ToChar(Convert.ToChar(e.Key.ToString()) + 32);
                        }
                    }
                    break;
                case Key.Q:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift)
                    {
                        bdrQUp.Opacity = 0.5;
                        txtBlockDown.Text += e.Key.ToString();
                    }
                    else
                    {
                        if (e.Key != Key.LeftShift)
                        {
                            bdrQ.Opacity = 0.5;
                            txtBlockDown.Text += Convert.ToChar(Convert.ToChar(e.Key.ToString()) + 32);
                        }
                    }
                    break;
                case Key.R:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift)
                    {
                        bdrRUp.Opacity = 0.5;
                        txtBlockDown.Text += e.Key.ToString();
                    }
                    else
                    {
                        if (e.Key != Key.LeftShift)
                        {
                            bdrR.Opacity = 0.5;
                            txtBlockDown.Text += Convert.ToChar(Convert.ToChar(e.Key.ToString()) + 32);
                        }
                    }
                    break;
                case Key.S:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift)
                    {
                        bdrSUp.Opacity = 0.5;
                        txtBlockDown.Text += e.Key.ToString();
                    }
                    else
                    {
                        if (e.Key != Key.LeftShift)
                        {
                            bdrS.Opacity = 0.5;
                            txtBlockDown.Text += Convert.ToChar(Convert.ToChar(e.Key.ToString()) + 32);
                        }
                    }
                    break;
                case Key.T:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift)
                    {
                        bdrTUp.Opacity = 0.5;
                        txtBlockDown.Text += e.Key.ToString();
                    }
                    else
                    {
                        if (e.Key != Key.LeftShift)
                        {
                            bdrT.Opacity = 0.5;
                            txtBlockDown.Text += Convert.ToChar(Convert.ToChar(e.Key.ToString()) + 32);
                        }
                    }
                    break;
                case Key.U:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift)
                    {
                        bdrUUp.Opacity = 0.5;
                        txtBlockDown.Text += e.Key.ToString();
                    }
                    else
                    {
                        if (e.Key != Key.LeftShift)
                        {
                            bdrU.Opacity = 0.5;
                            txtBlockDown.Text += Convert.ToChar(Convert.ToChar(e.Key.ToString()) + 32);
                        }
                    }
                    break;
                case Key.V:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift)
                    {
                        bdrVUp.Opacity = 0.5;
                        txtBlockDown.Text += e.Key.ToString();
                    }
                    else
                    {
                        if (e.Key != Key.LeftShift)
                        {
                            bdrV.Opacity = 0.5;
                            txtBlockDown.Text += Convert.ToChar(Convert.ToChar(e.Key.ToString()) + 32);
                        }
                    }
                    break;
                case Key.W:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift)
                    {
                        bdrWUp.Opacity = 0.5;
                        txtBlockDown.Text += e.Key.ToString();
                    }
                    else
                    {
                        if (e.Key != Key.LeftShift)
                        {
                            bdrW.Opacity = 0.5;
                            txtBlockDown.Text += Convert.ToChar(Convert.ToChar(e.Key.ToString()) + 32);
                        }
                    }
                    break;
                case Key.X:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift)
                    {
                        bdrXUp.Opacity = 0.5;
                        txtBlockDown.Text += e.Key.ToString();
                    }
                    else
                    {
                        if (e.Key != Key.LeftShift)
                        {
                            bdrX.Opacity = 0.5;
                            txtBlockDown.Text += Convert.ToChar(Convert.ToChar(e.Key.ToString()) + 32);
                        }
                    }
                    break;
                case Key.Y:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift)
                    {
                        bdrYUp.Opacity = 0.5;
                        txtBlockDown.Text += e.Key.ToString();
                    }
                    else
                    {
                        if (e.Key != Key.LeftShift)
                        {
                            bdrY.Opacity = 0.5;
                            txtBlockDown.Text += Convert.ToChar(Convert.ToChar(e.Key.ToString()) + 32);
                        }
                    }
                    break;
                case Key.Z:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift)
                    {
                        bdrZUp.Opacity = 0.5;
                        txtBlockDown.Text += e.Key.ToString();
                    }
                    else
                    {
                        if (e.Key != Key.LeftShift)
                        {
                            bdrZ.Opacity = 0.5;
                            txtBlockDown.Text += Convert.ToChar(Convert.ToChar(e.Key.ToString()) + 32);
                        }
                    }
                    break;
                case Key.LWin:
                    break;
                case Key.RWin:
                    break;
                case Key.LeftShift:
                    PanelUp.Visibility = Visibility.Visible;
                    PanelDown.Visibility = Visibility.Collapsed;
                    bdrLeftShiftUp.Opacity = 0.5;
                    break;
                case Key.RightShift:
                    PanelUp.Visibility = Visibility.Visible;
                    PanelDown.Visibility = Visibility.Collapsed;
                    bdrRightShiftUp.Opacity = 0.5;
                    break;
                case Key.LeftCtrl:
                    break;
                case Key.RightCtrl:
                    break;
                case Key.LeftAlt:
                    break;
                case Key.RightAlt:
                    break;
                case Key.Oem1: //":"
                    break;

                case Key.OemPlus: //"+" and "="
                    break;
                case Key.OemComma: //"<" and ","
                    break;
                case Key.OemMinus: //"-" and "_"
                    break;
                case Key.OemPeriod: //"." and ">"
                    break;

                case Key.OemQuestion: //"/" and "?"
                    break;

                case Key.OemTilde: //"~" and "`"
                    break;

                case Key.OemOpenBrackets: //"{" and "["
                    break;

                case Key.Oem6://"}" and "]"
                    break;

                default:
                    break;
            }

        }


        private void MainWindow_PreviewKeyUp(object sender, KeyEventArgs e)
        {

            switch (e.Key)
            {

                case Key.Back:
                    break;
                case Key.Tab:
                    break;
                case Key.Enter:
                    break;
                case Key.CapsLock:
                    break;
                case Key.Escape:
                    break;
                case Key.Space:
                    break;
                case Key.D0:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift)
                        bdrRightScob.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdr0.Opacity = 1;
                    break;
                case Key.D1:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift)
                        bdrVosklec.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdr1.Opacity = 1;
                    break;
                case Key.D2:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift)
                        bdrSobaka.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdr2.Opacity = 1;
                    break;
                case Key.D3:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift)
                        bdrSharp.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdr3.Opacity = 1;
                    break;
                case Key.D4:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift)
                        bdrDollar.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdr4.Opacity = 1;
                    break;
                case Key.D5:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift)
                        bdrProc.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdr5.Opacity = 1;
                    break;
                case Key.D6:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift)
                        bdrPtichka.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdr6.Opacity = 1;
                    break;
                case Key.D7:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift)
                        bdrAmpers.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdr7.Opacity = 1;
                    break;
                case Key.D8:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift)
                        bdrStar.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdr8.Opacity = 1;
                    break;
                case Key.D9:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift)
                        bdrLeftScob.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdr9.Opacity = 1;
                    break;
                case Key.A:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift)
                        bdrAUp.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdrA.Opacity = 1;
                    break;
                case Key.B:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift)
                        bdrBUp.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdrB.Opacity = 1;
                    break;
                case Key.C:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift)
                        bdrCUp.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdrC.Opacity = 1;
                    break;
                case Key.D:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift)
                        bdrDUp.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdrD.Opacity = 1;
                    break;
                case Key.E:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift)
                        bdrEUp.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdrE.Opacity = 1;
                    break;
                case Key.F:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift)
                        bdrFUp.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdrF.Opacity = 1;
                    break;
                case Key.G:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift)
                        bdrGUp.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdrG.Opacity = 1;
                    break;
                case Key.H:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift)
                        bdrHUp.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdrH.Opacity = 1;
                    break;
                case Key.I:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift)
                        bdrIUp.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdrI.Opacity = 1;
                    break;
                case Key.J:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift)
                        bdrJUp.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdrJ.Opacity = 1;
                    break;
                case Key.K:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift)
                        bdrKUp.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdrK.Opacity = 1;
                    break;
                case Key.L:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift)
                        bdrLUp.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdrL.Opacity = 1;
                    break;
                case Key.M:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift)
                        bdrMUp.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdrM.Opacity = 1;
                    break;
                case Key.N:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift)
                        bdrNUp.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdrN.Opacity = 1;
                    break;
                case Key.O:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift)
                        bdrOUp.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdrO.Opacity = 1;
                    break;
                case Key.P:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift)
                        bdrPUp.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdrP.Opacity = 1;
                    break;
                case Key.Q:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift)
                        bdrQUp.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdrQ.Opacity = 1;
                    break;
                case Key.R:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift)
                        bdrRUp.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdrR.Opacity = 1;
                    break;
                case Key.S:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift)
                        bdrSUp.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdrS.Opacity = 1;
                    break;
                case Key.T:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift)
                        bdrTUp.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdrT.Opacity = 1;
                    break;
                case Key.U:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift)
                        bdrUUp.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdrU.Opacity = 1;
                    break;
                case Key.V:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift)
                        bdrVUp.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdrV.Opacity = 1;
                    break;
                case Key.W:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift)
                        bdrWUp.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdrW.Opacity = 1;
                    break;
                case Key.X:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift)
                        bdrXUp.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdrX.Opacity = 1;
                    break;
                case Key.Y:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift)
                        bdrYUp.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdrY.Opacity = 1;
                    break;
                case Key.Z:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift)
                        bdrZUp.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdrZ.Opacity = 1;
                    break;
                case Key.LWin:
                    break;
                case Key.RWin:
                    break;
                case Key.LeftShift:
                    PanelUp.Visibility = Visibility.Collapsed;
                    PanelDown.Visibility = Visibility.Visible;
                    bdrLeftShiftUp.Opacity = 1;
                    break;
                case Key.RightShift:
                    PanelUp.Visibility = Visibility.Collapsed;
                    PanelDown.Visibility = Visibility.Visible;
                    bdrRightShiftUp.Opacity = 1;
                    break;
                case Key.LeftCtrl:
                    break;
                case Key.RightCtrl:
                    break;
                case Key.LeftAlt:
                    break;
                case Key.RightAlt:
                    break;
                case Key.Oem1: //":"
                    break;

                case Key.OemPlus: //"+" and "="
                    break;
                case Key.OemComma: //"<" and ","
                    break;
                case Key.OemMinus: //"-" and "_"
                    break;
                case Key.OemPeriod: //"." and ">"
                    break;

                case Key.OemQuestion: //"/" and "?"
                    break;

                case Key.OemTilde: //"~" and "`"
                    break;

                case Key.OemOpenBrackets: //"{" and "["
                    break;

                case Key.Oem6://"}" and "]"
                    break;

                default:
                    break;
            }

        }


        void Speed()
        {
            txtSpeed.Text = Math.Round(((double)txtBlockDownRight.Text.Length / tempTimer) * 60).ToString();
        }
    }
}