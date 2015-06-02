using Dogware.Scenes.Minigames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimGame;

namespace Dogware.Scenes
{
    class LevelScene : Scene
    {
        private int gamesWon = 0;
        private int winsNeeded = 5;
        private int currentLevel = 0;
        private MinigameBase currentGame = null;
        private bool countedWin = false;

        public LevelScene(int currentLevel) : base("LevelScene")
        {
            this.currentLevel = currentLevel;
        }

        public override void InitScene()
        {
            
        }

        public override void Update()
        {
            if (currentGame == null)
            {
                currentGame = MinigameServer.GetMinigame(currentLevel);
                TGame.Instance.LoadSceneAdditive(currentGame);

                Console.WriteLine("Started game " + currentGame.Name);
                countedWin = false;
            }

            currentGame.Update();

            if (currentGame.HasWon())
                currentGame.ReduceTime();

            if (currentGame.GameEnded())
            {
                if (currentGame.HasWon() && !countedWin)
                {
                    gamesWon++;
                    countedWin = true;
                }

                if (gamesWon >= winsNeeded)
                {
                    TGame.Instance.LoadScene(new MainMenu());
                }

                currentGame.Clean();
                currentGame = null;
            }
        }
    }
}
