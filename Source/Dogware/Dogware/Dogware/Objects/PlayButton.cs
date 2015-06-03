using Dogware.Scenes;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimGame;

namespace Dogware.Objects
{
    class PlayButton : Button
    {
        private int levelToStart = 0;

        public PlayButton(int level, Vector2 position) : base("Play", position, "ball.png")
        {
            levelToStart = level;
        }

        public override void OnButtonClick()
        {
            TGame.Instance.LoadScene(new LevelScene(levelToStart));
        }
    }
}
