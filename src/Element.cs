using System;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;

namespace Seed
{
    /// <summary>
    /// The class from which each game element class derives.
    /// </summary>
    public abstract class Element
    {
        /// <summary>
        /// The X position of the element in pixels.
        /// </summary>
        public double PosX;
        /// <summary>
        /// The Y position of the element in pixels.
        /// </summary>
        public double PosY;
        /// <summary>
        /// The X position of the center of rotation of the element in pixels. Relative to the PosX of the element. 0 by default.
        /// </summary>
        public double RotationCenterX = 0;
        /// <summary>
        /// The T position of the center of rotation of the element in pixels. Relative to the PosY of the element. 0 by default.
        /// </summary>
        public double RotationCenterY = 0;
        /// <summary>
        /// The angle of rotation of the element. 0 by default.
        /// </summary>
        public double Angle = 0f;
        /// <summary>
        /// Draws the element on the game window. 
        /// </summary>
        public virtual void Draw(){}

        public static int Convert(double value, bool pos, bool x)
        {
            double unit = Math.Min(GameLogic.Width, GameLogic.Height) / GameLogic.UnitsOnCanvas;
            double camOffsetX = Camera.PosX * unit * -1 + (GameLogic.Width / 2);
            double camOffsetY = Camera.PosY * unit * -1 + (GameLogic.Height / 2);

            if(x)
            {
                return (int)(value * unit + (pos? camOffsetX : 0));
            }
            else
            {
                return (int)(value * unit + (pos? camOffsetY : 0));
            }
        }
    }
}
