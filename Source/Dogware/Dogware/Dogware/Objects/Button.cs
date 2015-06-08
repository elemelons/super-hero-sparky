using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimGame;

namespace Dogware.Objects
{
    public abstract class Button : GameObject
    {
        public Button(string name, Vector2 position, string spriteName, RendererOptions options = null) : base(name + "button", false, position, spriteName, options)
        {

        }

        public abstract void OnButtonClick();
    }
}
