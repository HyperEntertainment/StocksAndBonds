//------------------------------------------------------------------------------
// <copyright file="GameController.cs" company="Hyper Entertainment">
//     Copyright (c) Hyper Entertainment. All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Hyper.StocksAndBonds.Engine;

namespace Hyper.StocksAndBonds.Controllers
{
    public class GameController : ApiController
    {
        private static List<GameSession> gameSessions = new List<GameSession>()
        {
            new GameSession(new GameOptions()),
            new GameSession(new GameOptions()),
            new GameSession(new GameOptions())
        };

        public IEnumerable<GameSession> GetAllSessions()
        {
            return gameSessions;
        }

        public GameSession GetSession(Guid id)
        {
            return gameSessions.FirstOrDefault(x => x.Id == id);
        }

        public GameSession CreateSession()
        {
            GameSession session = new GameSession(new GameOptions());

            lock (gameSessions)
            {
                gameSessions.Add(session);
            }

            return session;
        }
    }
}
