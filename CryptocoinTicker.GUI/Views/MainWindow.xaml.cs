using System.Windows;

namespace CryptocoinTicker.GUI.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            this.ChartView.Content = new ChartView();
            this.DepthView.Content = new DepthView();
        }
    }
}
