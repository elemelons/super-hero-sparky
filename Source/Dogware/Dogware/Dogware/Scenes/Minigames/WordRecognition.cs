using Dogware.Objects;
using Dogware.Objects.WordRecognition;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimGame;

namespace Dogware.Scenes.Minigames
{
    class WordRecognition : MinigameBase
    {
        private bool hasSelected = false;
        private bool hasWon;
        private string CorrectAnswer;
        System.Random random = new System.Random();
        private ImageBlock[] blocks;
        WordDisplay display;

        private int selectionIndex = 0;

        private SelectionArrow arrow;

        private int[] amountsPerLevel = new int[] { 2, 3, 5 };

        private ImagePair[] pairs = new ImagePair[]
        {
            new ImagePair("Vleermuis", "WordRecognition/bat.jpg"),
            new ImagePair("Kat", "WordRecognition/cat.jpg"),
            new ImagePair("Hond", "WordRecognition/dog.jpg"),
            new ImagePair("Vlieg", "WordRecognition/fly.jpg"),
            new ImagePair("Kikker", "WordRecognition/frog.jpg"),
            new ImagePair("Aap", "WordRecognition/monkey.jpg"),
            new ImagePair("Muis", "WordRecognition/mouse.jpg"),
            new ImagePair("Ridder", "WordRecognition/solaire.jpg"),
            new ImagePair("Spin", "WordRecognition/spider.jpg")
        };

        private class ImagePair
        {
            public string name;
            public string imageName;

            public ImagePair(string name, string imageName)
            {
                this.name = name;
                this.imageName = imageName;
            }
        }

        public WordRecognition() : base("WordRecognition", 3)
        {
            
        }

        public override void InitScene()
        {
            base.InitScene();

            hasWon = false;
            hasSelected = false;

            arrow = (SelectionArrow)MakeSceneObject(new SelectionArrow(Vector2.One * -50));
            arrow.transform.Rotation = MathHelper.ToRadians(-90);

            blocks = new ImageBlock[amountsPerLevel[LevelMenu.CurrentLevel]];

            selectionIndex = (int)Math.Floor((float)amountsPerLevel[LevelMenu.CurrentLevel] / 2);

            int[] numbers = new int[amountsPerLevel[LevelMenu.CurrentLevel]];

            for (int i = 0; i < numbers.Length; i++)
                numbers[i] = -1;

            for (int i = 0; i < numbers.Length; i++)
            {
                bool accepted = false;

                while(!accepted)
                {
                    numbers[i] = random.Next(pairs.Length);

                    accepted = true;

                    for(int e = 0; e < numbers.Length; e++)
                    {
                        if (numbers[e] == numbers[i] && e != i)
                            accepted = false;
                    }
                }
            }

            CorrectAnswer = pairs[numbers[random.Next(numbers.Length)]].name;


            for (int i = 0; i < numbers.Length; i++)
                blocks[i] = (ImageBlock)MakeSceneObject(new ImageBlock(new Vector2(400 + ((-105 * (float)(numbers.Length / 2) + 105 * i)), 300), pairs[numbers[i]].imageName, pairs[numbers[i]].name));

            display = (WordDisplay)MakeSceneObject(new WordDisplay(new Vector2(400, 500), "Lots of Words!"));
            display.word = CorrectAnswer;
        }

        public override void Update()
        {
            base.Update();

            if (Input.LeftPressed && !hasSelected)
                selectionIndex--;

            if (Input.RightPressed && !hasSelected)
                selectionIndex++;

            selectionIndex = Math.Min(Math.Max(selectionIndex, 0), blocks.Length - 1);

            if(Input.ConfirmPressed && !hasSelected)
            {
                hasSelected = true;
                hasWon = blocks[selectionIndex].Word.Equals(CorrectAnswer);
            }

            arrow.transform.Position = blocks[selectionIndex].transform.Position + new Vector2(0, 90);
        }

        public override string GetObjective()
        {
            return "Kies het juiste plaatje!";
        }

        public override bool HasWon()
        {
            return hasWon;
        }
    }
}
