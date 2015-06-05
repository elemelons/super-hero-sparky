using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimGame;

namespace Dogware.Objects.WordRecognition
{
    class WordDisplay : GameObject
    {
        private string word;
        private float scale = 0.5f;

        public WordDisplay(Vector2 position, string word) : base("WordDisplay", true, position, "none")
        {
            this.word = word;
        }

        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch batch)
        {
            batch.DrawString(TGame.Instance.MainFont, word, transform.Position, Color.Black, transform.Rotation, new Vector2(((word.Length * 24) + (word.Length * 24)) * scale, 24 * scale), scale, Microsoft.Xna.Framework.Graphics.SpriteEffects.None, 0);
        }
    }
}
