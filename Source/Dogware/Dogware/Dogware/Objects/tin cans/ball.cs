using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimGame;

namespace Dogware.Objects.tin_cans
{
    class ball : GameObject
    {
        private bool thrown = false;

        public ball(Vector2 position) : base("Ball", false, position, "ball.png")
        {

        }

        public override void Update()
        {
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
