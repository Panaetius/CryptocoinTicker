using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Windows.Documents;

using CryptocoinTicker.Contract;
using CryptocoinTicker.GUI.DisplayClasses;
using CryptocoinTicker.GUI.Modules.PointAndFigureChartModule.Views;

using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;

namespace CryptocoinTicker.GUI.Modules.PointAndFigureChartModule.ViewModels
{
    [Export(typeof(ViewModelBase))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class PointAndFigureSettingsViewModel : ViewModelBase
    {
        private decimal boxSize = -0.04m;

        public List<Tuple<string, decimal>> BoxSizes
        {
            get
            {
                return new List<Tuple<string, decimal>>
                           {
                               new Tuple<string, decimal>("2%", -0.02m),
                               new Tuple<string, decimal>("4%", -0.04m),
                               new Tuple<string, decimal>("6%", -0.06m),
                               new Tuple<string, decimal>("8%", -0.08m),
                               new Tuple<string, decimal>("10%", -0.1m),
                               new Tuple<string, decimal>("0.0625", 0.0625m),
                               new Tuple<string, decimal>("0.125", 0.125m),
                               new Tuple<string, decimal>("0.25", 0.25m),
                               new Tuple<string, decimal>("0.5", 0.5m),
                               new Tuple<string, decimal>("1", 1m),
                               new Tuple<string, decimal>("2", 2m),
                               new Tuple<string, decimal>("4", 4m),
                               new Tuple<string, decimal>("10", 10m),
                               new Tuple<string, decimal>("50", 50m),
                               new Tuple<string, decimal>("100", 100m),
                               new Tuple<string, decimal>("500", 500m),
                               new Tuple<string, decimal>("1000", 1000m)
                           };
            }
        }

        public decimal BoxSize
        {
            get
            {
                return this.boxSize;
            }
            set
            {
                this.boxSize = value;

                ((PointAndFigureChart)
                 ServiceLocator.Current.GetInstance<IRegionManager>().Regions["ChartRegion"].ActiveViews.FirstOrDefault())
                    .BoxSize = value;

                this.OnPropertyChanged("BoxSize");
            }
        }
    }
}