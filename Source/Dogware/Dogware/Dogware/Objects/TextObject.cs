using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimGame;

namespace Dogware.Objects
{
    class TextObject : GameObject
    {
        public string Text;
        public float Scale = 1f;

        public TextObject() : base("TextObject", true, Vector2.Zero, "none", new RendererOptions(Color.Black)) { }
        public TextObject(Vector2 position, string text, float scale = 1, RendererOptions options = null) : base("TextObject", true, position, "none", options == null? new RendererOptions(Color.Black) : options)
        {
            Text = text;
            Scale = scale;
        }

        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch batch)
        {
            batch.DrawString(TGame.Instance.MainFont, Text, transform.Position, renderer.BlendColor, transform.Rotation, new Vector2(((Text.Length * 24) + (Text.Length * 24)) * Scale, 24 * Scale), Scale, Microsoft.Xna.Framework.Graphics.SpriteEffects.None, 0);
        }
    }
}
