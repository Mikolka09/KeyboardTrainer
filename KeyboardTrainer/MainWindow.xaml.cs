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

namespace KeyboardTrainer
{
    internal sealed partial class MainWindow : Window
    {
        List<string> words = new List<string>();
        public MainWindow()
        {
            InitializeComponent();

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
            EnableButtons(true);
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            txtBlockUp.Text = "";
            sliderDiff.Value = 1;
            EnableButtons(false);
        }

        private void bdr_KeyDown(object sender, KeyEventArgs e)
        {
            bdrSpace.Opacity = 0.5;
        }
    }
}