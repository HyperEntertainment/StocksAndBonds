using System;

namespace Hyper.StocksAndBonds.Engine
{
    public class GameSession
    {
        private Random random;

        public GameSession(GameOptions options)
        {
            this.Id = Guid.NewGuid();
            this.Started = DateTime.UtcNow;
            this.Ended = DateTime.MaxValue;
            this.random = new Random();

            this.Options = options;
            this.Investments = new Portfolio[options.NumberOfYears + 1];
        }

        public Guid Id { get; private set; }

        public DateTime Started { get; private set; }

        public DateTime Ended { get; private set; }

        public bool HasEnded
        {
            get
            {
                return DateTime.UtcNow > this.Ended;
            }
        }

        public Portfolio[] Investments { get; set; }

        public GameOptions Options { get; internal set; }

        public void CalculateMarketProgression()
        {
            int changeIndex;
            int[] marketChanges;
            MarketEvent marketEvent;
            Portfolio previousYear = Portfolio.StartingMarket;

            for (int i = 1; i < this.Options.NumberOfYears; ++i)
            {
                // Figure out what happens to the market.
                marketEvent = null;
                changeIndex = this.random.Next(1, 6);
                changeIndex += this.random.Next(1, 6);

                // TODO: Fix and where does it come from?
                marketChanges = null;

                Investments[i].UpdateMarketValue(previousYear, marketChanges, marketEvent);
                previousYear = Investments[i];

            }
        }
    }
}