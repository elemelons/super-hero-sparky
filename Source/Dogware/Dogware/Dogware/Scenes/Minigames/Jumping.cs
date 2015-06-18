using Dogware.Objects.JumpingObjects;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimGame;

namespace Dogware.Scenes.Minigames
{
    class Jumping : MinigameBase
    {
        private JumpingDog dog;

        public Jumping() : base("Jumping", 3)
        {

        }

        public override void InitScene()
        {
            base.InitScene();

            dog = (JumpingDog)MakeSceneObject(new JumpingDog(new Vector2(100, 400)));
            Obstacle.move = true;

            for(int i = 0; i < 5 + 5 * LevelMenu.CurrentLevel; i++)
            {
                MakeSceneObject(new Obstacle(400, 5));
            }
        }

        public override void Update()
        {
            base.Update();
        }

        public override bool GameCompleted()
        {
            return dog.hit;
        }

        public override bool HasWon()
        {
            return !dog.hit;
        }

        public override string GetObjective()
        {
            return "Spring over de obstakels!";
        }
    }
}
