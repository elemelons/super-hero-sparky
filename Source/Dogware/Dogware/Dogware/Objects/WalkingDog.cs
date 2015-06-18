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

        public WalkingDog(Vector2 levelOnePosition) : base("Dog", true, new Vector2(400, 700), "Dodging/Dog.png")
        {
            targetPosition = levelOnePosition;
            renderer.Scale = 0.3f;
            DrawDepth = -5;
        }

        public void MoveTo(Vector2 pos)
        {
            targetPosition = pos;
        }

        public override void Update()
        {
            base.Update();

            Vector2 trgt = (targetPosition - transform.Position);
            trgt.Normalize();

            transform.Forward = Vector2.Lerp(transform.Forward, trgt, 0.1f);
            transform.Position += transform.Forward * Math.Min(3, (Vector2.Distance(transform.Position, targetPosition) - 100));
        }
    }
}
