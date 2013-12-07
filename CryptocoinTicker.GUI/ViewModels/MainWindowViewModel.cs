using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

using CryptocoinTicker.BusinessLogic;
using CryptocoinTicker.Contract;
using CryptocoinTicker.GUI.DisplayClasses;
using CryptocoinTicker.GUI.Helpers;

namespace CryptocoinTicker.GUI.ViewModels
{
    public class MainWindowViewModel:ViewModelBase
    {
        private TickerHost host;

        private ITickerApi currenTickerApi;

        private CurrencyPair selectedCurrencyPair;

        private int updateInterval = 5;

        private int periodSize = 900;

        public MainWindowViewModel()
        {
            this.host = new TickerHost();
            this.host.Setup();
        }

        public List<CurrencyPair> CurrencyPairs
        {
            get
            {
                return
                    this.host.GetTickerInformation()
                        .SelectMany(
                            t => t.Value.Select(v => new CurrencyPair { ExchangeName = t.Key, CurrencyPairName = v }))
                        .ToList();
            }
        }

        public CurrencyPair SelectedCurrencyPair
        {
            get
            {
                return this.selectedCurrencyPair;
            }
            set
            {
                this.selectedCurrencyPair = value;

                currenTickerApi = host.GetTicker(value.ExchangeName, value.CurrencyPairName);

                this.OnPropertyChanged("SelectedCurrencyPair");
            }
        }

        public List<Tuple<string, int>> UpdateIntervals
        {
            get
            {
                return new List<Tuple<string, int>>
                           {
                               new Tuple<string, int>("1 second", 1),
                               new Tuple<string, int>("5 seconds", 5),
                               new Tuple<string, int>("10 seconds", 10),
                               new Tuple<string, int>("15 seconds", 15),
                               new Tuple<string, int>("30 seconds", 30),
                               new Tuple<string, int>("1 minute", 60),
                               new Tuple<string, int>("5 minutes", 300),
                           };
            }
        }

        public int UpdateInterval
        {
            get
            {
                return this.updateInterval;
            }
            set
            {
                this.updateInterval = value;
                this.OnPropertyChanged("UpdateInterval");
            }
        }

        public List<Tuple<string, int>> PeriodSizes
        {
            get
            {
                return new List<Tuple<string, int>>
                           {
                               new Tuple<string, int>("1 minute", 60),
                               new Tuple<string, int>("3 minutes", 180),
                               new Tuple<string, int>("5 minutes", 300),
                               new Tuple<string, int>("15 minutes", 900),
                               new Tuple<string, int>("30 minutes", 1800),
                               new Tuple<string, int>("1 hour", 3600),
                               new Tuple<string, int>("2 hour", 7200),
                               new Tuple<string, int>("4 hour", 14400),
                               new Tuple<string, int>("6 hour", 21600),
                               new Tuple<string, int>("12 hour", 43200),
                               new Tuple<string, int>("1 day", 86400),
                               new Tuple<string, int>("3 day", 259200),
                               new Tuple<string, int>("1 week", 604800),
                           };
            }
        }

        public int PeriodSize
        {
            get
            {
                return this.periodSize;
            }
            set
            {
                this.periodSize = value;
                this.OnPropertyChanged("PeriodSize");
            }
        }
    }
}