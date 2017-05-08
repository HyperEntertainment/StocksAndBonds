using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hyper.StocksAndBonds.Engine;

namespace StocksAndBonds
{
    class Program
    {
        static void Main(string[] args)
        {
            GameSession session = new GameSession(new GameOptions()
            {
                NumberOfPlayers = 4
            });

            session.Initialize();

            for (int year = 1; year < session.Options.NumberOfYears; ++year)
            {
                Console.WriteLine("Begining of year {0}.", year);

                Console.WriteLine("{0} Market", session.MarketEvents[year].CurrentMarketTrend);
                Console.WriteLine("{0}", session.MarketEvents[year].Description);
                foreach (KeyValuePair<Portfolio.AccountType, int> change in session.MarketEvents[year].MarketSegmentChanges)
                {
                    Console.WriteLine("  {0} {1}", change.Key, change.Value);
                }

                for (int i = 0; i < Portfolio.NumberAccountTypes; ++i)
                {
                    Portfolio.AccountType account = (Portfolio.AccountType)i;
                    Console.WriteLine("{0}: {1}", account, session.Investments[year].GetValueOfAccount(account));
                }

                foreach (Player player in session.Players)
                {
                    player.BeginningOfYear();


                    player.EndYear();
                }
            }

            Console.WriteLine("Done...");
            Console.ReadLine();
        }
    }
}
