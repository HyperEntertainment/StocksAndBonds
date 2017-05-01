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
    public class User
    {
        public Guid Id { get; set; }
        public string DisplayName { get; set; }


        // DemoStuff...
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
    }
}