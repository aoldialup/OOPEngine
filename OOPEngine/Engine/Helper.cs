using SFML.Graphics;
using SFML.System;
using System;

namespace OOPEngine
{
    class Helper
    {
        private static readonly Random random = new Random();

        public static int GetRandom(int min, int max)
        {
            // Return a random number 
            return random.Next(min, max);
        }

        public static bool IsMouseOverRectangle(RectangleShape r)
        {
            Vector2f mousePos = Input.mousePosition;

            Vector2f buttonPos = r.Position;
            Vector2f buttonPosFull = new Vector2f(r.Position.X + r.GetGlobalBounds().Width, r.Position.Y + r.GetGlobalBounds().Height);

            if (mousePos.X < buttonPosFull.X &&
                mousePos.X > buttonPos.X &&
                mousePos.Y < buttonPosFull.Y &&
                mousePos.Y > buttonPos.Y)
            {
                return true;
            }

            return false;
        }

        public static int EnumLength<T>()
        {
            // return the length of the enum
            return Enum.GetNames(typeof(T)).Length;
        }
    }
}

