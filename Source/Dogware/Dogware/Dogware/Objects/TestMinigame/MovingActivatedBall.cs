using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimGame;

namespace Dogware.Objects.TestMinigame
{
    class MovingActivatedBall : GameObject
    {
        public bool Activated = false;

        public MovingActivatedBall(Vector2 position) : base("Ball", false, position, "tinyBall.png")
        {

        }

        public override void Update()
        {
            if (Input.KeyPressed(Microsoft.Xna.Framework.Input.Keys.Space))
            {
                transform.Position += new Vector2(0, -25);
            }
        }
    }
}
