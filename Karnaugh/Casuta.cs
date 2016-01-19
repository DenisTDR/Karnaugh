using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Karnaugh
{
    public class Casuta : Grid
    {
        private ThingState _state;
        private string _position;
        private TextBlock positionTxt, stateTxt;

        public Casuta()
        {
            this.MouseDown += Thing_MouseDown;
            this.Loaded += Thing_Loaded;
            this.HorizontalAlignment = HorizontalAlignment.Left;
            this.VerticalAlignment = VerticalAlignment.Top;
            positionTxt = new TextBlock
            {
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Foreground = new SolidColorBrush(Colors.Gray),
                FontSize = 10
            };
            stateTxt = new TextBlock
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                FontSize = 16,
                FontWeight = FontWeights.Bold
            };

            var border = new Border
            {
                BorderThickness = new Thickness(1),
                BorderBrush = Brushes.Black
            };

            this.Children.Add(positionTxt);
            this.Children.Add(stateTxt);
            this.Children.Add(border);

            this.Background = Brushes.White;
        }

        private void Thing_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.State = this.State.GetNext();
        }

        private void Thing_Loaded(object sender, RoutedEventArgs e)
        {
            this.State = ThingState.False;
            //this.Position = "0111";
        }


        public ThingState State
        {
            get { return _state; }
            set
            {
                _state = value;
                this.stateTxt.Text = _state.GetLogicValue().ToString();
            }
        }

        public string Position
        {
            get { return _position; }
            set
            {
                _position = value;
                positionTxt.Text = " " + _position;
            }
        }

        public double Left
        {
            get { return this.Margin.Left; }
            set { this.Margin = new Thickness(value, this.Margin.Top, this.Margin.Right, this.Margin.Bottom); }
        }

        public double Top
        {
            get { return this.Margin.Top; }
            set { this.Margin = new Thickness(this.Margin.Left, value, this.Margin.Right, this.Margin.Bottom); }
        }

    }

    public enum ThingState
    {
        False,
        True,
        DontCare
    }
}