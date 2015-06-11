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
        private SelectionArrow arrow;
        private List<Button> buttons = new List<Button>();
        private int selectionIndex = 0;

        public MainMenu() : base("Main Menu")
        {
            
        }

        public override void InitScene()
        {
            MakeSceneObject(new Background("menuscreen.png", true));

            arrow = (SelectionArrow)MakeSceneObject(new SelectionArrow(Vector2.Zero));

            float initialY = 300;
            float addY = 120;

            buttons.Add((Button)MakeSceneObject(new PlayButton(new Vector2(400, initialY + (addY * buttons.Count)))));
            buttons.Add((Button)MakeSceneObject(new CreditButton(new Vector2(400, initialY + (addY * buttons.Count)))));
            buttons.Add((Button)MakeSceneObject(new QuitButton(new Vector2(400, initialY + (addY * buttons.Count)))));
        }

        public override void Update()
        {
            if (Input.UpPressed)
                selectionIndex--;

            if (Input.DownPressed)
                selectionIndex++;

            if (selectionIndex < 0)
                selectionIndex = buttons.Count - 1;

            if (selectionIndex >= buttons.Count)
                selectionIndex = 0;

            if (Input.ConfirmPressed)
                buttons[selectionIndex].OnButtonClick();

            arrow.transform.Position = buttons[selectionIndex].transform.Position + new Vector2(-arrow.renderer.TextureWidth, 0);
        }
    }
}
