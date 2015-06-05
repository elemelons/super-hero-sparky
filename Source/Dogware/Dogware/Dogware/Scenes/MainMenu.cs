using Dogware.Objects;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimGame;

namespace Dogware.Scenes
{
    class MainMenu : Scene
    {
        private List<Button> buttons = new List<Button>();
        private SelectionArrow arrow;
        private int selectionIndex = 0;
        private WalkingDog dog;

        public static int CurrentLevel = 0;

        private Vector2[] levelOrbPositions = new Vector2[]
        {
            new Vector2(200, 500),
            new Vector2(600, 400),
            new Vector2(300, 250)
        };

        public MainMenu() : base("Main Menu")
        {

        }

        public override void Update()
        {
            if(Input.KeyPressed(Microsoft.Xna.Framework.Input.Keys.Up))
            {
                selectionIndex++;

                if (selectionIndex >= buttons.Count)
                    selectionIndex = buttons.Count - 1;
            }

            if (Input.KeyPressed(Microsoft.Xna.Framework.Input.Keys.Down))
            {
                selectionIndex--;

                if (selectionIndex < 0)
                    selectionIndex = 0;
            }

            arrow.transform.Position = new Vector2(buttons[selectionIndex].transform.Position.X - 32, buttons[selectionIndex].transform.Position.Y);
            dog.MoveTo(buttons[selectionIndex].transform.Position);

            if (Input.KeyPressed(Microsoft.Xna.Framework.Input.Keys.Enter))
                buttons[selectionIndex].OnButtonClick();
        }

        public override void InitScene()
        {
            arrow = (SelectionArrow)MakeSceneObject(new SelectionArrow(new Vector2(10, 50)));

            dog = (WalkingDog)MakeSceneObject(new WalkingDog(levelOrbPositions[0]));

            buttons.Add((Button)MakeSceneObject(new PlayButton(0, levelOrbPositions[0])));
            buttons.Add((Button)MakeSceneObject(new PlayButton(1, levelOrbPositions[1])));
            buttons.Add((Button)MakeSceneObject(new PlayButton(2, levelOrbPositions[2])));

            buttons.Add((Button)MakeSceneObject(new QuitButton(new Vector2(50, 200))));
        }
    }
}
