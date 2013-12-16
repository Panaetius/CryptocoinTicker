using System.Windows;

using CryptocoinTicker.GUI.Helpers;

namespace CryptocoinTicker.GUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var bootstrapper = new ViewBootstrapper();
            bootstrapper.Run();
        }
    }
}
