using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dogware.TimGame
{
    static class Random
    {
        private static System.Random rand = new System.Random();

        public static float Value
        {
            get
            {
                return (float)rand.NextDouble();
            }
        }

        public static float Range(float min, float max)
        {
            return min + (Value * (max - min));
        }
    }
}
