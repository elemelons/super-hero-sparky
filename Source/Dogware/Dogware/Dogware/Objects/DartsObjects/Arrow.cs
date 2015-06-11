using Dogware.Scenes.Minigames;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimGame;

namespace Dogware.Objects.DartsObjects
{
    class Arrow : GameObject
    {
        public bool Selected = false;
        public bool Fired = false;
        private bool hit = false;
        private Darts baseGame;

        public Arrow(Vector2 position, Darts game) : base("Arrow", false, position, "Darts/arrow.png")
        {
            baseGame = game;
            transform.Rotation += MathHelper.ToRadians(90);
        }

        public override void Update()
        {
            base.Update();

            if (!hit && !baseGame.HasWon())
            {
                if(Selected)
                {
                    if (Input.LeftHeld)
                        baseGame.xAim -= 3;

                    if (Input.RightHeld)
                        baseGame.xAim += 3;
                }

                if (Selected && Input.ConfirmPressed)
                {
                    Fired = true;
                    Selected = false;
                }

                if (Selected && !Fired)
                {
                    transform.Position = Vector2.Lerp(transform.Position, new Vector2(baseGame.xAim, 450), 0.1f);
                }

                if (Selected || Fired)
                {
                    transform.Rotation += (MathHelper.ToRadians(0) - transform.Rotation) * 0.1f;
                }

                if (Fired)
                {
                    transform.Position += new Vector2(0, -10);
                }
            }
        }

        public override void OnCollision(GameObject other)
        {
            base.OnCollision(other);

            if(other is Target && !hit && transform.Position.X < other.Bounds.X + other.Bounds.Width && transform.Position.X > other.Bounds.X)
            {
                hit = true;
                ((Target)other).Attach(this);
                baseGame.hitValues.Add(((Target)other).Value);
                IgnoreCollisions = true;
            }
        }
    }
}
