using Dogware.Objects;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimGame;

namespace Dogware.Scenes.Minigames
{
    public abstract class MinigameBase : Scene
    {
        protected float time = 0;
        protected float initialTime = 0;

        public float TimeRemainingAsPercentage
        {
            get
            {
                return time / initialTime;
            }
        }

        public MinigameBase(string name, float time) : base(name)
        {
            this.time = time;
            initialTime = time;
        }

        public override void InitScene()
        {
            time = initialTime;

            MakeSceneObject(new Background("MinigameFrame.png")).DrawDepth = -1000;
            MakeSceneObject(new Background("MinigameFrameBackground.png")).DrawDepth = -1000;

            GameObject obj = MakeSceneObject(new TextObject(new Vector2(400, 30), GetObjective(), 0.5f));
            obj.DrawDepth = 5;
        }

        public override void Update()
        {
            time -= 0.01f;
        }

        public void ReduceTime()
        {
            if (time > 1f)
                time = 1f;
        }

        public bool GameEnded()
        {
            return time < 0;
        }

        public virtual bool GameCompleted()
        {
            return HasWon();
        }

        public abstract string GetObjective();
        public abstract bool HasWon();
    }
}
