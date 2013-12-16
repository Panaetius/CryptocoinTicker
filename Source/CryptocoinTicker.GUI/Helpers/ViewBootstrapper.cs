using System;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Windows;

using CryptocoinTicker.GUI.Modules.CandleChartModule;
using CryptocoinTicker.GUI.Modules.DepthChartModule;
using CryptocoinTicker.GUI.Modules.PointAndFigureChartModule;
using CryptocoinTicker.GUI.Views;

using Microsoft.Practices.Prism.MefExtensions;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;

namespace CryptocoinTicker.GUI.Helpers
{
    public class ViewBootstrapper : MefBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            var container = this.Container.GetExportedValue<MainWindow>();

            return container;
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

            var catalog = new DirectoryCatalog("./");

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