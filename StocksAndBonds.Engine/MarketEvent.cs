using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyper.StocksAndBonds.Engine
{
    public class MarketEvent
    {
        public enum MarketTrend
        {
            Bear,
            Bull
        }
        public MarketEvent()
        {
            this.MarketSegmentChanges = new Dictionary<Portfolio.AccountType, int>();
        }

        public MarketTrend CurrentMarketTrend { get; set; }

        public string Description { get; set; }

        public Dictionary<Portfolio.AccountType, int> MarketSegmentChanges { get; private set; }
    }
}
