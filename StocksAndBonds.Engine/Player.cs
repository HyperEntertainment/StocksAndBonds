//------------------------------------------------------------------------------
// <copyright file="User.cs" company="Hyper Entertainment">
//     Copyright (c) Hyper Entertainment. All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hyper.StocksAndBonds.Engine
{
    public class Player
    {
        public Guid Id { get; set; }

        public string DisplayName { get; set; }

        public Portfolio[] Investments { get; private set; }

        public GameSession Session { get; private set; }

        public Player(GameSession session)
        {
            this.Session = session;
            this.Investments = new Portfolio[session.Options.NumberOfYears + 1];
        }

        public void BeginningOfYear()
        {
            // TODO: Earn dividends...
        }

        public void EndYear()
        {
            // TODO: something...
        }
    }
}