using Dogware.Objects.LevelSceneObjects;
using Dogware.Scenes.Minigames;
using Microsoft.Xna.Framework;
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

        private float nextGameTimer = 3;
        private float timeBetweenGames = 3;

        private MinigameTimeIndicator timeIndicator;

        private int indicatorAmount = 0;

        public LevelScene(int currentLevel) : base("LevelScene")
        {
            this.currentLevel = currentLevel;
        }

        public override void InitScene()
        {
            timeIndicator = new MinigameTimeIndicator();
        }

        public override void Update()
        {
            if (currentGame == null)
            {
                if (nextGameTimer < 0)
                {
                    if (gamesWon >= winsNeeded)
                    {
                        TGame.Instance.LoadScene(new MainMenu());
                    }
                    else
                    {
                        currentGame = MinigameServer.GetMinigame(currentLevel);
                        TGame.Instance.LoadSceneAdditive(currentGame);

                        Console.WriteLine("Started game " + currentGame.Name);
                        countedWin = false;

                        foreach (GameObject obj in SceneObjects)
                            obj.Active = false;

                        timeIndicator.Active = true;
                        timeIndicator.gameToTrack = currentGame;

                    }
                }
                else
                {
                    nextGameTimer -= 1f / 60f;

                    foreach (GameObject obj in SceneObjects)
                        obj.Active = true;

                    timeIndicator.Active = false;

                    if(indicatorAmount < gamesWon)
                    {
                        MakeSceneObject(new PointIndicator(new Vector2(100 + 50 * indicatorAmount, 50)));

                        indicatorAmount++;
                    }
                }
            }
            else
            {
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

                    currentGame.Clean();
                    currentGame = null;
                    nextGameTimer = timeBetweenGames;
                }
            }
        }
    }
}
