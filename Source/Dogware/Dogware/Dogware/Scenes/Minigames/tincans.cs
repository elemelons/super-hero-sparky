using Dogware.Objects.tin_cans;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dogware.Scenes.Minigames
{
    class TinCans : MinigameBase
    {
        private Ball baseball;
        private TinCan can;
        private bool correctCanHit = false;

        public struct SumData
        {
            public string sum;
            public string answer;
        }

        public TinCans() : base("Tin Cans", 6)
        {

        }

        public override void InitScene()
        {
            base.InitScene();
            baseball = (Ball)MakeSceneObject(new Ball(new Vector2(100, 450)));
            can = (TinCan)MakeSceneObject(new TinCan(new Vector2(100, 100)));
        }

        public override void Update()
        {
            base.Update();

            //if(juiste blikje is geraakt)
            //{
            //    correctCanHit = true;
            //}
        }

        public override bool HasWon()
        {
            return correctCanHit;
        }

        public SumData CreateSum()
        {
            SumData data = new SumData();

            data.sum = "1 + 1";
            data.answer = "2";

            return data;
        }
    }
}