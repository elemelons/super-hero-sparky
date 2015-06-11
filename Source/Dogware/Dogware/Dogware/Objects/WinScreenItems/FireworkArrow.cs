using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimGame;

namespace Dogware.Objects.WinScreenItems
{
    class FireworkArrow : GameObject
    {
        private Color color;
        private float maxAngle = MathHelper.ToRadians(30);
        private int minPart = 20;
        private int maxPart = 40;

        public FireworkArrow(Vector2 position, Color color) : base("firework", true, position, "none", new RendererOptions(color))
        {
            this.color = color;

            transform.Rotation = TimGame.Random.Range(-MathHelper.ToRadians(5), MathHelper.ToRadians(5));
        }

        public override void Update()
        {
            base.Update();

            transform.Rotation *= (Math.Abs(transform.Rotation) < 0.8f? 1.05f : 1.03f);
            transform.Position += transform.Forward * (0.9f - ((float)Math.Abs(transform.Rotation) / maxAngle)) * 15;

            if(Math.Abs(transform.Rotation) > maxAngle)
            {
                Destroy();
            }

            if (TimGame.Random.Value < 0.7f)
            {
                Particle part = (Particle)baseScene.MakeSceneObject(new Particle("SmokePuff.png", transform.Position, new Vector2(TimGame.Random.Range(-0.1f, 0.1f), TimGame.Random.Range(-0.1f, 0.1f)), TimGame.Random.Range(0, MathHelper.ToRadians(360)), Color.Gray, TimGame.Random.Range(-0.1f, 0.1f), 0.001f, 0.01f, 3));
                part.renderer.Scale = 0.3f;
            }
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            int amount = TimGame.Random.Range(minPart, maxPart);

            for(int i = 0; i < amount; i++)
            {
                Particle part = (Particle)baseScene.MakeSceneObject(new Particle("Flare.png", transform.Position, new Vector2(TimGame.Random.Range(-3f, 3f), TimGame.Random.Range(-3f, 1f)), TimGame.Random.Range(0, MathHelper.ToRadians(360)), color, TimGame.Random.Range(-0.1f, 0.1f), 0.03f, 0.03f, 1.5f));
                part.renderer.Scale = 0.5f;
            }
        }
    }
}
