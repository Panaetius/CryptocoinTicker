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

using CryptocoinTicker.GUI.DisplayClasses;

using Point = CryptocoinTicker.GUI.DisplayClasses.Point;

namespace CryptocoinTicker.GUI.Views
{
    /// <summary>
    /// Interaction logic for ChartView.xaml
    /// </summary>
    public partial class ChartView : UserControl, IChartView
    {
        private bool isDragging;

        private System.Windows.Point clickPosition;

        public ChartView()
        {
            this.Candles = new List<Candle>();
            this.Volumes = new List<VolumeBar>();
            Lines = new Dictionary<string, IEnumerable<Point>>();

            X = 0;

            InitializeComponent();

            this.MouseLeftButtonDown += new MouseButtonEventHandler(Control_MouseLeftButtonDown);
            this.MouseLeftButtonUp += new MouseButtonEventHandler(Control_MouseLeftButtonUp);
            this.MouseMove += new MouseEventHandler(Control_MouseMove);
        }

        public bool IsLogarithmic { get; set; }

        public int PeriodSize { get; set; }

        public int PeriodsToDisplay { get; set; }

        private DateTime MinDate { get; set; }

        private DateTime MaxDate { get; set; }

        private decimal MinChartValue { get; set; }

        private decimal MaxChartValue { get; set; }

        private decimal MaxVolumeValue { get; set; }

        private Dictionary<string, IEnumerable<Point>> Lines { get; set; }

        private List<Candle> Candles { get; set; }

        private List<VolumeBar> Volumes { get; set; }

        private int X { get; set; }

        public void AddCandle(Candle candle)
        {
            if (!this.Candles.Contains(candle))
            {
                this.Candles.Add(candle);
            }
        }

        public void Redraw()
        {
            var candles = this.Candles.Distinct().OrderByDescending(c => c.Date).Skip(X).Take(this.PeriodsToDisplay).ToList();

            MaxDate = candles.Max(c => c.Date);
            MinDate = MaxDate.AddSeconds(-1 * this.PeriodSize * this.PeriodsToDisplay);
            candles = candles.Where(c => c.Date > MinDate).ToList();
            MinChartValue = candles.Min(c => c.Low);
            MaxChartValue = candles.Max(c => c.High);
            MaxVolumeValue = candles.Max(c => c.Volume);

            this.DrawTimelineChart();
            this.DrawYLegendChart();
            this.DrawVolumeLegend();

            this.DrawCandles(candles);
        }

        private void DrawVolumeLegend()
        {
            var height = ((this.ChartCanvas.ActualHeight * 3) / 4) - 30;
            var line = new Line();
            line.Stroke = new SolidColorBrush(Colors.DimGray);
            line.X1 = this.ActualWidth - 50;
            line.X2 = line.X1;
            line.Y1 = height - 30;
            line.Y2 = this.ActualHeight - 2;
            line.SnapsToDevicePixels = true;
            line.StrokeThickness = 1;

            this.ChartCanvas.Children.Add(line);

            for (int i = 0; i < 6; i++)
            {
                var horLine = new Line();
                horLine.Stroke = line.Stroke;
                horLine.StrokeThickness = 1;
                horLine.SnapsToDevicePixels = true;

                horLine.X1 = 0;
                horLine.X2 = this.ActualWidth - 45;
                horLine.Y1 = this.ActualHeight - (i * (this.ActualHeight - height - 30) / 5) - 2;
                horLine.Y2 = horLine.Y1;

                this.ChartCanvas.Children.Add(horLine);

                var text = new TextBox();
                text.Text = this.FormatNumDigits((i * (this.MaxVolumeValue / 5)), 5);
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

        private void DrawCandles(List<Candle> candles)
        {
            if (candles.Count < 2)
            {
                return;
            }

            var minHeight = ((this.ChartCanvas.ActualHeight * 3) / 4) - 30;

            foreach (var candle in candles)
            {
                var x = (candle.Date.Subtract(this.MinDate).TotalSeconds / this.PeriodSize)
                        * ((this.ActualWidth - 50) / this.PeriodsToDisplay);

                Brush brush;

                if (candle.Close > candle.Open)
                {
                    brush = new SolidColorBrush(Colors.Green);
                }
                else
                {
                    brush = new SolidColorBrush(Colors.Red);
                }

                var line = new Line();
                line.X1 = x;
                line.X2 = x;
                line.Y1 = this.GetAbsoluteHeight(minHeight, candle.Low);
                line.Y2 = this.GetAbsoluteHeight(minHeight, candle.High);
                line.StrokeThickness = 1;
                line.SnapsToDevicePixels = true;
                line.Stroke = brush;

                this.ChartCanvas.Children.Add(line);

                var rect = new Rectangle();
                rect.Width = 5;
                rect.Height = Math.Max((minHeight * Convert.ToDouble(Math.Abs(candle.Open - candle.Close)))
                              / (Convert.ToDouble(MaxChartValue - MinChartValue)), 1);
                rect.SnapsToDevicePixels = true;
                rect.Stroke = brush;
                rect.Fill = brush;

                this.ChartCanvas.Children.Add(rect);
                Canvas.SetTop(rect, this.GetAbsoluteHeight(minHeight, Math.Max(candle.Open, candle.Close)));
                Canvas.SetLeft(rect, x - 2.5);

                //draw volume
                rect = new Rectangle();
                rect.Width = 5;
                rect.Height = (this.ActualHeight - minHeight - 30) * Convert.ToDouble(candle.Volume / this.MaxVolumeValue);
                rect.SnapsToDevicePixels = true;
                rect.Stroke = brush;
                rect.Fill = brush;
                this.ChartCanvas.Children.Add(rect);
                Canvas.SetTop(rect, this.ActualHeight - rect.Height - 2);
                Canvas.SetLeft(rect, x - 2.5);
            }
        }

        private double GetAbsoluteHeight(double minHeight, decimal val)
        {
            return minHeight - ((minHeight * Convert.ToDouble(val - this.MinChartValue)) / Convert.ToDouble(this.MaxChartValue - this.MinChartValue));
        }

        public void Clear()
        {
            this.Candles.Clear();
            this.Lines.Clear();
            this.Volumes.Clear();
            this.ChartCanvas.Children.Clear();
        }

        private void DrawYLegendChart()
        {
            var height = ((this.ChartCanvas.ActualHeight * 3) / 4);
            var line = new Line();
            line.Stroke = new SolidColorBrush(Colors.DimGray);
            line.X1 = this.ActualWidth - 50;
            line.X2 = line.X1;
            line.Y1 = 0;
            line.Y2 = height - 30;
            line.SnapsToDevicePixels = true;
            line.StrokeThickness = 1;

            this.ChartCanvas.Children.Add(line);

            for (int i = 0; i < 9; i++)
            {
                var horLine = new Line();
                horLine.Stroke = line.Stroke;
                horLine.StrokeThickness = 1;
                horLine.SnapsToDevicePixels = true;

                horLine.X1 = 0;
                horLine.X2 = this.ActualWidth - 45;
                horLine.Y1 = height - (i * height / 10) - 30;
                horLine.Y2 = horLine.Y1;

                this.ChartCanvas.Children.Add(horLine);

                var text = new TextBox();
                text.Text = this.FormatNumDigits((i * ((this.MaxChartValue - this.MinChartValue) / 10)) + this.MinChartValue, 5);
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

        private void DrawTimelineChart()
        {
            var line = new Line();
            line.Stroke = new SolidColorBrush(Colors.DimGray);
            line.X1 = 0;
            line.X2 = this.ChartCanvas.ActualWidth - 50;
            line.Y1 = ((this.ChartCanvas.ActualHeight * 3) / 4) - 30;
            line.Y2 = line.Y1;
            line.StrokeThickness = 1;
            line.SnapsToDevicePixels = true;

            this.ChartCanvas.Children.Add(line);

            for (int i = 0; i < this.PeriodsToDisplay / 10; i++)
            {
                var vertLine = new Line();
                vertLine.Stroke = line.Stroke;
                vertLine.X1 = (10 * i * Convert.ToInt32(this.ChartCanvas.ActualWidth - 50)) / this.PeriodsToDisplay;
                vertLine.X2 = vertLine.X1;
                vertLine.Y1 = line.Y1;
                vertLine.Y2 = line.Y1 - 5;
                vertLine.StrokeThickness = 1;
                vertLine.SnapsToDevicePixels = true;

                this.ChartCanvas.Children.Add(vertLine);

                var text = new TextBox();
                text.Text = this.MinDate.AddSeconds(i * 10 * this.PeriodSize).ToString("HH:mm");
                text.Background = new SolidColorBrush(Colors.Black);
                text.Foreground = new SolidColorBrush(Colors.LightBlue);
                text.BorderThickness = new Thickness(0);
                text.Height = 20;
                this.ChartCanvas.Children.Add(text);
                Canvas.SetTop(text, line.Y1 + 6);
                Canvas.SetLeft(text, vertLine.X1);
            }
        }

        public void AddLine(string name, IEnumerable<Point> line)
        {

            this.Lines.Add(name, line);
        }

        public void RemoveLine(string name)
        {
            if (this.Lines.ContainsKey(name))
            {
                this.Lines.Remove(name);
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

        private void Control_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isDragging = true;
            var draggableControl = sender as UserControl;
            clickPosition = e.GetPosition(this);
            draggableControl.CaptureMouse();
        }

        private void Control_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isDragging = false;
            var draggable = sender as UserControl;
            draggable.ReleaseMouseCapture();
            this.ChartCanvas.Children.Clear();
            this.Redraw();
        }

        private void Control_MouseMove(object sender, MouseEventArgs e)
        {
            var draggableControl = sender as UserControl;

            if (isDragging && draggableControl != null)
            {
                System.Windows.Point currentPosition = e.GetPosition(this.Parent as UIElement);

                var relativeX = currentPosition.X - clickPosition.X;
                var relativeY = currentPosition.Y - clickPosition.Y;

                var relativeChange = this.PeriodsToDisplay * relativeX / (this.ActualWidth * 10);

                this.X = Math.Min(
                    this.Candles.Count - this.PeriodsToDisplay,
                    Math.Max(0, Convert.ToInt32(this.X + relativeChange)));
            }
        }
    }
}
