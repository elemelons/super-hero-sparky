using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimGame;

namespace Dogware.Objects.tin_cans
{
    class ball : GameObject
    {
        public Vector2 Velocity = new Vector2(12, 0);
        private bool thrown = false;
        public ball(Vector2 position) : base("ball", false, position, "NewFolder1/baseball.png")
        {

        }

        public override void Update()
        {
            renderer.Scale = transform.Position.Y / 600f;
            transform.Position += Velocity;

            if (transform.Position.X <= 50 || transform.Position.X >= 750)
            {
                Velocity.X *= -1;
            }

            if (thrown == false && Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                thrown = true;
                Velocity = new Vector2(0, -4);
                
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