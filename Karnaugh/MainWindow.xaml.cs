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

namespace Karnaugh
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private int thingSize = 40, thingSpace = 5;
        private List<Casuta> casute = new List<Casuta>();
        private List<List<Casuta>> matrix = new List<List<Casuta>>(); 

        private void BuildBtn_Click(object sender, RoutedEventArgs e)
        {
            ClearThings();
            int dim;
            if (!int.TryParse(BitsNrTxt.Text, out dim) || dim < 1)
            {
                MessageBox.Show("Dimensiune invalidă!");
                return;
            }
            var dimY = dim/2;
            var dimX = dimY + (dim%2 == 0 ? 0 : 1);
            var grayCodeGenerator = new GrayCodeGenerator();
            var hGrayCode = grayCodeGenerator.GenerateGrayCode(dimX);
            var vGrayCode = grayCodeGenerator.GenerateGrayCode(dimY);
            dimY = (int) Math.Pow(2, dimY);
            dimX = (int) Math.Pow(2, dimX);
            for (var i = 0; i < dimY; i++)
            {
                matrix.Add(new List<Casuta>());
                for (var j = 0; j < dimX; j++)
                {
                    var casuta = new Casuta
                    {
                        Width = thingSize,
                        Height = thingSize,
                        Left = 50 + j*(thingSize + thingSpace),
                        Top = 0 + i*(thingSize + thingSpace),
                        Position = vGrayCode[i] + hGrayCode[j]
                    };
                    matrix[i].Add(casuta);
                    casute.Add(casuta);
                    this.TheGrid.Children.Add(casuta);
                }
            }
        }

        private void SolveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (matrix.Count == 0)
            {
                MessageBox.Show("Can't solve!");
                return;
            }
            var diagrama = matrix.Select(linie => linie.Select(casuta => casuta.State.GetIntValue()).ToList()).ToList();
            var dimX = diagrama[0].Count;
            var dimY = diagrama.Count;
            for (var i = 0; i < dimY; i++)
            {
                for (var j = 0; j < dimX; j++)
                {
                    //fku cu diagrama[i][j]
                }
            }
        }

        private void ClearThings()
        {
            while(casute.Count>0)
            {
                this.TheGrid.Children.Remove(casute[0]);
                casute.RemoveAt(0);
            }
            matrix = new List<List<Casuta>>();
        }
    }
}
