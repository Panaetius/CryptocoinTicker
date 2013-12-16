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

using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;

using CandleChart = CryptocoinTicker.GUI.Modules.CandleChartModule.Views.CandleChart;
using PointAndFigureChart = CryptocoinTicker.GUI.Modules.PointAndFigureChartModule.PointAndFigureChart;

namespace CryptocoinTicker.GUI.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private TickerHost host;

        private ITickerApi currenTickerApi;

        private CurrencyPair selectedCurrencyPair;

        private int updateInterval = 5;

        private DispatcherTimer timer = new DispatcherTimer();

        private IEnumerable<Trade> trades;

        private Depth depth;

        private string errorMessage;

        private bool showErrorMessage;

        private string windowTitle;

        public MainWindowViewModel()
        {
            this.host = new TickerHost();
            this.host.Setup();

            this.trades = new List<Trade>();
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

            if (this.ChartView != null)
            {
                await this.GetTickerData();

                this.ChartView.Clear();

                foreach (var trade in this.trades)
                {
                    this.ChartView.AddCandle(trade);
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
                this.trades = await currenTickerApi.GetTrades();

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