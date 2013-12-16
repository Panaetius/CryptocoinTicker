using System.Windows;

using CryptocoinTicker.GUI.Modules.CandleChartModule;
using CryptocoinTicker.GUI.Modules.DepthChartModule;
using CryptocoinTicker.GUI.Modules.PointAndFigureChartModule;
using CryptocoinTicker.GUI.Views;

using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Unity;

namespace CryptocoinTicker.GUI.Helpers
{
    public class ViewBootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return this.Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();

            App.Current.MainWindow = (Window)this.Shell;
            App.Current.MainWindow.Show();
        }

        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();

            ModuleCatalog moduleCatalog = (ModuleCatalog)this.ModuleCatalog;

            moduleCatalog.AddModule(typeof(CandleChartModule));
            moduleCatalog.AddModule(typeof(DepthChartModule));
            moduleCatalog.AddModule(typeof(PointAndFigureChartModule));
        }
    }
}