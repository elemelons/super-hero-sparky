using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimGame
{
    class SpriteLoader
    {
        public struct TexNameCombo
        {
            public string name;
            public Texture2D sprite;
        }

        public static SpriteLoader Instance { get; private set; }

        private Game1.Game1 baseGame;
        public List<TexNameCombo> LoadedSprites = new List<TexNameCombo>();

        public SpriteLoader(Game1.Game1 baseGame)
        {
            this.baseGame = baseGame;
            Instance = this;
        }

        public Texture2D GetSprite(string name)
        {
            return LoadedSprites.Find(o => o.name == name).sprite;
        }

        public void Load(SpriteBatch batch, string name)
        {
            Texture2D sprite = baseGame.LoadTexture(name);

            if (LoadedSprites == null)
                LoadedSprites = new List<TexNameCombo>();

            TexNameCombo namedTexture = new TexNameCombo();

            namedTexture.name = name;
            namedTexture.sprite = sprite;

            LoadedSprites.Add(namedTexture);
        }
    }
}
