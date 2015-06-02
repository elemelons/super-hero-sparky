using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimGame
{
    class Input
    {
        private static KeyboardState keyboardState = Keyboard.GetState();

        public static void UpdateState()
        {
            keyboardState = Keyboard.GetState();
        }

        public static bool KeyPressed(Keys key)
        {
            return keyboardState.IsKeyDown(key);
        }

        public static bool MouseButtonPressed()
        {
            throw new NotImplementedException();
        }

        public static Vector2 MousePosition()
        {
            throw new NotImplementedException();
        }
    }
}
