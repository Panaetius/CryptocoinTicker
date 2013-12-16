using System;
using System.ComponentModel.Composition;

using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;

namespace CryptocoinTicker.VircurexPlugins
{
    [ModuleExport(typeof(VircurexApiModule), InitializationMode = InitializationMode.OnDemand)]
    public class VircurexApiModule : IModule
    {
        private readonly IRegionViewRegistry regionViewRegistry;

        [ImportingConstructor]
        public VircurexApiModule(IRegionViewRegistry registry)
        {
            this.regionViewRegistry = registry;
        }

        public void Initialize()
        {
            //We need to register our Module in MainRegion.
            this.regionViewRegistry.RegisterViewWithRegion("TradeRegion", typeof(VircurexTradeView));
        }
    }
}