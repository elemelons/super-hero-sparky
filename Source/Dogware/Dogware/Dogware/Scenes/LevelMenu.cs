﻿using Dogware.Objects;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimGame;

namespace Dogware.Scenes
{
    class LevelMenu : Scene
    {
        private List<Button> buttons = new List<Button>();
        private SelectionArrow arrow;
        private int selectionIndex = 1;
        private WalkingDog dog;

        private int amountOfLevels = 3;

        private static bool winShown = false;

        public static int CurrentLevel = 0;

        public static Color[] LevelColors = new Color[]
        {
            new Color(0, 150, 0),
            new Color(0, 0, 150),
            new Color(150, 0, 0)
        };

        private Vector2[] levelOrbPositions = new Vector2[]
        {
            new Vector2(260, 480),
            new Vector2(570, 430),
            new Vector2(300, 220)
        };

        public LevelMenu() : base("Main Menu")
        {
            selectionIndex = CurrentLevel + 1;
        }

        public override void Update()
        {
            if(Input.UpPressed)
            {
                selectionIndex++;

                if (selectionIndex >= buttons.Count)
                    selectionIndex = buttons.Count - 1;
            }

            if (Input.DownPressed)
            {
                selectionIndex--;

                if (selectionIndex < 0)
                    selectionIndex = 0;
            }

            arrow.transform.Position = new Vector2(buttons[selectionIndex].transform.Position.X - arrow.renderer.TextureWidth, buttons[selectionIndex].transform.Position.Y);
            dog.MoveTo(buttons[selectionIndex].transform.Position);

            if (Input.ConfirmPressed)
                buttons[selectionIndex].OnButtonClick();
        }

        public override void InitScene()
        {
            arrow = (SelectionArrow)MakeSceneObject(new SelectionArrow(new Vector2(10, 50)));

            arrow.DrawDepth = -1000;

            dog = (WalkingDog)MakeSceneObject(new WalkingDog(levelOrbPositions[0]));

            MakeSceneObject(new Background("Levels.png", true));

            buttons.Add((Button)MakeSceneObject(new QuitButton(new Vector2(400, 550))));
            buttons[0].renderer.Scale = 0.4f;

            buttons.Add((Button)MakeSceneObject(new LevelOrb(0, levelOrbPositions[0])));
            buttons.Add((Button)MakeSceneObject(new LevelOrb(1, levelOrbPositions[1])));
            buttons.Add((Button)MakeSceneObject(new LevelOrb(2, levelOrbPositions[2])));

            bool allWon = true;

            for(int i = 0; i < amountOfLevels; i++)
            {
                if(!LevelScene.LevelStatus[i])
                {
                    allWon = false;
                }
            }

            if(allWon && !winShown)
            {
                winShown = true;
                TGame.Instance.LoadScene(new GameCompleteScreen());
            }
        }
    }
}
