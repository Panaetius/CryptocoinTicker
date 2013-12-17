using System.ComponentModel.Composition;
using System.Linq;
using System.Windows.Controls;
using CryptocoinTicker.Contract;

using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;

namespace CryptocoinTicker.BTCePlugins
{
    [Export(typeof(ViewModelBase))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class BTCeTradeSettingsViewModel
    {
        public string ApiKey
        {
            get
            {
                return
                    ((BTCeTradeViewModel)
                     ServiceLocator.Current.GetInstance<IRegionManager>().Regions["TradeRegion"].ActiveViews.Cast<UserControl>()
                         .FirstOrDefault().DataContext).ApiKey;
            }
            set
            {
                ((BTCeTradeViewModel)
                 ServiceLocator.Current.GetInstance<IRegionManager>().Regions["TradeRegion"].ActiveViews.Cast<UserControl>().FirstOrDefault(
                     ).DataContext).ApiKey = value;
            }
        }

        public string ApiSecret
        {
            get
            {
                return
                    ((BTCeTradeViewModel)
                     ServiceLocator.Current.GetInstance<IRegionManager>().Regions["TradeRegion"].ActiveViews.Cast<UserControl>()
                         .FirstOrDefault().DataContext).ApiSecret;
            }
            set
            {
                ((BTCeTradeViewModel)
                 ServiceLocator.Current.GetInstance<IRegionManager>().Regions["TradeRegion"].ActiveViews.Cast<UserControl>().FirstOrDefault(
                     ).DataContext).ApiSecret = value;
            }
        }
    }
}