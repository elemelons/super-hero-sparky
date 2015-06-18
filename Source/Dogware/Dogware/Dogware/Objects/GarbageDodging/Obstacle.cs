using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimGame;

namespace Dogware.Objects.GarbageDodging
{
    class Obstacle : GameObject
    {
        private static System.Random random = new System.Random();
        public static bool move = true;
        private float moveSpeed = 4;

        public Obstacle(Vector2 position) : base("garbage", false, position, "Dodging/Falling cat.png")
        {
            DrawDepth = 1;
            renderer.Scale = 0.2f;
        }

        public override void Update()
        {
            base.Update();

            if(move)
                transform.Position += new Vector2(0, moveSpeed);

            if (transform.Position.Y > 700)
                transform.Position = new Vector2(random.Next(800), -100);
        }
    }
}
