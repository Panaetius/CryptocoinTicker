using System;
using System.Collections.Generic;
using System.Linq;

using CryptocoinTicker.BusinessLogic;
using CryptocoinTicker.GUI.DisplayClasses;
using CryptocoinTicker.GUI.Helpers;

namespace CryptocoinTicker.GUI.ViewModels
{
    public class MainWindowViewModel:ViewModelBase
    {
        private TickerHost host;

        public MainWindowViewModel()
        {
            this.host = new TickerHost();
            this.host.Setup();
        }

        public List<Exchange> Exchanges
        {
            get
            {
                return
                    this.host.GetTickerInformation()
                        .Select(
                            t =>
                            new Exchange
                                {
                                    Name = t.Key,
                                    Pairs = t.Value.Select(p => new CurrencyPair { Name = p }).ToList()
                                }).ToList();
            }
        }
    }
}