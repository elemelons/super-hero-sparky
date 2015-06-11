using Dogware.Objects;
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
        private float objectiveTimer = 3;
        private float timeBetweenGames = 3;

        private MinigameTimeIndicator timeIndicator;

        private TextObject startGameTimer;
        private TextObject objectiveText;
        private Background bgr;

        private bool playing = false;

        private int indicatorAmount = 0;

        public static bool[] LevelStatus = new bool[100];

        public LevelScene(int currentLevel) : base("LevelScene")
        {
            this.currentLevel = currentLevel;
        }

        public override void InitScene()
        {
            timeIndicator = (MinigameTimeIndicator)MakeSceneObject(new MinigameTimeIndicator());

            objectiveText = (TextObject)MakeSceneObject(new TextObject(new Vector2(400, 450), "", 0.7f));
            startGameTimer = (TextObject)MakeSceneObject(new TextObject(new Vector2(400, 300), "", 2));

            objectiveText.Active = false;
            startGameTimer.Active = false;

            bgr = (Background)MakeSceneObject(new Background("superdog.png", true));
            bgr.renderer.Scale = 0.7f;

            timeIndicator.DrawDepth = -2000;
        }

        public override void Update()
        {
            if (!playing)
            {
                if (nextGameTimer < 0)
                {
                    if (gamesWon >= winsNeeded)
                    {
                        LevelStatus[currentLevel] = true;
                        TGame.Instance.LoadScene(new LevelMenu());
                    }
                    else
                    {
                        if (currentGame == null)
                            currentGame = MinigameServer.GetMinigame(currentLevel);

                        if (objectiveTimer < 0)
                        {
                            objectiveText.Active = false;
                            startGameTimer.Active = false;
                        
                            TGame.Instance.LoadSceneAdditive(currentGame);
                            playing = true;

                            Console.WriteLine("Started game " + currentGame.Name);
                            countedWin = false;

                            foreach (GameObject obj in SceneObjects)
                                obj.Active = false;

                            timeIndicator.Active = true;
                            timeIndicator.gameToTrack = currentGame;
                        }
                        else
                        {
                            bgr.Active = false;

                            objectiveTimer -= Time.DeltaTime;

                            objectiveText.Text = currentGame.GetObjective();
                            startGameTimer.Text = Math.Floor(objectiveTimer).ToString();

                            objectiveText.Active = true;
                            startGameTimer.Active = true;
                        }  
                    }
                }
                else
                {
                    objectiveTimer = 4;
                    nextGameTimer -= 1f / 60f;

                    foreach (GameObject obj in SceneObjects)
                        obj.Active = true;

                    objectiveText.Active = false;
                    startGameTimer.Active = false;

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

                if (currentGame.GameCompleted())
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
                    playing = false;
                    nextGameTimer = timeBetweenGames;
                }
            }
        }
    }
}
