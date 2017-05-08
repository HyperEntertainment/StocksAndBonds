
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyper.StocksAndBonds.Engine
{
    public class Portfolio
    {
        public enum AccountType
        {
            Cash,
            CityBonds,
            GrowthCorporation,
            MetroProperties,
            PioneerMutual,
            ShadyBrooks,
            StrykerDrilling,
            TriCityTransport,
            UnitedAuto,
            UraniumEnterprises,
            VallyPowerAndLight,
        }

        public const int NumberAccountTypes = (int)AccountType.VallyPowerAndLight + 1;

        private int[] ammounts;

        public static Portfolio StartingMarket
        {
            get
            {
                Portfolio startingMarket = new Portfolio();
                for (int i = 1; i < Portfolio.NumberAccountTypes; ++i)
                {
                    startingMarket.ammounts[i] = 100;
                }

                startingMarket.ammounts[(int)AccountType.Cash] = 1;
                return startingMarket;
            }
        }

        public Portfolio()
        {
            ammounts = new int[NumberAccountTypes];
        }

        public int GetValueOfAccount(AccountType account)
        {
            int value = (int)account;

            if (value < 0 || value >= Portfolio.NumberAccountTypes)
            {
                throw new ArgumentOutOfRangeException();
            }

            return ammounts[value];
        }

        internal void UpdateMarketValue(Portfolio startingYear, int[] marketChanges, MarketEvent marketEvent)
        {
            for (int i = 1; i < Portfolio.NumberAccountTypes; ++i)
            {
                this.ammounts[i] = startingYear.ammounts[i] + marketChanges[i];
            }

            foreach (KeyValuePair<AccountType, int> change in marketEvent.MarketSegmentChanges)
            {
                this.ammounts[(int)change.Key] += change.Value;
            }
        }
    }
}
