using Dogware.Objects.GarbageDodging;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dogware.Scenes.Minigames
{
    class GarbageDodging : MinigameBase
    {
        private static Random random = new Random();
        private RunningDog dog;

        public GarbageDodging() : base("GarbageDodging", 10)
        {

        }

        public override void InitScene()
        {
            base.InitScene();

            dog = (RunningDog)MakeSceneObject(new RunningDog());

            for (int i = 0; i < 3 * (LevelMenu.CurrentLevel + 1); i++ )
                MakeSceneObject(new Obstacle(new Vector2(random.Next(800), -300 + random.Next(400))));

            Obstacle.move = true;
            initialTime = 3 + 2 * LevelMenu.CurrentLevel;
            time = initialTime;
        }

        public override bool HasWon()//test
        {
            return !dog.HitGarbage;
        }

        public override string GetObjective()
        {
            return "Ontwijk!";
        }

        public override bool GameCompleted()
        {
            return !HasWon();
        }
    }
}
