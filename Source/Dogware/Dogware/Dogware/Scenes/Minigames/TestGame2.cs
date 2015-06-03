using Dogware.Objects.TestMinigame;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dogware.Scenes.Minigames
{
    class TestGame2 : MinigameBase
    {
        private MovingActivatedBall ball;
        private TargetBall target;

        public override void InitScene()
        {
            base.InitScene();
            ball = (MovingActivatedBall)MakeSceneObject(new MovingActivatedBall(new Vector2(400, 500)));
            target = (TargetBall)MakeSceneObject(new TargetBall(new Vector2(400, 100), ball));
        }

        public TestGame2() : base("Testgame", 2)
        {

        }

        public override bool HasWon()
        {
            return target.gravityToggled;
        }
    }
}
