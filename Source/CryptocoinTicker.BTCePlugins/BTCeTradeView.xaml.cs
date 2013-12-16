using System.ComponentModel.Composition;
using System.Windows.Controls;

namespace CryptocoinTicker.BTCePlugins
{
    /// <summary>
    /// Interaction logic for TradeView.xaml
    /// </summary>
    [Export]
    public partial class BTCeTradeView : UserControl
    {
        public BTCeTradeView()
        {
            InitializeComponent();
        }
    }
}
