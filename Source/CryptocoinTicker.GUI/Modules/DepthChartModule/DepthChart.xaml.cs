using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

using CryptocoinTicker.Contract;
using CryptocoinTicker.GUI.DisplayClasses;

using Point = System.Windows.Point;

namespace CryptocoinTicker.GUI.Modules.DepthChartModule
{
    /// <summary>
    /// Interaction logic for DepthView.xaml
    /// </summary>
    public partial class DepthChart : UserControl, IDepthView
    {
        public DepthChart()
        {
            InitializeComponent();

            this.MouseLeave += this.DepthView_MouseLeave;
            this.DepthCanvas.MouseMove += this.DepthView_MouseMove;
        }

        private Depth Depth { get; set; }

        private decimal MaxAmount { get; set; }

        private decimal MaxPrice { get; set; }

        private decimal MinPrice { get; set; }

        private Polygon AsksPolygon { get; set; }

        private Polygon BidsPolygon { get; set; }

        public void SetDepth(Depth depth)
        {
            this.DepthCanvas.Children.Clear();

            this.Depth = depth;

            if (!this.Depth.Asks.Any() || !this.Depth.Bids.Any())
            {
                return;
            }

            this.MaxAmount = Math.Max(this.Depth.Asks.Sum(a => a.Amount), this.Depth.Bids.Sum(b => b.Amount));

            this.MaxPrice = this.Depth.Asks.Max(a => a.Price);

            this.MinPrice = this.Depth.Bids.Min(b => b.Price);

            if (this.MaxPrice == this.MinPrice)
            {
                return;
            }

            this.DrawXAxis();

            this.DrawAsks();

            this.DrawBids();

            this.DrawYAxis();
        }

        private void DrawBids()
        {
            var bids = this.Depth.Bids.OrderByDescending(b => b.Price);

            var points = new PointCollection();

            var amount = 0M;

            foreach (var bid in bids)
            {
                var point = new Point(this.ValueToX(bid.Price), this.ValueToY(amount));

                points.Add(point);

                amount += bid.Amount;

                point = new Point(this.ValueToX(bid.Price), this.ValueToY(amount));

                points.Add(point);
            }

            points.Add(new Point(0, this.ActualHeight - 30));
            points.Add(new Point(this.ValueToX(bids.First().Price), this.ValueToY(0)));

            this.BidsPolygon = new Polygon();
            this.BidsPolygon.Stroke = new SolidColorBrush(Colors.Red);
            this.BidsPolygon.StrokeThickness = 1;
            this.BidsPolygon.SnapsToDevicePixels = true;
            this.BidsPolygon.Points = points;
            this.BidsPolygon.FillRule = FillRule.Nonzero;
            this.BidsPolygon.Fill = this.BidsPolygon.Stroke;

            this.DepthCanvas.Children.Add(this.BidsPolygon);
        }

        private void DrawAsks()
        {
            var asks = this.Depth.Asks.OrderBy(a => a.Price);

            var points = new PointCollection();

            var amount = 0M;

            foreach (var ask in asks)
            {
                var point = new Point(this.ValueToX(ask.Price), this.ValueToY(amount));

                points.Add(point);

                amount += ask.Amount;

                point = new Point(this.ValueToX(ask.Price), this.ValueToY(amount));

                points.Add(point);
            }

            points.Add(new Point(this.ActualWidth - 50, this.ActualHeight - 30));
            points.Add(new Point(this.ValueToX(asks.First().Price), this.ValueToY(0)));

            this.AsksPolygon = new Polygon();
            this.AsksPolygon.Stroke = new SolidColorBrush(Colors.Green);
            this.AsksPolygon.StrokeThickness = 1;
            this.AsksPolygon.SnapsToDevicePixels = true;
            this.AsksPolygon.Points = points;
            this.AsksPolygon.FillRule = FillRule.EvenOdd;
            this.AsksPolygon.Fill = this.AsksPolygon.Stroke;

            this.DepthCanvas.Children.Add(this.AsksPolygon);
        }

        private void DrawXAxis()
        {
            var line = new Line();
            line.Stroke = new SolidColorBrush(Colors.DimGray);
            line.X1 = 0;
            line.X2 = this.DepthCanvas.ActualWidth - 50;
            line.Y1 = this.ActualHeight - 30;
            line.Y2 = line.Y1;
            line.StrokeThickness = 1;
            line.SnapsToDevicePixels = true;

            this.DepthCanvas.Children.Add(line);

            for (int i = 0; i < 10; i++)
            {
                var vertLine = new Line();
                vertLine.Stroke = line.Stroke;
                vertLine.X1 = (i * Convert.ToInt32(this.DepthCanvas.ActualWidth - 50)) / 10.0;
                vertLine.X2 = vertLine.X1;
                vertLine.Y1 = line.Y1;
                vertLine.Y2 = line.Y1 + 5;
                vertLine.StrokeThickness = 1;
                vertLine.SnapsToDevicePixels = true;

                this.DepthCanvas.Children.Add(vertLine);

                var text = new TextBox();
                text.Text = this.FormatNumDigits(this.MinPrice + ((i * (this.MaxPrice - this.MinPrice)) / 10), 5);
                text.Background = new SolidColorBrush(Colors.Black);
                text.Foreground = new SolidColorBrush(Colors.LightBlue);
                text.BorderThickness = new Thickness(0);
                text.Height = 20;
                this.DepthCanvas.Children.Add(text);
                Canvas.SetTop(text, line.Y1 + 6);
                Canvas.SetLeft(text, vertLine.X1);
            }
        }

        private void DrawYAxis()
        {
            var x = this.ActualWidth - 50;

            var line = new Line();
            line.X1 = x;
            line.X2 = line.X1;
            line.Y1 = 0;
            line.Y2 = this.ActualHeight - 30;
            line.Stroke = new SolidColorBrush(Colors.DimGray);
            line.StrokeThickness = 1;
            line.SnapsToDevicePixels = true;

            this.DepthCanvas.Children.Add(line);

            for (int i = 0; i < 10; i++)
            {
                var vertLine = new Line();
                vertLine.X1 = 0;
                vertLine.X2 = x + 5;
                vertLine.Y1 = line.Y2 - ((i * line.Y2) / 10);
                vertLine.Y2 = vertLine.Y1;
                vertLine.Stroke = line.Stroke;
                vertLine.StrokeThickness = 1;
                vertLine.SnapsToDevicePixels = true;

                this.DepthCanvas.Children.Add(vertLine);

                var text = new TextBox();
                text.Text = this.FormatNumDigits((i * ((this.MaxAmount) / 10)), 5);
                text.Background = new SolidColorBrush(Colors.Black);
                text.Foreground = new SolidColorBrush(Colors.LightBlue);
                text.BorderThickness = new Thickness(0);
                text.Height = 12;
                text.FontSize = 8;
                this.DepthCanvas.Children.Add(text);
                Canvas.SetTop(text, vertLine.Y1 - 8);
                Canvas.SetLeft(text, vertLine.X2);
            }
        }

        private double ValueToX(decimal value)
        {
            return (this.DepthCanvas.ActualWidth - 50) * Convert.ToDouble((value - this.MinPrice) / (this.MaxPrice - this.MinPrice));
        }

        private double ValueToY(decimal value)
        {
            return ((this.DepthCanvas.ActualHeight - 30) * Convert.ToDouble(this.MaxAmount - value)) / Convert.ToDouble(this.MaxAmount);
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

        private string FormatNumDigits(double number, int x)
        {
            return this.FormatNumDigits(Convert.ToDecimal(number), x);
        }

        private void DepthView_MouseLeave(object sender, MouseEventArgs e)
        {
            this.InfoPopup.IsOpen = false;
        }

        private void DepthView_MouseMove(object sender, MouseEventArgs e)
        {
            var point = e.GetPosition(sender as Canvas);

            if (this.AsksPolygon == null || this.BidsPolygon == null || point.X >= this.ActualWidth - 50 || point.Y >= this.ActualHeight - 30)
            {
                return;
            }

            if (!this.InfoPopup.IsOpen)
            {
                this.InfoPopup.IsOpen = true;
            }

            this.InfoPopup.HorizontalOffset = point.X + 20;
            this.InfoPopup.VerticalOffset = point.Y;

            this.Volume.Text = string.Format(
                "Volume: {0}",
                this.FormatNumDigits((1 - (point.Y / (this.ActualHeight - 30))) * Convert.ToDouble(this.MaxAmount), 6));

            this.Price.Text = string.Format(
                "Price: {0}",
                this.FormatNumDigits(
                    ((point.X / (this.ActualWidth - 50)) * Convert.ToDouble(this.MaxPrice - this.MinPrice))
                    + Convert.ToDouble(this.MinPrice),
                    6));
        }
    }
}
