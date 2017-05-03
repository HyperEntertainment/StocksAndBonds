
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

        private const int NumberAccountTypes = (int)AccountType.VallyPowerAndLight + 1;

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

        internal void UpdateMarketValue(Portfolio startingYear, int[] marketChanges, MarketEvent marketEvent)
        {
            throw new NotImplementedException();
        }
    }
}
