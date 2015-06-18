using Dogware.Scenes.Minigames;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimGame;

namespace Dogware.Objects.GeographyObjects
{
    class Gebied : GameObject
    {
        public string correctAnswer;
        public string incorrectOne, incorrectTwo;
        private Geography baseGame;

        private bool tried = false;
        private SelectionArrow arrow;
        private int selectionIndex = 0;
        private int correctAnswerIndex = 0;

        public Gebied(string imageName, string correct, string incorrect1, string incorrect2, Geography baseGame) : base("Land", true, new Microsoft.Xna.Framework.Vector2(400, 300), imageName)
        {
            renderer.SetTexture("Geography/" + imageName);
            correctAnswer = correct;
            incorrectOne = incorrect1;
            incorrectTwo = incorrect2;

            this.baseGame = baseGame;

            arrow = (SelectionArrow)baseGame.MakeSceneObject(new SelectionArrow(Vector2.Zero));

            int[] positions = new int[] { 0, 50, 100 }.OrderBy(o => TimGame.Random.Value).ToArray();

            baseGame.MakeSceneObject(new TextObject(new Vector2(400, 400 + positions[0]), correct)).renderer.Scale = 0.5f;
            baseGame.MakeSceneObject(new TextObject(new Vector2(400, 400 + positions[1]), incorrect1)).renderer.Scale = 0.5f;
            baseGame.MakeSceneObject(new TextObject(new Vector2(400, 400 + positions[2]), incorrect2)).renderer.Scale = 0.5f;

            if (positions[0] == 50)
                correctAnswerIndex = 1;

            if (positions[0] == 100)
                correctAnswerIndex = 2;
        }

        public override void Update()
        {
            base.Update();

            if (Input.DownPressed)
                selectionIndex++;

            if (Input.UpPressed)
                selectionIndex--;

            selectionIndex %= 3;

            if (selectionIndex < 0)
                selectionIndex = 2;

            if (Input.ConfirmPressed && !tried)
            {
                tried = true;

                baseGame.Correct = selectionIndex == correctAnswerIndex;
            }

            arrow.transform.Position = new Vector2(tried ? 10000 : 100, 400 + (50 * selectionIndex));
        }
    }
}
