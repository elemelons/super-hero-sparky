using Dogware.Objects;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimGame;

namespace Dogware.Scenes
{
    class CreditScene : Scene
    {
        public Credit[] credits = new Credit[]
        {
            new Credit("Amber Hoogland", "Project Manager"),
            new Credit("Tim Falken", "Lead Developer"),
            new Credit("Laura van Heulen", "Lead Artist"),
            new Credit("Kalle van Lent", "Gameplay Developer")
        };

        public CreditScene() : base("Credits") { }

        public override void InitScene()
        {
            MakeSceneObject(new Background("Credits achtergrond.png", true));
            MakeSceneObject(new TextObject(new Vector2(400, 200), "Credits"));

            int pos = 300;
            int addPos = 50;

            for(int i = 0; i < credits.Length; i++)
            {
                TextObject obj = (TextObject)MakeSceneObject(new TextObject(new Vector2(400, pos + (addPos * i)), ""));
                obj.Text = credits[i].Name + " - " + credits[i].Title;
                obj.Scale = 0.5f;
            }
        }

        public override void Update()
        {
            if (Input.ConfirmPressed)
                TGame.Instance.LoadScene(new MainMenu());
        }

        public class Credit
        {
            public string Name, Title;

            public Credit(string name, string title)
            {
                Name = name;
                Title = title;
            }
        }
    }
}
