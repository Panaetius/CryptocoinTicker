using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Threading;

using CryptocoinTicker.BusinessLogic;
using CryptocoinTicker.Contract;
using CryptocoinTicker.GUI.DisplayClasses;
using CryptocoinTicker.GUI.Helpers;

namespace CryptocoinTicker.GUI.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private TickerHost host;

        private ITickerApi currenTickerApi;

        private CurrencyPair selectedCurrencyPair;

        private int updateInterval = 5;

        private int periodSize = 900;

        private IChartView chartView;

        private DispatcherTimer timer = new DispatcherTimer();

        private IDepthView depthView;

        private IEnumerable<Candle> candles;

        private Depth depth;

        private string errorMessage;

        private bool showErrorMessage;

        public MainWindowViewModel()
        {
            this.host = new TickerHost();
            this.host.Setup();

            timer.Interval = new TimeSpan(0, 0, this.UpdateInterval);
            timer.Tick += TimerOnTick;
        }

        private async void TimerOnTick(object sender, EventArgs eventArgs)
        {
            if (this.currenTickerApi == null)
            {
                return;
            }

            this.ShowErrorMessage = false;

            timer.Stop();

            this.ChartView.PeriodSize = this.PeriodSize;

            await this.GetTickerData();

            this.ChartView.Clear();

            foreach (var candle in this.candles)
            {
                this.ChartView.AddCandle(candle);
            }

            this.DepthView.SetDepth(this.depth);

            this.ChartView.Redraw();

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
                this.ShowErrorMessage = true;
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

                this.ChartView.PeriodsToDisplay = 100;

                currenTickerApi = host.GetTicker(value.ExchangeName, value.CurrencyPairName);

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
                return this.chartView;
            }
            set
            {
                this.chartView = value;
                this.OnPropertyChanged("ChartView");
            }
        }

        public IDepthView DepthView
        {
            get
            {
                return this.depthView;
            }
            set
            {
                this.depthView = value;
                this.OnPropertyChanged("DepthView");
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

        public bool ShowErrorMessage
        {
            get
            {
                return this.showErrorMessage;
            }
            set
            {
                this.showErrorMessage = value;
                this.OnPropertyChanged("ShowErrorMessage");
            }
        }
    }
}