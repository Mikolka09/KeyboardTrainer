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

            if (Keyboard.IsKeyToggled(Key.CapsLock))
            {
                PanelDown.Visibility = Visibility.Collapsed;
                PanelUp.Visibility = Visibility.Visible;
                bdrCapsLockUp.Opacity = 0.5;
            }

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
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
                    {
                        bdrBackspaceUp.Opacity = 0.5;
                        if (txtBlockDown.Text.Length != 0)
                            txtBlockDown.Text = txtBlockDown.Text.Remove(txtBlockDown.Text.Length - 1);
                    }
                    else
                    {
                        if (e.Key != Key.LeftShift)
                        {
                            bdrBackspace.Opacity = 0.5;
                            if (txtBlockDown.Text.Length != 0)
                                txtBlockDown.Text = txtBlockDown.Text.Remove(txtBlockDown.Text.Length - 1);
                        }
                    }
                    break;
                case Key.Tab:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
                        bdrTabUp.Opacity = 0.5;
                    else if (e.Key != Key.LeftShift)
                        bdrTab.Opacity = 0.5;
                    break;
                case Key.Enter:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
                        bdrEnterUp.Opacity = 0.5;
                    else if (e.Key != Key.LeftShift)
                        bdrEnter.Opacity = 0.5;
                    break;
                case Key.CapsLock:
                    if (Keyboard.IsKeyToggled(Key.CapsLock))
                    {
                        bdrCapsLockUp.Opacity = 0.5;
                        PanelDown.Visibility = Visibility.Collapsed;
                        PanelUp.Visibility = Visibility.Visible;

                    }
                    else
                    {
                        PanelDown.Visibility = Visibility.Visible;
                        PanelUp.Visibility = Visibility.Collapsed;
                        bdrCapsLockUp.Opacity = 1;
                    }
                    break;
                case Key.Escape:
                    this.Close();
                    break;
                case Key.Space:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
                    {
                        bdrSpaceUp.Opacity = 0.5;
                        txtBlockDown.Text += " ";
                    }
                    else
                    {
                        if (e.Key != Key.LeftShift)
                        {
                            bdrSpace.Opacity = 0.5;
                            txtBlockDown.Text += " ";
                        }
                    }
                    break;
                case Key.D0:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
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
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
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
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
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
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
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
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
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
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
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
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
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
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
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
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
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
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
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
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && Keyboard.IsKeyToggled(Key.CapsLock))
                    {
                        bdrA.Opacity = 0.5;
                        txtBlockDown.Text += Convert.ToChar(Convert.ToChar(e.Key.ToString()) + 32);
                    }
                    else if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
                    {
                        bdrAUp.Opacity = 0.5;
                        txtBlockDown.Text += e.Key.ToString();
                    }
                    else if (e.Key != Key.LeftShift)
                    {
                        bdrA.Opacity = 0.5;
                        txtBlockDown.Text += Convert.ToChar(Convert.ToChar(e.Key.ToString()) + 32);
                    }
                    break;
                case Key.B:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
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
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
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
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
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
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
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
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
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
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
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
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
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
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
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
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
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
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
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
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
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
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
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
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
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
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
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
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
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
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
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
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
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
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
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
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
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
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
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
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
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
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
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
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
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
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
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
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
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
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
                        bdrLeftWinUp.Opacity = 0.5;
                    else if (e.Key != Key.LeftShift)
                        bdrLeftWin.Opacity = 0.5;
                    break;
                case Key.RWin:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
                        bdrRightWinUp.Opacity = 0.5;
                    else if (e.Key != Key.LeftShift)
                        bdrRightWin.Opacity = 0.5;
                    break;
                case Key.LeftShift:
                    if (Keyboard.IsKeyToggled(Key.CapsLock))
                    {
                        PanelUp.Visibility = Visibility.Collapsed;
                        PanelDown.Visibility = Visibility.Visible;
                        bdrLeftShift.Opacity = 0.5;
                        bdrCapsLock.Opacity = 0.5;
                    }
                    else
                    {
                        PanelUp.Visibility = Visibility.Visible;
                        PanelDown.Visibility = Visibility.Collapsed;
                        bdrLeftShiftUp.Opacity = 0.5;
                    }
                    break;
                case Key.RightShift:
                    if (Keyboard.IsKeyToggled(Key.CapsLock))
                    {
                        PanelUp.Visibility = Visibility.Collapsed;
                        PanelDown.Visibility = Visibility.Visible;
                        bdrRightShift.Opacity = 0.5;
                        bdrCapsLock.Opacity = 0.5;
                    }
                    else
                    {
                        PanelUp.Visibility = Visibility.Visible;
                        PanelDown.Visibility = Visibility.Collapsed;
                        bdrRightShiftUp.Opacity = 0.5;
                    }
                    break;
                case Key.LeftCtrl:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
                        bdrLeftCtrlUp.Opacity = 0.5;
                    else if (e.Key != Key.LeftShift)
                        bdrLeftCtrl.Opacity = 0.5;
                    break;
                case Key.RightCtrl:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
                        bdrRightCtrlUp.Opacity = 0.5;
                    else if (e.Key != Key.LeftShift)
                        bdrRightCtrl.Opacity = 0.5;
                    break;
                case Key.System:
                    if (e.SystemKey == Key.RightAlt)
                    {
                        if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
                            bdrRightAltUp.Opacity = 0.5;
                        else if (e.Key != Key.LeftShift)
                            bdrRightAlt.Opacity = 0.5;
                    }
                    else
                    {
                        if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
                            bdrLeftAltUp.Opacity = 0.5;
                        else if (e.Key != Key.LeftShift)
                            bdrLeftAlt.Opacity = 0.5;
                    }
                    break;
                case Key.Oem1: //":" and ";"
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
                    {
                        bdrTochUp.Opacity = 0.5;
                        txtBlockDown.Text += ":";
                    }
                    else
                    {
                        if (e.Key != Key.LeftShift)
                        {
                            bdrTochKoma.Opacity = 0.5;
                            txtBlockDown.Text += ";";
                        }
                    }
                    break;

                case Key.OemPlus: //"+" and "="
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
                    {
                        bdrPlus.Opacity = 0.5;
                        txtBlockDown.Text += "+";
                    }
                    else
                    {
                        if (e.Key != Key.LeftShift)
                        {
                            bdrEquals.Opacity = 0.5;
                            txtBlockDown.Text += "=";
                        }
                    }
                    break;
                case Key.OemComma: //"<" and ","
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
                    {
                        bdrMenshe.Opacity = 0.5;
                        txtBlockDown.Text += "<";
                    }
                    else
                    {
                        if (e.Key != Key.LeftShift)
                        {
                            bdrKoma.Opacity = 0.5;
                            txtBlockDown.Text += ",";
                        }
                    }
                    break;
                case Key.OemMinus: //"-" and "_"
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
                    {
                        bdrDownPodcher.Opacity = 0.5;
                        txtBlockDown.Text += "_";
                    }
                    else
                    {
                        if (e.Key != Key.LeftShift)
                        {
                            bdrMinus.Opacity = 0.5;
                            txtBlockDown.Text += "-";
                        }
                    }
                    break;
                case Key.OemPeriod: //"." and ">"
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
                    {
                        bdrBolshe.Opacity = 0.5;
                        txtBlockDown.Text += ">";
                    }
                    else
                    {
                        if (e.Key != Key.LeftShift)
                        {
                            bdrToch.Opacity = 0.5;
                            txtBlockDown.Text += ".";
                        }
                    }
                    break;
                case Key.OemQuestion: //"/" and "?"
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
                    {
                        bdrVopros.Opacity = 0.5;
                        txtBlockDown.Text += "?";
                    }
                    else
                    {
                        if (e.Key != Key.LeftShift)
                        {
                            bdrRightLine.Opacity = 0.5;
                            txtBlockDown.Text += "/";
                        }
                    }
                    break;
                case Key.OemTilde: //"~" and "`"
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
                    {
                        bdrTilda.Opacity = 0.5;
                        txtBlockDown.Text += "~";
                    }
                    else
                    {
                        if (e.Key != Key.LeftShift)
                        {
                            bdrAps.Opacity = 0.5;
                            txtBlockDown.Text += "`";
                        }
                    }
                    break;
                case Key.OemOpenBrackets: //"{" and "["
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
                    {
                        bdrLeftFigurScob.Opacity = 0.5;
                        txtBlockDown.Text += "{";
                    }
                    else
                    {
                        if (e.Key != Key.LeftShift)
                        {
                            bdrLeftSqScob.Opacity = 0.5;
                            txtBlockDown.Text += "[";
                        }
                    }
                    break;
                case Key.Oem5://"|" and "\"
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
                    {
                        bdrLine.Opacity = 0.5;
                        txtBlockDown.Text += "|";
                    }
                    else
                    {
                        if (e.Key != Key.LeftShift)
                        {
                            bdrLeftLine.Opacity = 0.5;
                            txtBlockDown.Text += "\\";
                        }
                    }
                    break;
                case Key.Oem6://"}" and "]"
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
                    {
                        bdrRightFigurScob.Opacity = 0.5;
                        txtBlockDown.Text += "}";
                    }
                    else
                    {
                        if (e.Key != Key.LeftShift)
                        {
                            bdrRightSqScob.Opacity = 0.5;
                            txtBlockDown.Text += "]";
                        }
                    }
                    break;
                case Key.OemQuotes://""" and "'"
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
                    {
                        bdrLapki.Opacity = 0.5;
                        txtBlockDown.Text += "\"";
                    }
                    else
                    {
                        if (e.Key != Key.LeftShift)
                        {
                            bdrApos.Opacity = 0.5;
                            txtBlockDown.Text += "'";
                        }
                    }
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
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
                        bdrBackspaceUp.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdrBackspace.Opacity = 1;
                    break;
                case Key.Tab:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
                        bdrTabUp.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdrTab.Opacity = 1;
                    break;
                case Key.Enter:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
                        bdrEnterUp.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdrEnter.Opacity = 1;
                    break;
                case Key.Space:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
                        bdrSpaceUp.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdrSpace.Opacity = 1;
                    break;
                case Key.D0:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
                        bdrRightScob.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdr0.Opacity = 1;
                    break;
                case Key.D1:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
                        bdrVosklec.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdr1.Opacity = 1;
                    break;
                case Key.D2:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
                        bdrSobaka.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdr2.Opacity = 1;
                    break;
                case Key.D3:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
                        bdrSharp.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdr3.Opacity = 1;
                    break;
                case Key.D4:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
                        bdrDollar.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdr4.Opacity = 1;
                    break;
                case Key.D5:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
                        bdrProc.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdr5.Opacity = 1;
                    break;
                case Key.D6:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
                        bdrPtichka.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdr6.Opacity = 1;
                    break;
                case Key.D7:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
                        bdrAmpers.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdr7.Opacity = 1;
                    break;
                case Key.D8:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
                        bdrStar.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdr8.Opacity = 1;
                    break;
                case Key.D9:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
                        bdrLeftScob.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdr9.Opacity = 1;
                    break;
                case Key.A:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && Keyboard.IsKeyToggled(Key.CapsLock))
                        bdrA.Opacity = 1;
                    else if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
                        bdrAUp.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdrA.Opacity = 1;
                    break;
                case Key.B:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
                        bdrBUp.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdrB.Opacity = 1;
                    break;
                case Key.C:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
                        bdrCUp.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdrC.Opacity = 1;
                    break;
                case Key.D:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
                        bdrDUp.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdrD.Opacity = 1;
                    break;
                case Key.E:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
                        bdrEUp.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdrE.Opacity = 1;
                    break;
                case Key.F:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
                        bdrFUp.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdrF.Opacity = 1;
                    break;
                case Key.G:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
                        bdrGUp.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdrG.Opacity = 1;
                    break;
                case Key.H:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
                        bdrHUp.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdrH.Opacity = 1;
                    break;
                case Key.I:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
                        bdrIUp.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdrI.Opacity = 1;
                    break;
                case Key.J:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
                        bdrJUp.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdrJ.Opacity = 1;
                    break;
                case Key.K:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
                        bdrKUp.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdrK.Opacity = 1;
                    break;
                case Key.L:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
                        bdrLUp.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdrL.Opacity = 1;
                    break;
                case Key.M:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
                        bdrMUp.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdrM.Opacity = 1;
                    break;
                case Key.N:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
                        bdrNUp.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdrN.Opacity = 1;
                    break;
                case Key.O:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
                        bdrOUp.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdrO.Opacity = 1;
                    break;
                case Key.P:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
                        bdrPUp.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdrP.Opacity = 1;
                    break;
                case Key.Q:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
                        bdrQUp.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdrQ.Opacity = 1;
                    break;
                case Key.R:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
                        bdrRUp.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdrR.Opacity = 1;
                    break;
                case Key.S:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
                        bdrSUp.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdrS.Opacity = 1;
                    break;
                case Key.T:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
                        bdrTUp.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdrT.Opacity = 1;
                    break;
                case Key.U:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
                        bdrUUp.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdrU.Opacity = 1;
                    break;
                case Key.V:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
                        bdrVUp.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdrV.Opacity = 1;
                    break;
                case Key.W:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
                        bdrWUp.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdrW.Opacity = 1;
                    break;
                case Key.X:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
                        bdrXUp.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdrX.Opacity = 1;
                    break;
                case Key.Y:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
                        bdrYUp.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdrY.Opacity = 1;
                    break;
                case Key.Z:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
                        bdrZUp.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdrZ.Opacity = 1;
                    break;
                case Key.LWin:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
                        bdrLeftWinUp.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdrLeftWin.Opacity = 1;
                    break;
                case Key.RWin:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
                        bdrRightWinUp.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdrRightWin.Opacity = 1;
                    break;
                case Key.LeftShift:
                    if (Keyboard.IsKeyToggled(Key.CapsLock))
                    {
                        PanelUp.Visibility = Visibility.Visible;
                        PanelDown.Visibility = Visibility.Collapsed;
                        bdrLeftShift.Opacity = 1;
                        bdrCapsLockUp.Opacity = 0.5;
                    }
                    else
                    {
                        PanelUp.Visibility = Visibility.Collapsed;
                        PanelDown.Visibility = Visibility.Visible;
                        bdrLeftShiftUp.Opacity = 1;
                    }
                    break;
                case Key.RightShift:
                    if (Keyboard.IsKeyToggled(Key.CapsLock))
                    {
                        PanelUp.Visibility = Visibility.Visible;
                        PanelDown.Visibility = Visibility.Collapsed;
                        bdrRightShift.Opacity = 1;
                        bdrCapsLockUp.Opacity = 0.5;
                    }
                    else
                    {
                        PanelUp.Visibility = Visibility.Collapsed;
                        PanelDown.Visibility = Visibility.Visible;
                        bdrRightShiftUp.Opacity = 1;
                    }
                    break;
                case Key.LeftCtrl:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
                        bdrLeftCtrlUp.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdrLeftCtrl.Opacity = 1;
                    break;
                case Key.RightCtrl:
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
                        bdrRightCtrlUp.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdrRightCtrl.Opacity = 1;
                    break;
                case Key.System:
                    if (e.SystemKey == Key.RightAlt)
                    {
                        if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
                            bdrRightAltUp.Opacity = 1;
                        else if (e.Key != Key.LeftShift)
                            bdrRightAlt.Opacity = 1;
                    }
                    else
                    {
                        if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
                            bdrLeftAltUp.Opacity = 1;
                        else if (e.Key != Key.LeftShift)
                            bdrLeftAlt.Opacity = 1;
                    }
                    break;
                case Key.Oem1: //":" and ";"
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
                        bdrTochUp.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdrTochKoma.Opacity = 1;
                    break;
                case Key.OemPlus: //"+" and "="
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
                        bdrPlus.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdrEquals.Opacity = 1;
                    break;
                case Key.OemComma: //"<" and ","
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
                        bdrMenshe.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdrKoma.Opacity = 1;
                    break;
                case Key.OemMinus: //"-" and "_"
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
                        bdrDownPodcher.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdrMinus.Opacity = 1;
                    break;
                case Key.OemPeriod: //"." and ">"
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
                        bdrToch.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdrBolshe.Opacity = 1;
                    break;
                case Key.OemQuestion: //"/" and "?"
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
                        bdrRightLine.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdrVopros.Opacity = 1;
                    break;
                case Key.OemTilde: //"~" and "`"
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
                        bdrTilda.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdrAps.Opacity = 1;
                    break;
                case Key.OemOpenBrackets: //"{" and "["
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
                        bdrLeftFigurScob.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdrLeftSqScob.Opacity = 1;
                    break;
                case Key.Oem5://"|" and "\"
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
                        bdrLine.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdrLeftLine.Opacity = 1;
                    break;
                case Key.Oem6://"}" and "]"
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
                        bdrRightFigurScob.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdrRightSqScob.Opacity = 1;
                    break;
                case Key.OemQuotes://""" and "'"
                    if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key != Key.LeftShift || Keyboard.IsKeyToggled(Key.CapsLock))
                        bdrLapki.Opacity = 1;
                    else if (e.Key != Key.LeftShift)
                        bdrApos.Opacity = 1;
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