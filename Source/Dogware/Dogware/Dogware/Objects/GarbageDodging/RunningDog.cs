using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimGame;

namespace Dogware.Objects.GarbageDodging
{
    class RunningDog : GameObject
    {
        public bool HitGarbage = false;
        private float hSpeed = 2;

        public RunningDog() : base("Dog", false, new Vector2(400, 500), "tinyBall.png")
        {

        }

        public override void Update()
        {
            base.Update();

            if (Input.RightHeld || transform.Position.X < 50)
            {
                if(!HitGarbage)
                    transform.Position += new Vector2(hSpeed, 0);
            }

            if (Input.LeftHeld || transform.Position.X > 750)
            {
                if (!HitGarbage)
                    transform.Position -= new Vector2(hSpeed, 0);
            }
        }

        public override void OnCollision(GameObject other)
        {
            base.OnCollision(other);

            if (other is Obstacle)
            {
                HitGarbage = true;
                Obstacle.move = false;
            }
        }
    }
}
