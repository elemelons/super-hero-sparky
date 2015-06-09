﻿using Dogware;
using Dogware.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimGame
{
    class TGame
    {
        public static TGame Instance { get; private set; }
        private Scene activeScene;

        public SpriteFont MainFont;

        public static string[] SpriteNames = new string[]
        {
            "ball.png",
            "tinyBall.png",
            "SelectionArrow.png",
            "SelectionArrow.png",
            "WordRecognition/bat.jpg",
            "WordRecognition/cat.jpg",
            "WordRecognition/dog.jpg",
            "WordRecognition/fly.jpg",
            "WordRecognition/frog.jpg",
            "WordRecognition/monkey.jpg",
            "WordRecognition/mouse.jpg",
            "WordRecognition/solaire.jpg",
            "WordRecognition/spider.jpg",
            "SelectionArrow.png",
            "CanGame/ball.png",
            "CanGame/Blikje.png",
            "CanGame/Blikjes achtergrond.png"
        };
        
        public void Start()
        {
            Instance = this;
            LoadScene(new IntroSplash());
        }

        public void Update()
        {
            if (activeScene != null)
                activeScene.Update();
        }

        public void LoadScene(Scene scene)
        {
            if (activeScene != null)
                activeScene.Clean();

            activeScene = scene;
            LoadSceneAdditive(activeScene);
        }

        public void LoadSceneAdditive(Scene scene)
        {
            scene.InitScene();
        }
    }
}
