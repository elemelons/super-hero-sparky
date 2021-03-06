﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimGame;

namespace Dogware.Scenes.Minigames
{
    public static class MinigameServer
    {
        private static System.Random random = new System.Random();

        private static LevelGroup[] groups = new LevelGroup[]
        {
            new LevelGroup(new MinigameBase[]
                {
                    new Darts(),
                    new TinCans(),
                    new GarbageDodging(),
                    new WordRecognition(),
                    new Geography()
                }),

            new LevelGroup(new MinigameBase[]
                {
                    new Darts(),
                    new TinCans(),
                    new GarbageDodging(),
                    new WordRecognition(),
                    new Geography()
                }),

            new LevelGroup(new MinigameBase[]
                {
                    new Darts(),
                    new TinCans(),
                    new GarbageDodging(),
                    new WordRecognition(),
                    new Geography()
                })
        };

        public static MinigameBase GetMinigame(int level)
        {
            return groups[level].GetRandomGame();
        }

        private class LevelGroup
        {
            private MinigameBase[] games;

            public LevelGroup(MinigameBase[] minigames)
            {
                games = minigames;
            }

            public MinigameBase GetRandomGame()
            {
                int index = random.Next(games.Length);
                return games[index];
            }
        }
    }
}