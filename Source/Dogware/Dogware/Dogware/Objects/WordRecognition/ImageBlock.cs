using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimGame;

namespace Dogware.Objects.WordRecognition
{
    class ImageBlock : GameObject
    {
        public string Word;

        public ImageBlock(Vector2 position, string imgName, string word) : base("image", true, position, imgName)
        {
            Word = word;
        }
    }
}
