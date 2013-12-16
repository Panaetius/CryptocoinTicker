using System.ComponentModel.Composition;
using System.Windows.Input;

using CryptocoinTicker.Contract;

namespace CryptocoinTicker.BTCePlugins
{
    [Export(typeof(ViewModelBase))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class BTCeTradeViewModel:ViewModelBase
    {
        public BTCeTradeViewModel()
        {
            this.BuyCommand = new RelayCommand(this.Buy);
            this.SellCommand = new RelayCommand(this.Sell);
        }

        private void Buy(object obj)
        {
            throw new System.NotImplementedException();
        }

        private void Sell(object obj)
        {
            throw new System.NotImplementedException();
        }

        private string buyAmount;

        private string buyPrice;

        private string sellAmount;

        private string sellPrice;

        public string ApiKey
        {
            get
            {
                return Settings.Default.ApiKey;
            }

            set
            {
                Settings.Default.ApiKey = value;
                Settings.Default.Save();
            }
        }

        public string ApiSecret
        {
            get
            {
                return Settings.Default.ApiSecret;
            }

            set
            {
                Settings.Default.ApiSecret = value;
                Settings.Default.Save();
            }
        }

        public string BuyAmount
        {
            get
            {
                return this.buyAmount;
            }
            set
            {
                this.buyAmount = value;
                this.OnPropertyChanged("BuyAmount");
            }
        }

        public string BuyPrice
        {
            get
            {
                return this.buyPrice;
            }
            set
            {
                this.buyPrice = value;
                this.OnPropertyChanged("BuyPrice");
            }
        }

        public string SellAmount
        {
            get
            {
                return this.sellAmount;
            }
            set
            {
                this.sellAmount = value;
                this.OnPropertyChanged("SellAmount");
            }
        }

        public string SellPrice
        {
            get
            {
                return this.sellPrice;
            }
            set
            {
                this.sellPrice = value;
                this.OnPropertyChanged("SellPrice");
            }
        }

        public ICommand BuyCommand { get; set; }

        public ICommand SellCommand { get; set; }
    }
}