using Dogware.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimGame;

namespace Dogware.Objects
{
    class Background : GameObject
    {
        public Background(string imgName, bool ignoreLevelColor = false) : base("background", true, new Microsoft.Xna.Framework.Vector2(400, 300), imgName)
        {
            DrawDepth = 1000;

            if (!ignoreLevelColor)
                renderer.BlendColor = MainMenu.LevelColors[MainMenu.CurrentLevel];
        }
    }
}
