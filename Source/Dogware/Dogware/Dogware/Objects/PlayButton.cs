﻿using Dogware.Scenes;
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
        public PlayButton(Vector2 position) : base("PlayButton", position, "playbutton.png")
        {
            //SoundLoader.Instance.PlaySound("win");
        }

        public override void OnButtonClick()
        {
            TimGame.TGame.Instance.LoadScene(new ControlScreen());
        }
    }
}
