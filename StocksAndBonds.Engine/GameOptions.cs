using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hyper.StocksAndBonds.Engine
{
    public class GameOptions
    {
        public GameOptions()
        {
            this.NumberOfPlayers = 1;
            this.NumberOfYears = 10;
        }

        public int NumberOfPlayers { get; set; }

        public int NumberOfYears { get; set; }
    }
}