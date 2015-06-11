using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimGame;

namespace Dogware.Objects.WinScreenItems
{
    class Particle : GameObject
    {
        private float friction;
        private float lifeTimeStart;
        private float lifeTime;
        private float angSpeed;
        private float gravity;
        private bool fade;
        private Vector2 velocity;

        public Particle(string imageName, Vector2 position, Vector2 velocity, float rotation, Color color, float angSpeed, float gravity, float friction, float lifeTime, bool fade = true) : base("particle", true, position, imageName, new RendererOptions(color))
        {
            lifeTimeStart = lifeTime;
            this.angSpeed = angSpeed;
            this.gravity = gravity;
            this.friction = friction;
            this.lifeTime = lifeTime;
            this.fade = fade;
            this.velocity = velocity;
        }

        public override void Update()
        {
            base.Update();

            transform.Rotation += angSpeed;
            transform.Position += velocity;

            velocity *= 1 - friction;
            velocity.Y += gravity;

            lifeTime -= Time.DeltaTime;

            if(fade)
            {
                renderer.BlendColor.A = (byte)((lifeTime / lifeTimeStart) * 255);
            }

            if (lifeTime <= 0)
                Destroy();
        }
    }
}
