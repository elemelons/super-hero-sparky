using Dogware.Scenes.Minigames;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimGame;

namespace Dogware.Objects.LevelSceneObjects
{
    class MinigameTimeIndicator : GameObject
    {
        public MinigameBase gameToTrack;

        public MinigameTimeIndicator() : base("Timer", true, Vector2.Zero, "ball.png")
        {
            Active = false;
        }

        public override void Update()
        {
            base.Update();

            if(gameToTrack != null)
                transform.Position = new Vector2(30 +  740 * gameToTrack.TimeRemainingAsPercentage, 570);
        }
    }
}
