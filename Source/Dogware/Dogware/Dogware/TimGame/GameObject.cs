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
        public class RendererOptions
        {
            public int cols, rows, index;
            public Color color;

            public RendererOptions(Color color, int cols = 1, int rows = 1, int startIndex = 0)
            {
                this.color = color;
                this.cols = cols;
                this.rows = rows;
                index = startIndex;
            }
        }

        public static List<GameObject> AllObjects { get; private set; }
        public static List<GameObject> NewObjects { get; private set; }

        public bool Active = true;

        public Transform transform;
        public Renderer renderer;

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
                return new Rectangle((int)transform.Position.X, (int)transform.Position.Y, (int)renderer.TextureWidth, (int)renderer.TextureHeight);
            }
        }

        public string Name;
        public GameObject Parent = null;

        private string spriteName;
        public bool IgnoreCollisions;

        public bool destroyed = false;

        public GameObject(string name, bool ignoreCollisions, Vector2 position, string spriteName, RendererOptions rendererOptions = null)
        {
            transform = new Transform(this);
            renderer = new Renderer(this);

            int cols = 1;
            int rows = 1;
            int index = 0;

            if (rendererOptions != null)
            {
                renderer.BlendColor = rendererOptions.color;
                cols = rendererOptions.cols;
                rows = rendererOptions.rows;
                index = rendererOptions.index;
            }

            renderer.SetTexture(spriteName, cols, rows);
            renderer.ImageIndex = index;

            this.IgnoreCollisions = ignoreCollisions;

            transform.Position = position;

            if (AllObjects == null)
                AllObjects = new List<GameObject>();

            if (NewObjects == null)
                NewObjects = new List<GameObject>();

            NewObjects.Add(this);

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

            List<GameObject> children = GameObject.AllObjects.FindAll(o => o.Parent == this);

            foreach (GameObject child in children)
                child.Destroy();
        }

        public virtual void Draw(SpriteBatch batch)
        {
            if(Active)
                renderer.Draw(batch);
        }

        public void UpdateObject()
        {
            if (!destroyed && Active)
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
