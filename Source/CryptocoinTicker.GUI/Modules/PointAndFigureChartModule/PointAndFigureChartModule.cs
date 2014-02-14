using System;
using System.ComponentModel.Composition;
using System.Windows;
using System.Windows.Controls;

using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;

namespace CryptocoinTicker.GUI.Modules.PointAndFigureChartModule
{
    [ModuleExport(typeof(PointAndFigureChartModule))]
    public class PointAndFigureChartModule : IModule
    {
        private readonly IRegionViewRegistry regionViewRegistry;

        [ImportingConstructor]
        public PointAndFigureChartModule(IRegionViewRegistry registry)
        {
            this.regionViewRegistry = registry;
        }

        public void Initialize()
        {
            var subItem = new ListViewItem();
            subItem.Content = "Point & Figure";
            subItem.Selected += (object sender, RoutedEventArgs e) => this.ShowView();

            this.regionViewRegistry.RegisterViewWithRegion("ChartMenu", () => subItem);

            //We need to register our Module in MainRegion.
            this.regionViewRegistry.RegisterViewWithRegion("ChartRegion", typeof(Views.PointAndFigureChart));
            this.regionViewRegistry.RegisterViewWithRegion("ChartSettings", typeof(Views.PointAndFigureChartSettings));
        }

        public void ShowView()
        {
            // Initialize
            var regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();

            // Show Chart
            var chart = new Uri("PointAndFigureChart", UriKind.Relative);
            regionManager.RequestNavigate("ChartRegion", chart);

            var settings = new Uri("PointAndFigureChartSettings", UriKind.Relative);
            regionManager.RequestNavigate("ChartSettings", settings);
        }
    }
}