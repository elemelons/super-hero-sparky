using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimGame;

namespace Dogware.Objects.TestMinigame
{
    class TargetBall : GameObject
    {
        MovingActivatedBall movingBall;

        private float speed = -15;
        private float gravity = 1;
        public bool gravityToggled = false;

        public TargetBall(Vector2 pos, MovingActivatedBall movingBall) : base("targetBall", false, pos, "ball.png")
        {

        }

        public override void OnCollision(GameObject other)
        {
            base.OnCollision(other);

            if (other.Name == "Ball")
                gravityToggled = true;
        }

        public override void Update()
        {
            base.Update();

            if(gravityToggled)
            {
                transform.Position += new Vector2(0, speed);
                speed += gravity;
            }
        }
    }
}
