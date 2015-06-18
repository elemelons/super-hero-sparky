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
        public Background TinBackground;
        private bool correctCanHit = false;
        public int Answer;
        public int Kind;
        public int Option;
        private int[] incorrectAnswers;
        private int canY;

        private int maxVal = 10;

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
            SumData data = CreateSum();
            CreateNumbers();
            canY = 340;

            maxVal = 10 * (10 * (LevelMenu.CurrentLevel + 1));

            List<int> positions = new int[]{2, 3, 4, 5}.ToList();
            positions = positions.OrderBy(o => TimGame.Random.Value).ToList();

            TinBackground = (Background)MakeSceneObject(new Background("CanGame/Blikjes achtergrond strech.png"));

            can = (TinCan)MakeSceneObject(new TinCan(new Vector2((800 / 7 * positions[0]), canY), (TextObject)MakeSceneObject(new TextObject()), incorrectAnswers[0]));
            can1 = (TinCan)MakeSceneObject(new TinCan(new Vector2((800 / 7 * positions[1]), canY), (TextObject)MakeSceneObject(new TextObject()), incorrectAnswers[1]));
            can2 = (TinCan)MakeSceneObject(new TinCan(new Vector2((800 / 7 * positions[2]), canY), (TextObject)MakeSceneObject(new TextObject()), incorrectAnswers[2]));
            can3 = (TinCan)MakeSceneObject(new TinCan(new Vector2((800 / 7 * positions[3]), canY), (TextObject)MakeSceneObject(new TextObject()), Answer));
            baseball = (Ball)MakeSceneObject(new Ball(new Vector2(100, 450)));

            MakeSceneObject(new TextObject(new Vector2(400, 125), data.sum));

            correctCanHit = false;
        }

        public override void Update()
        {
            base.Update();

            if (can3.Hit)
                correctCanHit = true;
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
            Console.WriteLine(type.ToString());
            int X;
            int Y;
     
            switch(type)
            {
                case SumType.Plus:
                    X = rdm.Next(1, maxVal);
                    Y = rdm.Next(1, maxVal);
                    data.sum = X + " + " + Y;
                    data.answer = X + Y;
                    Kind = 1;
                break;

                case SumType.Minus:
                    X = rdm.Next(1, maxVal);
                    Y = rdm.Next(1, maxVal);
                    Kind = 2;

                    if (X > Y)
                    {
                        data.sum = X + " - " + Y;
                        data.answer = X - Y;
                    }
                    else
                    {
                        data.sum = Y + " - " + X;
                        data.answer = Y - X;
                    }

                break;

                case SumType.Multiply:
                    X = rdm.Next(maxVal);
                    Y = rdm.Next(maxVal);
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

            Random rnd = new Random();
            Option = rnd.Next(1);
            for (int i = 0; i < incorrectAnswers.Length; i++)
            {
                int addition = rnd.Next(1, 30);

                if ((rnd.Next(100) > 50) && addition < Answer)
                    addition *= -1;

                incorrectAnswers[i] = Answer + addition;
            }

            return incorrectAnswers;
        }
    }
}