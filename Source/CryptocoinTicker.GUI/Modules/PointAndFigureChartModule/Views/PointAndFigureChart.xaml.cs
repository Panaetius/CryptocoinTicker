using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

using CryptocoinTicker.GUI.DisplayClasses;

using Point = CryptocoinTicker.GUI.DisplayClasses.Point;

namespace CryptocoinTicker.GUI.Modules.PointAndFigureChartModule.Views
{
    /// <summary>
    /// Interaction logic for PointAndFigureChart.xaml
    /// </summary>
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class PointAndFigureChart : UserControl, IChartView
    {
        public PointAndFigureChart()
        {
            InitializeComponent();

            this.Candles = new List<Candle>();
            this.PeriodSize = 900;
            this.PeriodsToDisplay = 100;
            this.BoxSize = -0.04m;
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

            this.MinChartValue = candles.Min(c => c.Low);
            this.MaxChartValue = candles.Max(c => c.High);

            var firstCandle = candles.First();

            candles = candles.Skip(1).ToList();

            var boxSize = this.BoxSize;

            if (boxSize < 0)
            {
                boxSize = boxSize * -1 * this.MaxChartValue;
            }

            this.MinChartValue = Math.Round(this.MinChartValue / boxSize, 0) * boxSize;
            this.MaxChartValue = Math.Round(this.MaxChartValue / boxSize, 0) * boxSize;

            var boxes = new List<Box>();

            var lastBox = new Box(Math.Round(firstCandle.Close / boxSize, 0) * boxSize, 0, false);

            boxes.Add(lastBox);

            foreach (var candle in candles)
            {
                if (lastBox.IsX)
                {
                    if (Math.Round(candle.High, 1) - lastBox.Price > 0)
                    {
                        for (decimal i = lastBox.Price; i < Math.Round(candle.High, 1); i += boxSize)
                        {
                            lastBox = new Box(Math.Round(i / boxSize, 0) * boxSize, lastBox.Column, true);

                            boxes.Add(lastBox);
                        }
                        
                    }
                    else if (Math.Round(candle.Low, 1) - lastBox.Price <= 3 * boxSize)
                    {
                        var col = lastBox.Column + 1;
                        for (decimal i = lastBox.Price - boxSize; i > Math.Round(candle.Low, 1); i -= boxSize)
                        {
                            lastBox = new Box(Math.Round(i / boxSize, 0) * boxSize, col, false);

                            boxes.Add(lastBox);
                        }
                    }
                }
                else
                {
                    if (Math.Round(candle.Low, 1) - lastBox.Price < 0)
                    {
                        for (decimal i = lastBox.Price; i > Math.Round(candle.Low, 1); i -= boxSize)
                        {
                            lastBox = new Box(Math.Round(i / boxSize, 0) * boxSize, lastBox.Column, false);

                            boxes.Add(lastBox);
                        }

                    }
                    else if (Math.Round(candle.High, 1) - lastBox.Price >= 3 * this.BoxSize)
                    {
                        var col = lastBox.Column + 1;
                        for (decimal i = lastBox.Price + boxSize; i < Math.Round(candle.High, 1); i += boxSize)
                        {
                            lastBox = new Box(Math.Round(i / boxSize, 0) * boxSize, col, true);

                            boxes.Add(lastBox);
                        }
                    }
                }
            }

            var colums = boxes.Max(b => b.Column);
            var rows = Math.Ceiling((boxes.Max(b => b.Price) - boxes.Min(b => b.Price)) / boxSize);
            var width = this.AreaWidth / this.PeriodsToDisplay;
            var height = this.AreaHeight / 20;
            boxes = boxes.Where(b => b.Column > (colums - 100)).ToList();

            this.DrawYLegendChart(rows);
            this.DrawGridlines();

            foreach (var box in boxes)
            {
                var y = this.AreaHeight * Convert.ToDouble(1m - ((box.Price - this.MinChartValue) / (boxSize + this.MaxChartValue - this.MinChartValue)));
                var x = this.AreaWidth * ((1.0 * box.Column + Math.Max(0, this.PeriodsToDisplay - colums - 1)) / this.PeriodsToDisplay);

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
            for (int i = 0; i < this.PeriodsToDisplay; i++)
            {
                var line = new Line();
                line.X1 = (1.0 * i) / this.PeriodsToDisplay * this.AreaWidth;
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

        private void DrawYLegendChart(decimal numRows)
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

            numRows += 1;

            this.ChartCanvas.Children.Add(line);

            for (int i = 0; i < numRows; i++)
            {
                var horLine = new Line();
                horLine.Stroke = line.Stroke;
                horLine.StrokeThickness = 1;
                horLine.SnapsToDevicePixels = true;

                horLine.X1 = 0;
                horLine.X2 = this.AreaWidth + 5;
                horLine.Y1 = height - (i * height / Convert.ToDouble(numRows));
                horLine.Y2 = horLine.Y1;

                this.ChartCanvas.Children.Add(horLine);

                var text = new TextBox();
                text.Text = this.FormatNumDigits((i * ((this.MaxChartValue - this.MinChartValue) / numRows)) + this.MinChartValue, 5);
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
                this.Price = price;
                this.Column = column;
                this.IsX = isX;
            }

            public decimal Price { get; set; }

            public int Column { get; set; }

            public bool IsX { get; set; }
        }
    }
}
