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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Encrypt_Click(object sender, RoutedEventArgs e)
        {
            Dictionary<int, char> AlphArray = new Dictionary<int, char>();
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
            var lines = new string[2];

            for (int i = 0; i < AlphArray.Count; i++)
            {
                lines[0] += chars[randomArray[i]];
                lines[1] += vals[randomArray[i]] + 1;
            }
            output.Text = lines[0];
            outputVars.Text = lines[1];
        }
    }
}
