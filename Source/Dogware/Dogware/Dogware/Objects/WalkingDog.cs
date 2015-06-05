using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimGame;

namespace Dogware.Objects
{
    class WalkingDog : GameObject
    {
        private Vector2 targetPosition;

        public WalkingDog(Vector2 levelOnePosition) : base("Dog", true, new Vector2(400, 700), "tinyBall.png")
        {
            targetPosition = levelOnePosition;
        }

        public void MoveTo(Vector2 pos)
        {
            targetPosition = pos;
        }

        public override void Update()
        {
            base.Update();

            transform.Forward = targetPosition - transform.Position;
            transform.Position += transform.Forward * Math.Min(3, (Vector2.Distance(transform.Position, targetPosition) - 50));
        }
    }
}
