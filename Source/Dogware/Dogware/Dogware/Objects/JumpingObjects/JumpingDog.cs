using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimGame;

namespace Dogware.Objects.JumpingObjects
{
    class JumpingDog : GameObject
    {
        public bool hit = false;
        private float floorY = 0;

        private bool canJump = true;
        private float ySpeed = 0;

        public JumpingDog(Vector2 position) : base("Dog", false, position, "ball.png")
        {
            floorY = position.Y;
        }

        public override void OnCollision(GameObject other)
        {
            base.OnCollision(other);

            if(other is Obstacle)
            {
                hit = true;
                Obstacle.move = false;
            }
        }

        public override void Update()
        {
            base.Update();
            
            if(Input.ConfirmHeld && canJump)
            {
                canJump = false;
                ySpeed = -15;
            }

            if(transform.Position.Y + ySpeed > floorY)
            {
                transform.Position = new Vector2(transform.Position.X, floorY);
                canJump = true;
            }
            else
            {
                transform.Position += new Vector2(0, ySpeed);
                ySpeed += Time.DeltaTime * 40;
            }
        }
    }
}
