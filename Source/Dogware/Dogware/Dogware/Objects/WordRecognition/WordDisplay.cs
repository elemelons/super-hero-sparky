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

        public WordDisplay(Vector2 position, string word) : base("WordDisplay", true, position, "none")
        {
            this.word = word;
        }

        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch batch)
        {
            batch.DrawString(TGame.Instance.MainFont, "Test", new Vector2(400, 500), Color.Black);
        }
    }
}
