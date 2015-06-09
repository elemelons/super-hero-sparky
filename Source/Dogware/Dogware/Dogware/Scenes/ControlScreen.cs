using Dogware.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimGame;

namespace Dogware.Scenes
{
    class ControlScreen : Scene
    {
        float timer = 3;

        public ControlScreen() : base("Controls")
        {

        }

        public override void InitScene()
        {
            timer = 3;
            MakeSceneObject(new Background("besturingen.png", true));
        }

        public override void Update()
        {
            if (timer < 0)
                TGame.Instance.LoadScene(new LevelMenu());
            else
                timer -= Time.DeltaTime;
        }
    }
}
