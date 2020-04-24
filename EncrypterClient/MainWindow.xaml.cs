using EncrypterLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace EncrypterClient
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Decrypt_Click(object sender, RoutedEventArgs e)
        {
            if (!File.Exists("private-key.txt"))
            {
                MessageBox.Show("Файл private-key.txt не существует");
                return;
            }

            if (!File.Exists("public-key.txt"))
            {
                MessageBox.Show("Файл private-key.txt не существует");
                return;
            }

            var private_key = File.ReadAllText("private-key.txt").Split(':');
            var public_key = File.ReadAllLines("public-key.txt");
            var key = Rsa.Decrypt(public_key.ToList(), long.Parse(private_key[0]), long.Parse(private_key[1]));
            input.Text = MagicSquare.Decrypt(output.Text, key);
        }

        private void Encrypt_Click(object sender, RoutedEventArgs e)
        {
            var pair = MagicSquare.Encrypt(input.Text);
            output.Text = pair.Value;
            var key = pair.Key;
            Rsa rsa = null;
            if (int.TryParse(pInput.Text, out var p) && int.TryParse(qInput.Text, out var q))
            {
                if (Rsa.IsSimple(p, q))
                {
                    rsa = new Rsa(p, q);
                }
            }
            else
            {
                MessageBox.Show("p и q - не простые числа");
                return;
            }
            using (StreamWriter writer = new StreamWriter("public-key.txt"))
            {
                foreach (var line in rsa.Encrypt(key))
                {
                    writer.WriteLine(line);
                }
            }
            File.WriteAllText("private-key.txt", $"{rsa.D}:{rsa.N}");


        }
    }
}
