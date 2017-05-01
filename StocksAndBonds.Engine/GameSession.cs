using System;

namespace Hyper.StocksAndBonds.Engine
{
    public class GameSession
    {
        public GameSession(GameOptions options)
        {
            this.Id = Guid.NewGuid();
            this.Started = DateTime.UtcNow;
            this.Ended = DateTime.MaxValue;
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
    }
}