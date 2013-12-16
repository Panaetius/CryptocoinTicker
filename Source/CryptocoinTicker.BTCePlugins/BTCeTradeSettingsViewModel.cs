using System.ComponentModel.Composition;
using System.Linq;

using CryptocoinTicker.Contract;

using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;

namespace CryptocoinTicker.BTCePlugins
{
    [Export(typeof(ViewModelBase))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class BTCeTradeSettingsViewModel
    {
        private string apiKey;

        private string apiSecret;

        public string ApiKey
        {
            get
            {
                return
                    ((BTCeTradeViewModel)
                     ServiceLocator.Current.GetInstance<IRegionManager>().Regions["TradeRegion"].ActiveViews
                         .FirstOrDefault()).ApiKey;
            }
            set
            {
                ((BTCeTradeViewModel)
                 ServiceLocator.Current.GetInstance<IRegionManager>().Regions["TradeRegion"].ActiveViews.FirstOrDefault(
                     )).ApiKey = value;
            }
        }

        public string ApiSecret
        {
            get
            {
                return
                    ((BTCeTradeViewModel)
                     ServiceLocator.Current.GetInstance<IRegionManager>().Regions["TradeRegion"].ActiveViews
                         .FirstOrDefault()).ApiSecret;
            }
            set
            {
                ((BTCeTradeViewModel)
                 ServiceLocator.Current.GetInstance<IRegionManager>().Regions["TradeRegion"].ActiveViews.FirstOrDefault(
                     )).ApiSecret = value;
            }
        }
    }
}