using System.Collections.ObjectModel;
using System.Reflection;
using System.Windows;

using CryptocoinTicker.GUI.DisplayClasses;

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

            this.AboutMenuItem.Click += this.ShowAboutDialog;
        }

        public void ShowAboutDialog(object sender, RoutedEventArgs routedEventArgs)
        {
            var about = new About();

            about.Version.Text = Assembly.GetExecutingAssembly().GetName().Version.ToString();

            about.ShowDialog();
        }
    }
}
