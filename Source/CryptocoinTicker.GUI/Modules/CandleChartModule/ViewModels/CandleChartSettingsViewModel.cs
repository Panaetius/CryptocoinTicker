using System;
using System.Collections.Generic;
using System.Linq;

using CryptocoinTicker.GUI.DisplayClasses;
using CryptocoinTicker.GUI.Helpers;

using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;

namespace CryptocoinTicker.GUI.Modules.CandleChartModule.ViewModels
{
    public class CandleChartSettingsViewModel : ViewModelBase
    {
        private int periodSize;

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

                ((IChartView)
                 ServiceLocator.Current.GetInstance<IRegionManager>().Regions["ChartRegion"].ActiveViews.FirstOrDefault(
                     )).PeriodSize = value;

                this.OnPropertyChanged("PeriodSize");
            }
        }
    }
}