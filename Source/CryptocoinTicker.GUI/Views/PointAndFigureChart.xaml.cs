using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using CryptocoinTicker.GUI.DisplayClasses;

using Point = CryptocoinTicker.GUI.DisplayClasses.Point;

namespace CryptocoinTicker.GUI.Views
{
    /// <summary>
    /// Interaction logic for PointAndFigureChart.xaml
    /// </summary>
    public partial class PointAndFigureChart : UserControl, IChartView
    {
        public PointAndFigureChart()
        {
            InitializeComponent();

            this.Candles = new List<Candle>();
        }

        public string ChartName
        {
            get
            {
                return "Point and Figure";
            }
        }

        public bool IsLogarithmic { get; set; }
        public int PeriodSize { get; set; }
        public int PeriodsToDisplay { get; set; }
        
        private List<Candle> Candles { get; set; }

        private int X { get; set; }

        public decimal MaxChartValue { get; set; }

        public decimal MinChartValue { get; set; }

        public DateTime MinDate { get; set; }

        public DateTime MaxDate { get; set; }

        public decimal BoxSize { get; set; }

        private double AreaWidth
        {
            get
            {
                return this.ActualWidth - 50;
            }
        }

        private double AreaHeight
        {
            get
            {
                return this.ActualHeight;
            }
        }

        public void AddCandle(Candle candle)
        {
            if (!this.Candles.Contains(candle))
            {
                this.Candles.Add(candle);
            }
        }

        public void AddLine(string name, IEnumerable<Point> line)
        {
            return;
        }

        public void RemoveLine(string name)
        {
            return;
        }

        public void Redraw()
        {
            if (this.Candles.Count == 0)
            {
                return;
            }

            var candles = this.Candles.Distinct().OrderBy(c => c.Date).ToList();

            MinChartValue = candles.Min(c => c.Low);
            MaxChartValue = candles.Max(c => c.High);

            BoxSize = (MaxChartValue - MinChartValue) / 20;

            MinChartValue = Math.Round(MinChartValue / BoxSize, 0) * BoxSize;
            MaxChartValue = Math.Round(MaxChartValue / BoxSize, 0) * BoxSize;

            var firstCandle = candles.First();

            candles = candles.Skip(1).ToList();

            var boxes = new List<Box>();

            var lastBox = new Box(Math.Round(firstCandle.Close / BoxSize, 0) * BoxSize, 0, false);

            boxes.Add(lastBox);

            foreach (var candle in candles)
            {
                if (lastBox.IsX)
                {
                    if (Math.Round(candle.High, 1) - lastBox.Price > 0)
                    {
                        for (decimal i = lastBox.Price; i < Math.Round(candle.High, 1); i+=BoxSize)
                        {
                            lastBox = new Box(Math.Round(i / BoxSize, 0) * BoxSize, lastBox.Column, true);

                            boxes.Add(lastBox);
                        }
                        
                    }
                    else if (Math.Round(candle.Low, 1) - lastBox.Price <= 3 * BoxSize)
                    {
                        var col = lastBox.Column + 1;
                        for (decimal i = lastBox.Price - BoxSize; i > Math.Round(candle.Low, 1); i -= BoxSize)
                        {
                            lastBox = new Box(Math.Round(i/ BoxSize, 0) * BoxSize, col, false);

                            boxes.Add(lastBox);
                        }
                    }
                }
                else
                {
                    if (Math.Round(candle.Low, 1) - lastBox.Price < 0)
                    {
                        for (decimal i = lastBox.Price; i > Math.Round(candle.Low, 1); i -= BoxSize)
                        {
                            lastBox = new Box(Math.Round(i / BoxSize, 0) * BoxSize, lastBox.Column, false);

                            boxes.Add(lastBox);
                        }

                    }
                    else if (Math.Round(candle.High, 1) - lastBox.Price >= 3 * BoxSize)
                    {
                        var col = lastBox.Column + 1;
                        for (decimal i = lastBox.Price + BoxSize; i < Math.Round(candle.High, 1); i += BoxSize)
                        {
                            lastBox = new Box(Math.Round(i / BoxSize, 0) * BoxSize, col, true);

                            boxes.Add(lastBox);
                        }
                    }
                }
            }

            var colums = boxes.Max(b => b.Column);
            var width = AreaWidth / PeriodsToDisplay;
            var height = AreaHeight / 20;
            boxes = boxes.Where(b => b.Column > (colums - 100)).ToList();

            this.DrawYLegendChart();
            this.DrawGridlines();

            foreach (var box in boxes)
            {
                var y = this.AreaHeight * Convert.ToDouble(1m - ((box.Price - this.MinChartValue) / (this.MaxChartValue - this.MinChartValue)));
                var x = this.AreaWidth * ((1.0 * box.Column + Math.Max(0, PeriodsToDisplay - colums - 1)) / PeriodsToDisplay);

                if (box.IsX)
                {
                    var line = new Line();
                    line.X1 = x + (width * 0.1);
                    line.X2 = x + (width * 0.9);
                    line.Y1 = y - (height * 0.9);
                    line.Y2 = y - (height * 0.1);
                    line.Stroke = new SolidColorBrush(Colors.Green);
                    line.SnapsToDevicePixels = true;

                    this.ChartCanvas.Children.Add(line);

                    line = new Line();
                    line.X1 = x + (width * 0.1);
                    line.X2 = x + (width * 0.9);
                    line.Y1 = y - (height * 0.1);
                    line.Y2 = y - (height * 0.9);
                    line.Stroke = new SolidColorBrush(Colors.Green);
                    line.SnapsToDevicePixels = true;

                    this.ChartCanvas.Children.Add(line);
                }
                else
                {
                    var ellipse = new Ellipse();
                    ellipse.Height = height * 0.8;
                    ellipse.Width = width * 0.8;
                    ellipse.Stroke = new SolidColorBrush(Colors.Red);
                    ellipse.SnapsToDevicePixels = true;

                    this.ChartCanvas.Children.Add(ellipse);

                    Canvas.SetTop(ellipse, y - height * 0.9);
                    Canvas.SetLeft(ellipse, x + (width * 0.1));
                }
            }
        }

        private void DrawGridlines()
        {
            for (int i = 0; i < PeriodsToDisplay; i++)
            {
                var line = new Line();
                line.X1 = (1.0 * i) / PeriodsToDisplay * this.AreaWidth;
                line.X2 = line.X1;
                line.Y1 = 0;
                line.Y2 = this.ActualHeight;
                line.Stroke = new SolidColorBrush(Colors.Gray);
                line.StrokeThickness = 1;
                line.SnapsToDevicePixels = true;

                this.ChartCanvas.Children.Add(line);
            }
        }

        public void Clear()
        {
            this.Candles.Clear();
            this.ChartCanvas.Children.Clear();
        }

        private void DrawYLegendChart()
        {
            var height = this.AreaHeight;
            var line = new Line();
            line.Stroke = new SolidColorBrush(Colors.DimGray);
            line.X1 = this.AreaWidth;
            line.X2 = line.X1;
            line.Y1 = 0;
            line.Y2 = height;
            line.SnapsToDevicePixels = true;
            line.StrokeThickness = 1;

            this.ChartCanvas.Children.Add(line);

            for (int i = 0; i < 20; i++)
            {
                var horLine = new Line();
                horLine.Stroke = line.Stroke;
                horLine.StrokeThickness = 1;
                horLine.SnapsToDevicePixels = true;

                horLine.X1 = 0;
                horLine.X2 = this.AreaWidth + 5;
                horLine.Y1 = height - (i * height / 20);
                horLine.Y2 = horLine.Y1;

                this.ChartCanvas.Children.Add(horLine);

                var text = new TextBox();
                text.Text = this.FormatNumDigits((i * ((this.MaxChartValue - this.MinChartValue) / 20)) + this.MinChartValue, 5);
                text.Background = new SolidColorBrush(Colors.Black);
                text.Foreground = new SolidColorBrush(Colors.LightBlue);
                text.BorderThickness = new Thickness(0);
                text.Height = 12;
                text.FontSize = 8;
                this.ChartCanvas.Children.Add(text);
                Canvas.SetTop(text, horLine.Y1 - 8);
                Canvas.SetLeft(text, horLine.X2);
            }
        }

        private string FormatNumDigits(decimal number, int x)
        {
            string asString = number.ToString("F50", System.Globalization.CultureInfo.InvariantCulture);

            if (asString.Contains('.'))
            {
                if (asString.Length > x + 2)
                {
                    return asString.Substring(0, x + 2);
                }

                // Pad with zeros
                return asString.Insert(asString.Length, new String('0', x + 2 - asString.Length));
            }

            if (asString.Length > x + 1)
            {
                return asString.Substring(0, x + 1);
            }

            // Pad with zeros
            return asString.Insert(1, new String('0', x + 1 - asString.Length));
        }

        private class Box
        {
            public Box(decimal price, int column, bool isX)
            {
                Price = price;
                this.Column = column;
                IsX = isX;
            }

            public decimal Price { get; set; }

            public int Column { get; set; }

            public bool IsX { get; set; }
        }
    }
}
