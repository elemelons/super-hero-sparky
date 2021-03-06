﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimGame;

namespace Dogware.Objects.TestMinigame
{
    class ActivatedBall : GameObject
    {
        public bool Activated = false;

        public ActivatedBall(Vector2 position) : base("Ball", false, position, "tinyBall.png")
        {

        }

        public override void Update()
        {
            if (Input.KeyHeld(Microsoft.Xna.Framework.Input.Keys.Space))
            {
                renderer.SetTexture("ball.png");
                Activated = true;

                Console.WriteLine("Space pressed");
            }
        }
    }
}
