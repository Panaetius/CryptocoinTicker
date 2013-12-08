using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using CryptocoinTicker.Contract;

namespace CryptocoinTicker.BusinessLogic
{
    public class TickerHost
    {
        [ImportMany]
        private IEnumerable<Lazy<ITickerApi, ITickerMetadata>> Tickers = null;

        public void Setup()
        {
            // Set up MEF
            var myPath = Path.GetDirectoryName(
                Assembly.GetExecutingAssembly().Location);
            var directoryCatalog = new DirectoryCatalog(myPath);

            var assemblyCatalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());

            var aggregateCatalog = new AggregateCatalog(assemblyCatalog, directoryCatalog);

            var container = new CompositionContainer(aggregateCatalog);

            // Do the Imports.
            container.SatisfyImportsOnce(this);
        }

        public Dictionary<string, List<string>> GetTickerInformation()
        {
            return this.Tickers.GroupBy(t => t.Metadata.Exchange)
                .ToDictionary(g => g.Key, g => g.Select(t => t.Metadata.Pair).ToList());
        }

        public ITickerApi GetTicker(string exchange, string pair)
        {
            return this.Tickers.First(t => t.Metadata.Exchange == exchange && t.Metadata.Pair == pair).Value;
        }
    }
}
