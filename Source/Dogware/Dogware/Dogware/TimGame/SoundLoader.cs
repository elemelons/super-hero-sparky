using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimGame
{
    class SoundLoader
    {
        public struct SoundNameCombo
        {
            public string name;
            public SoundEffect sound;
        }

        private string folder = "";
        public static SoundLoader Instance { get; private set; }

        private Game1.Game1 baseGame;
        public List<SoundNameCombo> LoadedSounds = new List<SoundNameCombo>();

        public SoundLoader(Game1.Game1 baseGame, string path = "Sound\\")
        {
            this.baseGame = baseGame;
            Instance = this;

            folder = path;
        }

        public void PlaySound(string name)
        {
            SoundEffect sound = LoadedSounds.Find(o => o.name == name).sound;

            sound.Play();
        }

        public void Load(string name)
        {
            SoundEffect sound = baseGame.LoadSound(folder + name);

            if (LoadedSounds == null)
                LoadedSounds = new List<SoundNameCombo>();

            SoundNameCombo namedTexture = new SoundNameCombo();

            namedTexture.name = name;
            namedTexture.sound = sound;

            LoadedSounds.Add(namedTexture);
        }
    }
}
