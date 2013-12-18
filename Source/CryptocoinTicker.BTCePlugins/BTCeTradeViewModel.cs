using System.ComponentModel.Composition;
using System.Windows.Input;

using CryptocoinTicker.Contract;
using CryptocoinTicker.Helpers;
using CryptocoinTicker.Helpers.WPF;

namespace CryptocoinTicker.BTCePlugins
{
    [Export(typeof(ViewModelBase))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class BTCeTradeViewModel:ViewModelBase, ITradeViewModel
    {
        public BTCeTradeViewModel()
        {
            this.BuyCommand = new RelayCommand(this.Buy);
            this.SellCommand = new RelayCommand(this.Sell);
        }

        private void Buy(object obj)
        {
            decimal amount;
            decimal price;

            if (!decimal.TryParse(this.BuyAmount, out amount) || !decimal.TryParse(this.BuyPrice, out price))
            {
                return;
            }

            this.ActualApi.Buy(price, amount);
        }

        private void Sell(object obj)
        {
            decimal amount;
            decimal price;

            if (!decimal.TryParse(this.SellAmount, out amount) || !decimal.TryParse(this.SellPrice, out price))
            {
                return;
            }

            this.ActualApi.Sell(price, amount);
        }

        private string buyAmount;

        private string buyPrice;

        private string sellAmount;

        private string sellPrice;
        private ITickerApi _api;

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

        public ITickerApi Api
        {
            get
            {
                return _api; 
                
            }
            set
            {
                _api = value;
                this.OnPropertyChanged("Api");
            }
        }

        protected BTCeAPI ActualApi
        {
            get { return (BTCeAPI) Api; }
        }

        public ICommand BuyCommand { get; set; }

        public ICommand SellCommand { get; set; }
    }
}