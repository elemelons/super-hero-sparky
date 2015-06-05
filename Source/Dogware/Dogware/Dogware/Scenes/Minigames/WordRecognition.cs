using Dogware.Objects.WordRecognition;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dogware.Scenes.Minigames
{
    class WordRecognition : MinigameBase
    {
        private bool hasSelected = false;
        private bool hasWon;

        private int[] amountsPerLevel = new int[] { 2, 3, 5 };

        private ImagePair[] pairs = new ImagePair[]
        {
            new ImagePair("Vleermuis", "WordRecognition/bat.jpg"),
            new ImagePair("Insect", "WordRecognition/bug.jpg"),
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

            MakeSceneObject(new WordDisplay(Vector2.Zero, ""));
        }

        public override void Update()
        {
            base.Update();
        }

        public override bool HasWon()
        {
            return hasWon;
        }
    }
}
