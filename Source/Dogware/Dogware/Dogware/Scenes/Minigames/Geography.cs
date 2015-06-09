using Dogware.Objects.GeographyObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dogware.Scenes.Minigames
{
    class Geography : MinigameBase
    {
        private class AreaData
        {
            public string imageName;
            public string correct, incorrect1, incorrect2;

            public AreaData(string imageName, string c1, string i1, string i2)
            {
                this.imageName = imageName;
                correct = c1;
                incorrect1 = i1;
                incorrect2 = i2;
            }
        }

        private AreaData[][] levels = new AreaData[][]
        {
            new AreaData[]//Provincies Nederland
            {
                new AreaData("zuidholland.png", "Zuid-Holland", "Flevoland", "Noord-Holland"),
                new AreaData("friesland.png", "Friesland", "Groningen", "Flevoland"),
                new AreaData("overijssel.png", "Overijssel", "Drenthe", "Limburg"),
                new AreaData("limburg.png", "Limburg", "Noord-Brabant", "Utrecht")
            },

            new AreaData[]//West Europa landen
            {
                new AreaData("frankrijk.png", "Frankrijk", "Duitsland", "Oostenrijk"),
                new AreaData("belgie.png", "Belgie", "Duitsland", "Luxemburg"),
                new AreaData("luxemburg.png", "Luxemburg", "Zwitserland", "Belgie"),
                new AreaData("duitsland.png", "Duitsland", "Belgie", "Zwitserland")
            },

            new AreaData[]//Continenten
            {
                new AreaData("azie.png", "Azie", "Europa", "Afrika"),
                new AreaData("afrika.png", "Afrika", "Antartica", "Europa"),
                new AreaData("europa.png", "Europa", "Noord-Amerika", "Zuid-Amerika"),
                new AreaData("oceanie.png", "Oceanie", "Afrika", "Antartica")
            }
        };

        public bool Correct = false;

        public Geography() : base("Geography", 5)
        {

        }

        public override void InitScene()
        {
            base.InitScene();

            Correct = false;
            AreaData data = levels[MainMenu.CurrentLevel][(int)Math.Floor((double)TimGame.Random.Range(0, levels[MainMenu.CurrentLevel].Length))];

            Gebied gebied = (Gebied)MakeSceneObject(new Gebied(data.imageName, data.correct, data.incorrect1, data.incorrect2, this));
        }

        public override void Update()
        {
            base.Update();

            
        }

        public override bool HasWon()
        {
            return Correct;
        }

        public override string GetObjective()
        {
            return "Kies het goede antwoord!";
        }
    }
}
