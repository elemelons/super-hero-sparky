using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimGame
{
    public abstract class GameObject
    {
        public static List<GameObject> AllObjects { get; private set; }
        public static List<GameObject> NewObjects { get; private set; }

        public Transform transform;

        private int drawDepth = 0;

        public int DrawDepth
        {
            get
            {
                return drawDepth;
            }

            set
            {
                drawDepth = value;

                SortObjects();
            }
        }

        public static GameObject Find(string name)
        {
            return AllObjects.Find(o => o.Name == name);
        }

        public Rectangle Bounds
        {
            get
            {
                return new Rectangle((int)transform.Position.X, (int)transform.Position.Y, sprite.Width, sprite.Height);
            }
        }

        public string Name;
        public GameObject Parent = null;

        private string spriteName;
        private bool isStatic;
        private Texture2D sprite;
        protected Vector2 origin = Vector2.Zero;

        public bool destroyed = false;

        public GameObject(string name, bool isStatic, Vector2 position, string spriteName)
        {
            transform = new Transform(this);

            this.isStatic = isStatic;

            transform.Position = position;

            if (AllObjects == null)
                AllObjects = new List<GameObject>();

            if (NewObjects == null)
                NewObjects = new List<GameObject>();

            NewObjects.Add(this);

            this.sprite = SpriteLoader.Instance.GetSprite(spriteName);

            if (this.sprite != null)
                origin = new Vector2(this.sprite.Width * 0.5f, this.sprite.Height * 0.5f);

            this.spriteName = spriteName;
            this.Name = name;
        }

        public void Collide(GameObject other)
        {
            OnCollision(other);
        }

        public void Destroy()
        {
            destroyed = true;
            OnDestroy();
        }

        public void ChangeSprite(string name)
        {
            spriteName = name;
            sprite = SpriteLoader.Instance.GetSprite(spriteName);
            origin = new Vector2(this.sprite.Width * 0.5f, this.sprite.Height * 0.5f);
        }

        public virtual void Draw(SpriteBatch batch)
        {
            if (sprite != null)
            {
                batch.Draw(sprite, transform.Position, null, Color.White, transform.Rotation, origin, 1, SpriteEffects.None, 0);
            }
            else
            {
                ChangeSprite(spriteName);

                if (this.sprite != null)
                    origin = new Vector2(this.sprite.Width * 0.5f, this.sprite.Height * 0.5f);
            }
        }

        public void UpdateObject()
        {
            if (!destroyed)
            {
                transform.UpdateLocalPos();

                Update();
            }
        }

        public static void SortObjects()
        {
            AllObjects = AllObjects.OrderBy(o => o.DrawDepth).ToList();
        }

        public virtual void Update() { }
        public virtual void OnCollision(GameObject other) { }
        protected virtual void OnDestroy() { }
    }
}
