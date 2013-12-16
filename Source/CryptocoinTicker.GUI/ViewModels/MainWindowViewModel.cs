using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Threading;

using CryptocoinTicker.BusinessLogic;
using CryptocoinTicker.Contract;
using CryptocoinTicker.GUI.DisplayClasses;
using CryptocoinTicker.GUI.Helpers;

using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;

using CandleChart = CryptocoinTicker.GUI.Modules.CandleChartModule.Views.CandleChart;

namespace CryptocoinTicker.GUI.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private TickerHost host;

        private ITickerApi currenTickerApi;

        private CurrencyPair selectedCurrencyPair;

        private int updateInterval = 5;

        private int periodSize = 900;

        private DispatcherTimer timer = new DispatcherTimer();

        private IEnumerable<Candle> candles;

        private Depth depth;

        private string errorMessage;

        private string windowTitle;

        public MainWindowViewModel()
        {
            this.host = new TickerHost();
            this.host.Setup();

            this.candles = new List<Candle>();
            this.depth = new Depth{Asks = new List<DepthItem>(), Bids = new List<DepthItem>() };

            timer.Interval = new TimeSpan(0, 0, this.UpdateInterval);
            timer.Tick += TimerOnTick;
        }

        private async void TimerOnTick(object sender, EventArgs eventArgs)
        {
            if (this.currenTickerApi == null)
            {
                return;
            }

            this.ErrorMessage = string.Empty;

            timer.Stop();

            await this.GetTickerData();

            if (this.ChartView != null)
            {
                this.ChartView.Clear();

                this.ChartView.PeriodSize = this.PeriodSize;

                foreach (var candle in this.candles)
                {
                    this.ChartView.AddCandle(candle);
                }
                
                this.ChartView.Redraw();
            }

            if (this.DepthView != null)
            {
                this.DepthView.SetDepth(this.depth);
            }

            timer.Start();
        }

        private async Task<int> GetTickerData()
        {
            try
            {
                var trades = await currenTickerApi.GetTrades();

                var candles =
                    trades.GroupBy(t => t.Date.ToUnixTime() / this.PeriodSize)
                        .Select(
                            g =>
                            new Candle
                            {
                                Date = DateTimeHelper.DateTimeFromUnixTimestampSeconds(g.Key * this.PeriodSize),
                                Close = g.Last().Price,
                                Open = g.First().Price,
                                High = g.Max(c => c.Price),
                                Low = g.Min(c => c.Price),
                                Volume = g.Sum(c => Math.Abs(c.Amount))
                            });

                this.candles = candles;

                this.depth = await this.currenTickerApi.GetDepth();
            }
            catch (Exception ex)
            {
                this.ErrorMessage = ex.Message;
            }

            return 0;
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

                this.WindowTitle = value.ExchangeName + " - " + value.CurrencyPairName;

                currenTickerApi = host.GetTicker(value.ExchangeName, value.CurrencyPairName);

                try
                {


                    var regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();

                    var modulemanager = ServiceLocator.Current.GetInstance<IModuleManager>();
                    modulemanager.LoadModule(string.Format("{0}ApiModule", value.ExchangeName));

                    // Show Chart
                    var tradeView = new Uri(string.Format("{0}TradeView", value.ExchangeName), UriKind.Relative);
                    regionManager.RequestNavigate("TradeRegion", tradeView);

                    var tradeSettings = new Uri(string.Format("{0}TradeSettings", value.ExchangeName), UriKind.Relative);
                    regionManager.RequestNavigate("ApiSettings", tradeSettings);
                }
                catch (ModuleNotFoundException)
                {
                    //No Trade Module available for currencypair
                }

                this.TimerOnTick(null, null);

                this.OnPropertyChanged("SelectedCurrencyPair");
            }
        }

        public List<Tuple<string, int>> UpdateIntervals
        {
            get
            {
                return new List<Tuple<string, int>>
                           {
                               //new Tuple<string, int>("1 second", 1),
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

                timer.Stop();
                timer.Interval = new TimeSpan(0, 0, value);
                this.TimerOnTick(null, null);

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
                this.TimerOnTick(null, null);
                this.OnPropertyChanged("PeriodSize");
            }
        }

        public IChartView ChartView
        {
            get
            {
                return ServiceLocator.Current.GetInstance<IRegionManager>().Regions["ChartRegion"].ActiveViews.FirstOrDefault() as IChartView; 
            }
        }

        public IDepthView DepthView
        {
            get
            {
                return ServiceLocator.Current.GetInstance<IRegionManager>().Regions["ChartRegion"].ActiveViews.FirstOrDefault() as IDepthView; 
            }
        }

        public string ErrorMessage
        {
            get
            {
                return this.errorMessage;
            }
            set
            {
                this.errorMessage = value;
                this.OnPropertyChanged("ErrorMessage");
            }
        }

        public string WindowTitle
        {
            get
            {
                return "CryptocoinTicker - " + this.windowTitle;
            }
            set
            {
                this.windowTitle = value;
                this.OnPropertyChanged("WindowTitle");
            }
        }
    }
}