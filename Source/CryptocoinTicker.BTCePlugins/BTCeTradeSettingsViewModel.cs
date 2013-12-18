using System.ComponentModel.Composition;
using System.Linq;
using System.Windows.Controls;
using CryptocoinTicker.Contract;
using CryptocoinTicker.Helpers;
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
                return Settings.Default.ApiKey.DecryptString().ToInsecureString();
            }

            set
            {
                Settings.Default.ApiKey = value.ToSecureString().EncryptString();
                Settings.Default.Save();
            }
        }

        public string ApiSecret
        {
            get
            {
                return Settings.Default.ApiSecret.DecryptString().ToInsecureString();
            }

            set
            {
                Settings.Default.ApiSecret = value.ToSecureString().EncryptString();
                Settings.Default.Save();
            }
        }
    }
}