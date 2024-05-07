using System;
using System.CodeDom;
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
        /// The X position of the element in game units.
        /// </summary>
        public double PosX;
        /// <summary>
        /// The Y position of the element in game units.
        /// </summary>
        public double PosY;
        

        public bool IsSticky = false;
        /// <summary>
        /// Draws the element on the game window. 
        /// </summary>
        public virtual void Draw(){}

        protected int Convert(double value, bool pos, bool x)
        {
            double unit = Math.Min(GameLogic.Width, GameLogic.Height) / GameLogic.UnitsOnCanvas;
            double camOffsetX = Camera.PosX * unit * -1 + (GameLogic.Width / 2);
            double camOffsetY = Camera.PosY * unit * -1 + (GameLogic.Height / 2);

            if(x)
            {
                return (int)(value * unit + (pos? IsSticky? GameLogic.Width / 2: camOffsetX : 0));
            }
            else
            {
                return (int)(value * unit + (pos? IsSticky? GameLogic.Height / 2: camOffsetY : 0));
            }
        }
    }
}
