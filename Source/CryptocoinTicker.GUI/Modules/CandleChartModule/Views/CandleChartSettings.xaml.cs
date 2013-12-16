using System.ComponentModel.Composition;
using System.Windows.Controls;

using CryptocoinTicker.GUI.Helpers;

namespace CryptocoinTicker.GUI.Modules.CandleChartModule.Views
{
    /// <summary>
    /// Interaction logic for CandleChartSettings.xaml
    /// </summary>
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class CandleChartSettings : UserControl
    {
        public CandleChartSettings()
        {
            InitializeComponent();
        }
    }
}
