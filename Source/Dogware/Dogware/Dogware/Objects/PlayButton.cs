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
        public PlayButton(Vector2 position) : base("Play", position, "ball.png")
        {

        }

        public override void OnButtonClick()
        {
            TGame.Instance.LoadScene(new LevelScene(0));
        }
    }
}
