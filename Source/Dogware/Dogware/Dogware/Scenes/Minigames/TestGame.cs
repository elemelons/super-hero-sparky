using Dogware.Objects.TestMinigame;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimGame;

namespace Dogware.Scenes.Minigames
{
    class TestGame : MinigameBase
    {
        private ActivatedBall ball;

        public override void InitScene()
        {
            base.InitScene();
            ball = (ActivatedBall)MakeSceneObject(new ActivatedBall(new Vector2(100, 200)));
        }

        public TestGame() : base("Testgame", 2)
        {

        }

        public override void Update()
        {
            base.Update();
        }

        public override string GetObjective()
        {
            return "Druk op spatie!";
        }

        public override bool HasWon()
        {
            return ball.Activated;
        }
    }
}
