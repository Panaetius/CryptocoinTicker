using System;
using System.ComponentModel.Composition.Hosting;
using System.Windows;

using CryptocoinTicker.GUI.Modules.CandleChartModule;
using CryptocoinTicker.GUI.Modules.DepthChartModule;
using CryptocoinTicker.GUI.Modules.PointAndFigureChartModule;
using CryptocoinTicker.GUI.Views;

using Microsoft.Practices.Prism.MefExtensions;
using Microsoft.Practices.Prism.Modularity;

namespace CryptocoinTicker.GUI.Helpers
{
    public class ViewBootstrapper : MefBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return this.Container.GetExportedValue<MainWindow>();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();

            App.Current.MainWindow = (Window)this.Shell;
            App.Current.MainWindow.Show();
        }

        protected override void ConfigureAggregateCatalog()
        {
            base.ConfigureAggregateCatalog();
            this.AggregateCatalog.Catalogs.Add(
                new AssemblyCatalog(typeof(ViewBootstrapper).Assembly));

            DirectoryCatalog catalog = new DirectoryCatalog("./");
            this.AggregateCatalog.Catalogs.Add(catalog);
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            // When using MEF, the existing Prism ModuleCatalog is still the place to 
            // configure modules via configuration files.
            return new ConfigurationModuleCatalog();
        }
    }
}