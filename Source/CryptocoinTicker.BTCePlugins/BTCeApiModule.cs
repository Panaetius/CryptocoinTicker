using System;
using System.ComponentModel.Composition;

using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;

namespace CryptocoinTicker.BTCePlugins
{
    [ModuleExport(typeof(BTCeApiModule), InitializationMode = InitializationMode.OnDemand)]
    public class BTCeApiModule : IModule
    {
        private readonly IRegionViewRegistry regionViewRegistry;

        [ImportingConstructor]
        public BTCeApiModule(IRegionViewRegistry registry)
        {
            this.regionViewRegistry = registry;
        }

        public void Initialize()
        {
            //We need to register our Module in MainRegion.
            this.regionViewRegistry.RegisterViewWithRegion("TradeRegion", typeof(BTCeTradeView));
            this.regionViewRegistry.RegisterViewWithRegion("ApiSettings", typeof(BTCeTradeSettings));
        }
    }
}