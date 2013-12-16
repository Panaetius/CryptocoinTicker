using System;
using System.Windows;
using System.Windows.Controls;

using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;

namespace CryptocoinTicker.GUI.Modules.DepthChartModule
{
    public class DepthChartModule : IModule
    {
        private readonly IRegionViewRegistry regionViewRegistry;

        public DepthChartModule(IRegionViewRegistry registry)
        {
            this.regionViewRegistry = registry;
        }

        public void Initialize()
        {
            var subItem = new ListViewItem();
            subItem.Content = "Depth";
            subItem.Selected += (object sender, RoutedEventArgs e) => this.ShowView();

            this.regionViewRegistry.RegisterViewWithRegion("ChartMenu", () => subItem);

            //We need to register our Module in MainRegion.
            this.regionViewRegistry.RegisterViewWithRegion("ChartRegion", typeof(DepthChart));
            this.regionViewRegistry.RegisterViewWithRegion("ChartSettings", typeof(DepthChartSettings));
        }

        public void ShowView()
        {
            // Initialize
            var regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();

            // Show Chart
            var chart = new Uri("DepthChart", UriKind.Relative);
            regionManager.RequestNavigate("ChartRegion", chart);

            var settings = new Uri("DepthChartSettings", UriKind.Relative);
            regionManager.RequestNavigate("ChartSettings", settings);
        }
    }
}