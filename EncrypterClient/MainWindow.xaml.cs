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
        private IType asymmetric;
        private Rsa symmetric;
        private char[] characters;
        public MainWindow()
        {
            InitializeComponent();
            asymmetric = new SimpleRearrangement();
            characters = asymmetric.Characters;
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
            var key = symmetric.Decrypt(public_key.ToList(), long.Parse(private_key[0]), long.Parse(private_key[1]));
            input.Text = asymmetric.Decrypt(output.Text, key);
        }

        private void Encrypt_Click(object sender, RoutedEventArgs e)
        {
            var pair = asymmetric.Encrypt(input.Text);
            output.Text = pair.Value;
            MessageBox.Show($"{pair.Value}, {pair.Key}");
            var key = pair.Key;
            if (int.TryParse(pInput.Text, out var p) && int.TryParse(qInput.Text, out var q))
            {
                if (Rsa.IsSimple(p, q))
                {
                    symmetric = new Rsa(p, q, characters);
                }
            }
            else
            {
                MessageBox.Show("p и q - не простые числа");
                return;
            }
            using (StreamWriter writer = new StreamWriter("public-key.txt"))
            {
                foreach (var line in symmetric.Encrypt(key))
                {
                    writer.WriteLine(line);
                }
            }
            File.WriteAllText("private-key.txt", $"{symmetric.D}:{symmetric.N}");


        }
    }
}
