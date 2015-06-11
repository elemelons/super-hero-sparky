using Dogware.Objects;
using Dogware.Objects.WinScreenItems;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimGame;

namespace Dogware.Scenes
{
    class GameCompleteScreen : Scene
    {
        public GameCompleteScreen() : base("winscreen"){}
        
        public Color[] colors = new Color[]
        {
            Color.Red,
            Color.Blue,
            Color.Green,
            Color.Purple,
            Color.Pink,
            Color.Yellow,
            Color.Orange,
            Color.Cyan,
            Color.Lime
        };

        public override void InitScene()
        {
            MakeSceneObject(new Background("WinAchtergrond.png", true));

            MakeSceneObject(new TextObject(new Vector2(400, 300), "Je hebt gewonnen!", 0.5f, new TimGame.GameObject.RendererOptions(Color.White)));
        }

        public override void Update()
        {
            if(TimGame.Random.Value < 0.1f)
            {
                MakeSceneObject(new FireworkArrow(new Vector2(TimGame.Random.Value > 0.5f ? 150 : 650, 650), colors[TimGame.Random.Range(0, colors.Length)]));
            }

            if (Input.ConfirmPressed)
                TGame.Instance.LoadScene(new CreditScene());
        }
    }
}