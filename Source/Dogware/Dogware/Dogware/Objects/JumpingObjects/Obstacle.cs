using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimGame;

namespace Dogware.Objects.JumpingObjects
{
    class Obstacle : GameObject
    {
        private float speed = 0;
        public static bool move = true;

        public Obstacle(float ypos, float speed) : base("Obstacle", false, new Vector2(300 + TimGame.Random.Value * 800, ypos), "ball.png")
        {
            this.speed = speed;
        }

        public override void Update()
        {
            base.Update();

            if (move)
            {
                transform.Position += new Vector2(-speed, 0);

                if (transform.Position.X < -100)
                    transform.Position = new Vector2(900, transform.Position.Y);
            }
        }
    }
}
