using System.ComponentModel.Composition;
using System.Windows.Controls;

namespace CryptocoinTicker.GUI.Modules.PointAndFigureChartModule.Views
{
    /// <summary>
    /// Interaction logic for PointAndFigureChartSettings.xaml
    /// </summary>
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class PointAndFigureChartSettings : UserControl
    {
        public PointAndFigureChartSettings()
        {
            InitializeComponent();
        }
    }
}
