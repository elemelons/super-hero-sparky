using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimGame;

namespace Dogware.Scenes.Minigames
{
    public static class MinigameServer
    {
        private static Random random = new Random();

        private static LevelGroup[] groups = new LevelGroup[]
        {
            new LevelGroup(new MinigameBase[]
                {
                    new TestGame(),
                    new TestGame(),
                    new TestGame()
                }),

            new LevelGroup(new MinigameBase[]
                {
                    new TestGame(),
                    new TestGame(),
                    new TestGame()
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
