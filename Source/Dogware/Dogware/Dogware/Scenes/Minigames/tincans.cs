using Dogware.Objects;
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
        private TinCan can1;
        private TinCan can2;
        private TinCan can3;
        private TinCan can4;
        private TinCan can5;
        private bool correctCanHit = false;
        public int Answer;
        public int Kind;
        public int Option;
        private int[] incorrectAnswers;

        public enum SumType
        {
            Plus,
            Minus,
            Multiply
        }

        public struct SumData
        {
            public string sum;
            public int answer;
        }

        public TinCans() : base("Tin Cans", 6)
        {

        }

        public override void InitScene()
        {
            base.InitScene();
            CreateSum();
            CreateNumbers();
            can = (TinCan)MakeSceneObject(new TinCan(new Vector2((800 / 7 * 1), 200), (TextObject)MakeSceneObject(new TextObject()), incorrectAnswers[0]));
            can1 = (TinCan)MakeSceneObject(new TinCan(new Vector2((800 / 7 * 2), 200), (TextObject)MakeSceneObject(new TextObject()), incorrectAnswers[1]));
            can2 = (TinCan)MakeSceneObject(new TinCan(new Vector2((800 / 7 * 3), 200), (TextObject)MakeSceneObject(new TextObject()), incorrectAnswers[2]));
            can3 = (TinCan)MakeSceneObject(new TinCan(new Vector2((800 / 7 * 4), 200), (TextObject)MakeSceneObject(new TextObject()), incorrectAnswers[3]));
            can4 = (TinCan)MakeSceneObject(new TinCan(new Vector2((800 / 7 * 5), 200), (TextObject)MakeSceneObject(new TextObject()), incorrectAnswers[4]));
            can5 = (TinCan)MakeSceneObject(new TinCan(new Vector2((800 / 7 * 6), 200), (TextObject)MakeSceneObject(new TextObject()), Answer));
            baseball = (Ball)MakeSceneObject(new Ball(new Vector2(100, 450)));
        }

        public override void Update()
        {
            base.Update();

            //if(juiste blikje is geraakt)
            //{
            //    correctCanHit = true;
            //}
        }

        public override string GetObjective()
        {
            return "Raak het juiste blikje!";
        }

        public override bool HasWon()
        {
            return correctCanHit;
        }

        public SumData CreateSum()
        {
            SumData data = new SumData();
            Random rdm = new Random();
            int sort = rdm.Next(2);
            Console.WriteLine(sort);
            
            SumType type = (SumType)sort;
            int X;
            int Y;
     

            switch(type)
            {
                case SumType.Plus:
                    X = rdm.Next(1, 101);
                    Y = rdm.Next(1, 101);
                    data.sum = X + " + " + Y;
                    data.answer = X + Y;
                    Kind = 1;
                    break;

                case SumType.Minus:
                    Random rnd = new Random();
                    X = rnd.Next(1, 101);
                    Y = rnd.Next(1, 101);
                    Kind = 2;
                    if (X > Y)
                    {
                        data.sum = X + " - " + Y;
                        data.answer = X - Y;
                    }

                    else if (Y > X)
                    {
                        data.sum = Y + " - " + X;
                        data.answer =  (Y - X);
                    }

                    break;

                case SumType.Multiply:
                    X = rdm.Next(10);
                    Y = rdm.Next(10);
                    Kind = 3;
                    data.sum = X + " X " + Y;
                    data.answer = X * Y;
                break;
                }
            Answer = data.answer;
            return data;
        }

        public int[] CreateNumbers()
        {
            incorrectAnswers = new int[5];

            if (Kind == 1)
            {
                Random rnd = new Random();
                Option = rnd.Next(1);
                for (int i = 0; i < incorrectAnswers.Length; i++ )
                {
                    int addition = rnd.Next(1, 30);

                    if((rnd.Next(100) > 50) && addition < Answer)
                        addition *= -1;

                    incorrectAnswers[i] = Answer + addition;
                }
            }

            return incorrectAnswers;
        }
    }
}