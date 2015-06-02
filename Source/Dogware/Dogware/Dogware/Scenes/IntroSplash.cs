using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimGame;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Dogware.Objects;

namespace Dogware.Scenes
{
    class IntroSplash : Scene
    {
        private float timer = 3;

        public IntroSplash() : base("Main Menu")
        {

        }

        public override void Update()
        {
            timer -= 0.01f;

            if (timer < 0)
                TGame.Instance.LoadScene(new MainMenu());
        }

        public override void InitScene()
        {
            MakeSceneObject(new SplashLogo(new Vector2(100, 100)));
        }
    }
}
