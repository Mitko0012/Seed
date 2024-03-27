using System;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;

namespace Seed
{
    /// <summary>
    /// The class from which each game element class derives.
    /// </summary>
    public class Element
    {
        /// <summary>
        /// The X position of the element in pixels.
        /// </summary>
        public int PosX;
        /// <summary>
        /// The Y position of the element in pixels.
        /// </summary>
        public int PosY;
        /// <summary>
        /// The X position of the center of rotation of the element in pixels. Relative to the PosX of the element. 0 by default.
        /// </summary>
        public int RotationCenterX = 0;
        /// <summary>
        /// The T position of the center of rotation of the element in pixels. Relative to the PosY of the element. 0 by default.
        /// </summary>
        public int RotationCenterY = 0;
        /// <summary>
        /// The angle of rotation of the element. 0 by default.
        /// </summary>
        public float Angle = 0f;
        /// <summary>
        /// Draws the element on the game window. 
        /// </summary>
        public virtual void Draw(){}
    }
}
