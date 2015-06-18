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

        public TinCan(Vector2 position, TextObject obj, int value) : base("can", false, position, "CanGame/Blikje.png")
        {
            text = obj;
            obj.transform.LocalPosition = Vector2.Zero;
            obj.Parent = this;
            obj.Scale = 0.5f;
            renderer.Scale = 0.4f;
            Value = value;

            obj.Text = value.ToString();
            obj.DrawDepth = -1;
        }

        public override void Update()
        {
            if(Hit)
            {
                timer -= 3f / 60f;

                if(timer < 0)
                {
                    transform.Position += new Vector2(0, -3);
                    renderer.Scale -= 0.006f;

                    transform.Rotation += 0.1f;

                    if (renderer.Scale < 0)
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