
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Threading.Tasks;

using CryptocoinTicker.Contract;

using CryptocoinTicker.CryptsyPlugins;

namespace CryptocoinTicker.CryptsyPlugins
{
                                [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "ADT/XPM")]
    public class CryptsyADTXPMAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("113"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("113"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "ASC/XPM")]
    public class CryptsyASCXPMAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("112"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("112"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "CENT/XPM")]
    public class CryptsyCENTXPMAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("118"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("118"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "COL/XPM")]
    public class CryptsyCOLXPMAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("110"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("110"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "IFC/XPM")]
    public class CryptsyIFCXPMAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("105"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("105"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "NET/XPM")]
    public class CryptsyNETXPMAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("104"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("104"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "TIX/XPM")]
    public class CryptsyTIXXPMAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("103"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("103"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "ADT/LTC")]
    public class CryptsyADTLTCAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("94"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("94"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "ASC/LTC")]
    public class CryptsyASCLTCAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("111"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("111"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "CENT/LTC")]
    public class CryptsyCENTLTCAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("97"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("97"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "CNC/LTC")]
    public class CryptsyCNCLTCAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("17"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("17"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "COL/LTC")]
    public class CryptsyCOLLTCAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("109"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("109"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "CPR/LTC")]
    public class CryptsyCPRLTCAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("91"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("91"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "DBL/LTC")]
    public class CryptsyDBLLTCAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("46"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("46"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "DGC/LTC")]
    public class CryptsyDGCLTCAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("96"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("96"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "DVC/LTC")]
    public class CryptsyDVCLTCAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("52"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("52"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "ELP/LTC")]
    public class CryptsyELPLTCAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("93"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("93"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "EZC/LTC")]
    public class CryptsyEZCLTCAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("55"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("55"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "FLO/LTC")]
    public class CryptsyFLOLTCAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("61"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("61"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "GLD/LTC")]
    public class CryptsyGLDLTCAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("36"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("36"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "GME/LTC")]
    public class CryptsyGMELTCAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("84"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("84"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "IFC/LTC")]
    public class CryptsyIFCLTCAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("60"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("60"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "JKC/LTC")]
    public class CryptsyJKCLTCAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("35"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("35"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "MEC/LTC")]
    public class CryptsyMECLTCAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("100"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("100"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "MEM/LTC")]
    public class CryptsyMEMLTCAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("56"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("56"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "MST/LTC")]
    public class CryptsyMSTLTCAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("62"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("62"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "NET/LTC")]
    public class CryptsyNETLTCAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("108"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("108"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "PXC/LTC")]
    public class CryptsyPXCLTCAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("101"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("101"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "RED/LTC")]
    public class CryptsyREDLTCAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("87"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("87"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "RYC/LTC")]
    public class CryptsyRYCLTCAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("37"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("37"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "SXC/LTC")]
    public class CryptsySXCLTCAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("98"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("98"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "TIX/LTC")]
    public class CryptsyTIXLTCAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("107"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("107"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "WDC/LTC")]
    public class CryptsyWDCLTCAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("21"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("21"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "XPM/LTC")]
    public class CryptsyXPMLTCAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("106"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("106"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "YAC/LTC")]
    public class CryptsyYACLTCAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("22"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("22"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "ALF/BTC")]
    public class CryptsyALFBTCAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("57"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("57"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "AMC/BTC")]
    public class CryptsyAMCBTCAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("43"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("43"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "ANC/BTC")]
    public class CryptsyANCBTCAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("66"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("66"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "ARG/BTC")]
    public class CryptsyARGBTCAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("48"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("48"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "BQC/BTC")]
    public class CryptsyBQCBTCAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("10"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("10"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "BTB/BTC")]
    public class CryptsyBTBBTCAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("23"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("23"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "BTE/BTC")]
    public class CryptsyBTEBTCAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("49"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("49"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "BTG/BTC")]
    public class CryptsyBTGBTCAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("50"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("50"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "BUK/BTC")]
    public class CryptsyBUKBTCAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("102"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("102"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "CAP/BTC")]
    public class CryptsyCAPBTCAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("53"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("53"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "CGB/BTC")]
    public class CryptsyCGBBTCAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("70"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("70"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "CLR/BTC")]
    public class CryptsyCLRBTCAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("95"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("95"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "CMC/BTC")]
    public class CryptsyCMCBTCAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("74"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("74"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "CRC/BTC")]
    public class CryptsyCRCBTCAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("58"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("58"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "CSC/BTC")]
    public class CryptsyCSCBTCAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("68"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("68"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "DGC/BTC")]
    public class CryptsyDGCBTCAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("26"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("26"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "ELC/BTC")]
    public class CryptsyELCBTCAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("12"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("12"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "EMD/BTC")]
    public class CryptsyEMDBTCAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("69"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("69"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "FRC/BTC")]
    public class CryptsyFRCBTCAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("39"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("39"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "FRK/BTC")]
    public class CryptsyFRKBTCAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("33"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("33"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "FST/BTC")]
    public class CryptsyFSTBTCAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("44"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("44"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "FTC/BTC")]
    public class CryptsyFTCBTCAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("5"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("5"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "GDC/BTC")]
    public class CryptsyGDCBTCAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("82"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("82"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "GLC/BTC")]
    public class CryptsyGLCBTCAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("76"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("76"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "GLD/BTC")]
    public class CryptsyGLDBTCAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("30"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("30"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "GLX/BTC")]
    public class CryptsyGLXBTCAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("78"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("78"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "HBN/BTC")]
    public class CryptsyHBNBTCAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("80"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("80"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "IXC/BTC")]
    public class CryptsyIXCBTCAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("38"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("38"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "KGC/BTC")]
    public class CryptsyKGCBTCAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("65"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("65"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "LKY/BTC")]
    public class CryptsyLKYBTCAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("34"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("34"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "LTC/BTC")]
    public class CryptsyLTCBTCAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("3"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("3"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "MEC/BTC")]
    public class CryptsyMECBTCAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("45"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("45"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "MNC/BTC")]
    public class CryptsyMNCBTCAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("7"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("7"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "NBL/BTC")]
    public class CryptsyNBLBTCAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("32"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("32"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "NEC/BTC")]
    public class CryptsyNECBTCAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("90"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("90"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "NMC/BTC")]
    public class CryptsyNMCBTCAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("29"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("29"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "NRB/BTC")]
    public class CryptsyNRBBTCAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("54"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("54"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "NVC/BTC")]
    public class CryptsyNVCBTCAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("13"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("13"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "PHS/BTC")]
    public class CryptsyPHSBTCAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("86"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("86"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "POINTS/BTC")]
    public class CryptsyPointsBTCAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("120"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("120"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "PPC/BTC")]
    public class CryptsyPPCBTCAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("28"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("28"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "PTS/BTC")]
    public class CryptsyPTSBTCAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("119"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("119"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "PXC/BTC")]
    public class CryptsyPXCBTCAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("31"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("31"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "PYC/BTC")]
    public class CryptsyPYCBTCAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("92"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("92"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "QRK/BTC")]
    public class CryptsyQRKBTCAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("71"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("71"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "SBC/BTC")]
    public class CryptsySBCBTCAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("51"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("51"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "SPT/BTC")]
    public class CryptsySPTBTCAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("81"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("81"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "SRC/BTC")]
    public class CryptsySRCBTCAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("88"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("88"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "TAG/BTC")]
    public class CryptsyTAGBTCAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("117"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("117"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "TEK/BTC")]
    public class CryptsyTEKBTCAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("114"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("114"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "TRC/BTC")]
    public class CryptsyTRCBTCAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("27"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("27"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "WDC/BTC")]
    public class CryptsyWDCBTCAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("14"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("14"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "XJO/BTC")]
    public class CryptsyXJOBTCAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("115"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("115"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "XPM/BTC")]
    public class CryptsyXPMBTCAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("63"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("63"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "YAC/BTC")]
    public class CryptsyYACBTCAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("11"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("11"));
        }
    }


    [Export(typeof(ITickerApi))]
    [ExportMetadata("Exchange", "Cryptsy")]
    [ExportMetadata("Pair", "ZET/BTC")]
    public class CryptsyZETBTCAPI:CryptsyAPI, ITickerApi
    {
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            return await Task.Run(() => this.GetTrades("85"));
        }

        public async Task<Depth> GetDepth()
        {
            return await Task.Run(() => this.GetDepth("85"));
        }
    }


  }