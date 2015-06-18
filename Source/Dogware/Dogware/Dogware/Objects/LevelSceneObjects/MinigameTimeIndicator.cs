using Dogware.Scenes;
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

        public MinigameTimeIndicator() : base("Timer", true, Vector2.Zero, "alarm clock.png")
        {
            Active = false;
            renderer.Scale = 0.17f;
        }

        public override void Update()
        {
            base.Update();

            if(gameToTrack != null)
                transform.Position = new Vector2(30 +  740 * gameToTrack.TimeRemainingAsPercentage, 570);
        }
    }
}
