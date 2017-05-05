using System;
using System.Collections.Generic;

namespace Hyper.StocksAndBonds.Engine
{
    public class GameSession
    {
        private Random random;
        private List<MarketEvent> marketEvents;


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

        public void Initialize()
        {
            this.LoadAllMarketEvents();
            this.CalculateMarketProgression();
        }

        private void CalculateMarketProgression()
        {
            int changeIndex;
            int[] marketChanges;
            MarketEvent marketEvent;
            Portfolio previousYear = Portfolio.StartingMarket;

            for (int i = 1; i < this.Options.NumberOfYears; ++i)
            {
                // Figure out what happens to the market.
                marketEvent = GetNextMarketEvent();
                changeIndex = this.random.Next(1, 6);
                changeIndex += this.random.Next(1, 6);

                // TODO: Fix and where does it come from?
                marketChanges = null;

                Investments[i].UpdateMarketValue(previousYear, marketChanges, marketEvent);
                previousYear = Investments[i];

            }
        }
        private MarketEvent GetNextMarketEvent()
        {
            int selectedEvent = this.random.Next(0, this.marketEvents.Count);

            MarketEvent returnValue = this.marketEvents[selectedEvent];
            this.marketEvents.RemoveAt(selectedEvent);

            return returnValue;
        }

        private void LoadAllMarketEvents()
        {
            MarketEvent marketEvent;

            marketEvents = new List<MarketEvent>();

            marketEvent = new MarketEvent()
            {
                CurrentMarketTrend = MarketEvent.MarketTrend.Bull,
                Description = "President announces expansion plans to increase productive capacity by 30%.",
            };
            marketEvent.MarketSegmentChanges.Add(Portfolio.AccountType.UnitedAuto, 15);
            marketEvents.Add(marketEvent);

            marketEvent = new MarketEvent()
            {
                CurrentMarketTrend = MarketEvent.MarketTrend.Bull,
                Description = "Influx of personnel of new company in nearby town creates a severe housing shortage.",
            };
            marketEvent.MarketSegmentChanges.Add(Portfolio.AccountType.ShadyBrooks, 5);
            marketEvent.MarketSegmentChanges.Add(Portfolio.AccountType.VallyPowerAndLight, 4);
            marketEvents.Add(marketEvent);

            marketEvent = new MarketEvent()
            {
                CurrentMarketTrend = MarketEvent.MarketTrend.Bull,
                Description = "Large petroleum corporation offers to buy all assets for cash. Offer is well above book value. Directors approve and will submite recommendation to stockholders.",
            };
            marketEvent.MarketSegmentChanges.Add(Portfolio.AccountType.StrykerDrilling, 17);
            marketEvents.Add(marketEvent);

            marketEvent = new MarketEvent()
            {
                CurrentMarketTrend = MarketEvent.MarketTrend.Bull,
                Description = "Company prospectors find huge, new high-grade ore deposits.",
            };
            marketEvent.MarketSegmentChanges.Add(Portfolio.AccountType.UraniumEnterprises, 10);
            marketEvents.Add(marketEvent);

            marketEvent = new MarketEvent()
            {
                CurrentMarketTrend = MarketEvent.MarketTrend.Bull,
                Description = "War scare promotes mixed activity on Wall Street.",
            };
            marketEvent.MarketSegmentChanges.Add(Portfolio.AccountType.PioneerMutual, -8);
            marketEvent.MarketSegmentChanges.Add(Portfolio.AccountType.StrykerDrilling, 8);
            marketEvent.MarketSegmentChanges.Add(Portfolio.AccountType.UraniumEnterprises, 5);
            marketEvents.Add(marketEvent);

            marketEvent = new MarketEvent()
            {
                CurrentMarketTrend = MarketEvent.MarketTrend.Bull,
                Description = "==Growth==",
            };
            marketEvent.MarketSegmentChanges.Add(Portfolio.AccountType.MetroProperties, 7);
            marketEvent.MarketSegmentChanges.Add(Portfolio.AccountType.PioneerMutual, 8);
            marketEvent.MarketSegmentChanges.Add(Portfolio.AccountType.ShadyBrooks, 5);
            marketEvents.Add(marketEvent);

            marketEvent = new MarketEvent()
            {
                CurrentMarketTrend = MarketEvent.MarketTrend.Bear,
                Description = "Extra year-end dividend of $2 per share devlared by the Board of Directors.",
            };
            marketEvent.MarketSegmentChanges.Add(Portfolio.AccountType.GrowthCorporation, 10);
            // TODO: How to handle dividends...
            marketEvents.Add(marketEvent);

            marketEvent = new MarketEvent()
            {
                CurrentMarketTrend = MarketEvent.MarketTrend.Bear,
                Description = "President hospitalized in sanitorium for an indefinite period.",
            };
            marketEvent.MarketSegmentChanges.Add(Portfolio.AccountType.TriCityTransport, -5);
            marketEvents.Add(marketEvent);

            marketEvent = new MarketEvent()
            {
                CurrentMarketTrend = MarketEvent.MarketTrend.Bear,
                Description = "City Council considers the Company's choicest property for large industrial fair.",
            };
            marketEvent.MarketSegmentChanges.Add(Portfolio.AccountType.MetroProperties, 10);
            marketEvents.Add(marketEvent);

            marketEvent = new MarketEvent()
            {
                CurrentMarketTrend = MarketEvent.MarketTrend.Bear,
                Description = "Government suddenly announces it ill no longer support ore prices, since it has large stockpiles.",
            };
            marketEvent.MarketSegmentChanges.Add(Portfolio.AccountType.UraniumEnterprises, -25);
            marketEvents.Add(marketEvent);

            marketEvent = new MarketEvent()
            {
                CurrentMarketTrend = MarketEvent.MarketTrend.Bear,
                Description = "==Recall==",
            };
            marketEvent.MarketSegmentChanges.Add(Portfolio.AccountType.UnitedAuto, -15);
            marketEvents.Add(marketEvent);

            marketEvent = new MarketEvent()
            {
                CurrentMarketTrend = MarketEvent.MarketTrend.Bear,
                Description = "==Market Tensions==",
            };
            marketEvent.MarketSegmentChanges.Add(Portfolio.AccountType.GrowthCorporation, -10);
            marketEvents.Add(marketEvent);
        }
    }
}