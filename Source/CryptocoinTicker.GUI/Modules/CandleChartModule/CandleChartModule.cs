﻿using System;
using System.ComponentModel.Composition;
using System.Windows;
using System.Windows.Controls;

using CryptocoinTicker.GUI.Modules.CandleChartModule.Views;

using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;

namespace CryptocoinTicker.GUI.Modules.CandleChartModule
{
    [ModuleExport(typeof(CandleChartModule))]
    public class CandleChartModule : IModule
    {
        private readonly IRegionViewRegistry regionViewRegistry;

        [ImportingConstructor]
        public CandleChartModule(IRegionViewRegistry registry)
        {
            this.regionViewRegistry = registry;
        }

        public void Initialize()
        {
            var subItem = new ListViewItem();
            subItem.Content = "Candles";
            subItem.Selected += (object sender, RoutedEventArgs e) => this.ShowView();

            this.regionViewRegistry.RegisterViewWithRegion("ChartMenu", () => subItem);

            //We need to register our Module in MainRegion.
            this.regionViewRegistry.RegisterViewWithRegion("ChartRegion", typeof(CandleChart));
            this.regionViewRegistry.RegisterViewWithRegion("ChartSettings", typeof(CandleChartSettings));
        }

        public void ShowView()
        {
            // Initialize
            var regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();

            // Show Chart
            var chart = new Uri("CandleChart", UriKind.Relative);
            regionManager.RequestNavigate("ChartRegion", chart);

            var settings = new Uri("CandleChartSettings", UriKind.Relative);
            regionManager.RequestNavigate("ChartSettings", settings);
        }
    }
}