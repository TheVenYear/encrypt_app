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

namespace encrypt_app
{
    public partial class MainWindow : Window
    {
        Dictionary<int, char> AlphArray = new Dictionary<int, char>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Encrypt_Click(object sender, RoutedEventArgs e)
        {
            AlphArray = new Dictionary<int, char>();
            var randomArray = new List<int>();

            for (int i = 0; i < input.Text.Length; i++)
            {
                AlphArray.Add(i, input.Text[i]);
                randomArray.Add(i);
            }
            var random = new Random(DateTime.Now.Millisecond);
            randomArray = randomArray.OrderBy(x => random.Next()).ToList();

            List<char> chars = Enumerable.ToList(AlphArray.Values);
            List<int> vals = Enumerable.ToList(AlphArray.Keys);

            output.Text = "";
            outputVars.Text = "";
            for (int i = 0; i < AlphArray.Count; i++)
            {
                output.Text += chars[randomArray[i]];
                outputVars.Text += $"{vals[randomArray[i]] + 1} ";
            }

        }

        private void Decrypt_Click(object sender, RoutedEventArgs e)
        {
            if (output.Text != "" && outputVars.Text != "")
            {
                var arrNums = new List<int>();
                var arrChars = new List<char>();
                AlphArray = new Dictionary<int, char>();
                foreach (var item in output.Text)
                {
                    arrChars.Add(item);
                }

                var element = "";
                var counter = 0;
                foreach (var item in outputVars.Text)
                {
                    if (item == ' ')
                    {
                        arrNums.Add(int.Parse(element.ToString()) - 1);
                        counter++;
                        element = "";
                    }
                    element += item;
                }

                for (int i = 0; i < arrNums.Count; i++)
                {
                    AlphArray.Add(arrNums[i], arrChars[i]);
                }
                var sorted = new SortedDictionary<int, char>(AlphArray);



                foreach (var item in sorted.Values)
                {
                    element += $"{item}";
                }
                input.Text = element;
            }
            else
                MessageBox.Show("Неверные данные");

        }
    }
}
