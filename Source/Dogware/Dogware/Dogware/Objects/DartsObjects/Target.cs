using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimGame;

namespace Dogware.Objects.DartsObjects
{
    class Target : GameObject
    {
        public int Value = 0;
        private bool hit = false;

        private float gravity = 0.5f;
        private float ySpeed = 0;
        private float rotSpeed = 0;

        private bool spawned = false;

        public Target(Vector2 pos, TextObject textObject, int value) : base("Target", false, pos, "Darts/dartbord.png")
        {
            Value = value;
            textObject.Text = value.ToString();
            textObject.Parent = this;
            textObject.transform.LocalPosition = new Vector2(0, 0);
            textObject.Scale = 0.5f;

            renderer.Scale = 0.5f;
            textObject.DrawDepth = -1;
        }

        public override void Update()
        {
            base.Update();

            if(!spawned && baseScene != null)
            {
                spawned = true;

                Background obj = (Background)baseScene.MakeSceneObject(new Background("Darts/BoardFrame.png", true));
                obj.transform.Position = transform.Position + new Vector2(0, -30);
                obj.renderer.Scale = 0.5f;
            }

            if(hit)
            {
                ySpeed += gravity;

                transform.Position += new Vector2(0, ySpeed); 

                rotSpeed *= 1.01f;

                transform.Rotation += rotSpeed;
            }
        }

        public void Attach(Arrow arrow)
        {
            ySpeed = -5;
            arrow.Parent = this;
            arrow.transform.LocalPosition = arrow.transform.Position - transform.Position;
            hit = true;
            IgnoreCollisions = true;
            rotSpeed = (-0.5f + TimGame.Random.Value) * 0.1f;
        }
    }
}