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
        private TextObject text;
        public int Value;

        public TinCan(Vector2 position, TextObject obj, int value) : base("can", false, position, "CanGame/tincan.jpg")
        {
            text = obj;
            obj.transform.LocalPosition = Vector2.Zero;
            obj.Parent = this;
            renderer.Scale = 0.30f;
            obj.Scale = 0.5f;
            Value = value;

            obj.Text = value.ToString();
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