using System.ComponentModel.Composition;
using System.Windows.Controls;

namespace CryptocoinTicker.VircurexPlugins
{
    /// <summary>
    /// Interaction logic for TradeView.xaml
    /// </summary>
    [Export]
    public partial class VircurexTradeView : UserControl
    {
        public VircurexTradeView()
        {
            this.InitializeComponent();
        }
    }
}
