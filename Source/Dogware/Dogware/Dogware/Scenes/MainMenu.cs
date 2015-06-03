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

        public MainMenu() : base("Main Menu")
        {

        }

        public override void Update()
        {
            if(Input.KeyPressed(Microsoft.Xna.Framework.Input.Keys.Down))
            {
                selectionIndex++;

                if (selectionIndex >= buttons.Count)
                    selectionIndex = buttons.Count - 1;
            }

            if (Input.KeyPressed(Microsoft.Xna.Framework.Input.Keys.Up))
            {
                selectionIndex--;

                if (selectionIndex < 0)
                    selectionIndex = 0;
            }

            arrow.transform.Position = new Vector2(buttons[selectionIndex].transform.Position.X - 32, buttons[selectionIndex].transform.Position.Y);

            if (Input.KeyPressed(Microsoft.Xna.Framework.Input.Keys.Enter))
                buttons[selectionIndex].OnButtonClick();
        }

        public override void InitScene()
        {
            arrow = (SelectionArrow)MakeSceneObject(new SelectionArrow(new Vector2(10, 50)));

            buttons.Add((Button)MakeSceneObject(new PlayButton(0, new Vector2(50, 50))));
            buttons.Add((Button)MakeSceneObject(new PlayButton(1, new Vector2(50, 100))));
            buttons.Add((Button)MakeSceneObject(new PlayButton(2, new Vector2(50, 150))));

            buttons.Add((Button)MakeSceneObject(new QuitButton(new Vector2(50, 200))));
        }
    }
}
