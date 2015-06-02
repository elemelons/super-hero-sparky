using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimGame;

namespace Dogware.Scenes.Minigames
{
    public abstract class MinigameBase : Scene //asdafasdf
    {
        private float time = 0;

        public MinigameBase(string name, float time) : base(name)
        {
            this.time = time;
        }

        public override void Update()
        {
            time -= 0.01f;

            Console.WriteLine("T remaining: " + time);
        }

        public bool GameEnded()
        {
            return time < 0;
        }

        public abstract bool HasWon();
    }
}
