﻿using Dogware;
using Dogware.Scenes;
using Microsoft.Xna.Framework;
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

        public static string[] SpriteNames = new string[]
        {
            "ball.png",
            "tinyBall.png",
            "SelectionArrow.png"
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
