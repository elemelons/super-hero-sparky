﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimGame;

namespace Dogware.Objects.LevelSceneObjects
{
    class PointIndicator : GameObject
    {
        Vector2 targetPos;

        public PointIndicator(Vector2 targetPosition) : base("PointIndicator", false, targetPosition + new Vector2(0, -500), "ball.png")
        {
            targetPos = targetPosition;
        }

        public override void Update()
        {
            base.Update();

            transform.Position = Vector2.Lerp(transform.Position, targetPos, 0.05f);
        }
    }
}
