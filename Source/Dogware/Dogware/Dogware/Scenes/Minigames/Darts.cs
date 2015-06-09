using Dogware.Objects;
using Dogware.Objects.DartsObjects;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dogware.Scenes.Minigames
{
    class Darts : MinigameBase
    {
        public float xAim = 400;
        private Random random = new Random();
        public List<int> hitValues;
        private TargetData currentScenario;
        private TextObject currTotal;
        private TextObject thrownTotal;

        private List<Arrow> arrows = new List<Arrow>();

        private TargetData[] scenarios = new TargetData[]
        {
            new TargetData(5, 5, 0, new int[]{1, 2, 2, 4, 3}),
            new TargetData(6, 4, 0, new int[]{2, 2, 1, 5, 4, 2}),
            new TargetData(5, 10, 0, new int[]{2, 2, 3, 3, 6}),

            new TargetData(5, 20, 1, new int[]{5, 10, 5, 2, 8}),
            new TargetData(7, 15, 1, new int[]{2, 5, 3, 4, 5, 2, 3}),
            new TargetData(10, 30, 1, new int[]{15, 15, 10, 20, 25, 5, 1, 4, 7, 9}),

            new TargetData(10, 50, 2, new int[]{20, 10, 10, 5, 5, 20, 8, 4, 3, 2}),
            new TargetData(10, 100, 2, new int[]{40, 20, 10, 20, 10, 5, 5, 3, 9, 6}),
            new TargetData(10, 80, 2, new int[]{40, 30, 10, 5, 5, 8, 4, 5, 2, 3})
        };

        public Darts() : base("Darts", 7)
        {
        }

        public override bool HasWon()
        {
            int total = 0;

            foreach(int val in hitValues)
                total += val;

            bool won = total == currentScenario.totalSum;

            return won;
        }

        public override void InitScene()
        {
            base.InitScene();

            xAim = 400;
            hitValues = new List<int>();
            scenarios = scenarios.OrderBy(o => (o.targets / o.targets) * random.Next(100)).ToArray();

            TargetData data = scenarios.First(o => o.difficulty == LevelMenu.CurrentLevel);
            currentScenario = data;

            data.targetValues = data.targetValues.OrderBy(o => TimGame.Random.Value).ToArray();

            arrows = new List<Arrow>();

            arrows.Add((Arrow)MakeSceneObject(new Arrow(new Vector2(xAim, 700), this)));
            
            for(int i = 0; i < data.targets; i++)
            {
                float xP = 400 + ((-70 * (data.targets * 0.5f)) + 70 * i);
                MakeSceneObject(new Target(new Vector2(xP, 100), (TextObject)MakeSceneObject(new TextObject()), data.targetValues[i]));
            }

            thrownTotal = (TextObject)MakeSceneObject(new TextObject(new Vector2(400, 300), data.totalSum.ToString()));
            thrownTotal.DrawDepth = 5;
            currTotal = (TextObject)MakeSceneObject(new TextObject());
            currTotal.transform.Position = new Vector2(400, 500);
            currTotal.Scale = 0.5f;
        }

        public override void Update()
        {
            base.Update();

            if (!HasWon())
            {
                arrows.RemoveAll(o => o.Fired);

                if (arrows.Count > 0)
                    arrows[0].Selected = true;
                else
                {
                    arrows.Add((Arrow)MakeSceneObject(new Arrow(new Vector2(xAim, 700), this)));
                
                    arrows[0].Selected = true;
                }
            }

            string currSum = "";

            for(int i = 0; i < hitValues.Count; i++)
            {
                currSum += hitValues[i].ToString();
                
                if (i < hitValues.Count - 1)
                    currSum += " + ";
            }

            int total = 0;

            foreach (int val in hitValues)
                total += val;

            thrownTotal.Text = currentScenario.totalSum.ToString();

            currSum += " = " + total.ToString();

            currTotal.Text = currSum;
                
        }

        public override string GetObjective()
        {
            return "Raak borden om het goede getal te maken!";
        }

        private class TargetData
        {
            public int targets, difficulty, totalSum;
            public int[] targetValues;

            public TargetData(int amountOfTargets, int totalSum, int difficulty, int[] targetValues)
            {
                targets = amountOfTargets;
                this.difficulty = difficulty;
                this.totalSum = totalSum;
                this.targetValues = targetValues;
            }
        }
    }
}
