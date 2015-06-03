using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimGame;

namespace Dogware.Scenes.Minigames
{
    public abstract class MinigameBase : Scene
    {
        private float time = 0;
        private float initialTime = 0;

        public float TimeRemainingAsPercentage
        {
            get
            {
                return time / initialTime;
            }
        }

        public MinigameBase(string name, float time) : base(name)
        {
            this.time = time;
            initialTime = time;
        }

        public override void InitScene()
        {
            time = initialTime;
        }

        public override void Update()
        {
            time -= 0.01f;

            Console.WriteLine("T remaining: " + time);
        }

        public void ReduceTime()
        {
            if (time > 1f)
                time = 1f;
        }

        public bool GameEnded()
        {
            return time < 0;
        }

        public abstract bool HasWon();
    }
}
