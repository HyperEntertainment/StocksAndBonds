using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hyper.StocksAndBonds.Engine;

namespace StocksAndBonds.Console
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


        }
    }
}
