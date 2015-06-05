using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimGame;

namespace Dogware.Objects.tin_cans
{
    class TinCan : GameObject
    {
        public Vector2 Velocity = new Vector2(0, 0);
        private float timer = 1;
        public bool Hit;

        public TinCan(Vector2 position) : base("can", false, position, "CanGame/tincan.jpg")
        {
            renderer.Scale = 0.20f;
        }

        public override void Update()
        {
            if(Hit)
            {
                timer -= 3f / 60f;

                if(timer < 0)
                {
                    Destroy();
                }
            }
           
            base.Update();
        }

        public override void OnCollision(GameObject other)//ik kom tegen "other" aan
        {
            if(other.Name == "ball")//is de naam van het voorwerp waar ik tegenaankom "Blikje"?
            {
                Hit = true;
            }
        }
    }
}