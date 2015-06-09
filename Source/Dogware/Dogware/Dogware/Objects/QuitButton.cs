using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dogware.Objects
{
    class QuitButton : Button
    {
        public QuitButton(Vector2 position) : base("Quit", position, "stopbutton.png")
        {

        }

        public override void OnButtonClick()
        {
            Game1.Game1.Instance.Exit();
        }
    }
}
