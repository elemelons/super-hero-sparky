using Dogware.Scenes;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimGame;

namespace Dogware.Objects
{
    class LevelOrb : Button
    {
        private int levelToStart = 0;

        public LevelOrb(int level, Vector2 position) : base("Play", position, "ball.png", new RendererOptions(LevelScene.LevelStatus[level]? Color.Green : Color.Red))
        {
            levelToStart = level;
        }

        public override void OnButtonClick()
        {
            TGame.Instance.LoadScene(new LevelScene(levelToStart));
            MainMenu.CurrentLevel = levelToStart;
        }
    }
}
