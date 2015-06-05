using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1;

namespace TimGame
{
    class MonoTim
    {
        private class CollisionData
        {
            public GameObject objOne;
            public GameObject objTwo;

            public void SendCollisionMessage()
            {
                objOne.Collide(objTwo);
                objTwo.Collide(objOne);
            }
        }

        private SpriteBatch spriteBatch;
        private GraphicsDeviceManager graphics;
        private Game1.Game1 baseGame;
        private SpriteLoader spriteLoader;

        public static MonoTim Instance { get; private set; }

        private TGame game = new TGame();

        public int GameStep { get; private set; }

        public void Start(Game1.Game1 baseGame)
        {
            Instance = this;
            this.baseGame = baseGame;

            spriteLoader = new SpriteLoader(baseGame);

            GameStep = 0;

            game.Start();
        }

        public void Update()
        {
            GameStep++;

            Input.UpdateState();

            List<CollisionData> collided = new List<CollisionData>();

            foreach(GameObject toUpdate in GameObject.AllObjects)
            {
                toUpdate.UpdateObject();

                foreach (GameObject potentialCollision in GameObject.AllObjects)
                {
                    if (potentialCollision != toUpdate && toUpdate.Active && potentialCollision.Active && !toUpdate.IgnoreCollisions && !potentialCollision.IgnoreCollisions)
                    {
                        if (collided.Find(o => ((o.objOne == toUpdate && o.objTwo == potentialCollision) || (o.objOne == potentialCollision && o.objTwo == toUpdate))) == null)
                        {
                            if (toUpdate.Bounds.Intersects(potentialCollision.Bounds))
                            {
                                CollisionData newCollision = new CollisionData();

                                newCollision.objOne = toUpdate;
                                newCollision.objTwo = potentialCollision;

                                collided.Add(newCollision);
                            }
                        }
                    }
                }
            }

            foreach (CollisionData collision in collided)
                collision.SendCollisionMessage();

            GameObject.AllObjects.AddRange(GameObject.NewObjects);
            GameObject.NewObjects.RemoveAll(o => true);
            GameObject.AllObjects.RemoveAll(o => o.destroyed);

            game.Update();
        }

        public void Draw()
        {
            foreach (GameObject toUpdate in GameObject.AllObjects)
            {
                if(toUpdate.Active)
                    toUpdate.Draw(spriteBatch);
            }
        }

        public void Load(SpriteBatch batch)
        {
            spriteBatch = batch;

            TGame.Instance.MainFont = baseGame.Content.Load<SpriteFont>("FunSized");

            foreach(string toLoad in TGame.SpriteNames)
            {
                spriteLoader.Load(spriteBatch, toLoad);
            }
        }

        public void Unload()
        {
            
        }

        internal void SetGraphics(GraphicsDeviceManager graphics)
        {
            this.graphics = graphics;
        }
    }
}
