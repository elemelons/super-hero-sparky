using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimGame;

namespace Dogware.Objects.tin_cans
{
    class Ball : GameObject
    {
        public Vector2 Velocity = new Vector2(12, 0);
        private bool thrown = false;

        public Ball(Vector2 position) : base("ball", false, position, "CanGame/ball.png")
        {
            DrawDepth = -10;
        }

        public override void Update()
        {
            renderer.Scale = Math.Max(((transform.Position.Y / 600f) - 0.5f) * 2.0f, 0);
            transform.Position += Velocity;

            if (transform.Position.X <= 50 || transform.Position.X >= 750)
            {
                Velocity.X *= -1;
            }

            if (thrown == false && Input.ConfirmPressed)
            {
                thrown = true;
                Velocity = new Vector2(0, -7);
            }
            
            base.Update();
        }

        public override void OnCollision(GameObject other)//ik kom tegen "other" aan
        {
            if(other.Name == "Blikje")//is de naam van het voorwerp waar ik tegenaankom "Blikje"?
            {

            }
        }
    }
}