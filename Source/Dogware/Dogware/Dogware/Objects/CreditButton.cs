using Dogware.Scenes;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dogware.Objects
{
    class CreditButton : Button
    {
        public CreditButton(Vector2 position) : base("CreditButton", position, "creditsbutton.png")
        {

        }

        public override void OnButtonClick()
        {
            TimGame.TGame.Instance.LoadScene(new CreditScene());
        }
    }
}
