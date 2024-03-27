using System;

namespace Seed
{
    /// <summary>
    /// This class represents elements which can be collision checked without having to create the collider(it checks if the elements are directly touching).
    /// </summary>
    public class CollidableElement : Element
    {
        /// <summary>
        /// The width of the element in pixels.
        /// </summary>
        public int Width;
        /// <summary>
        /// The height of the element in pixels.
        /// </summary>
        public int Height;
    }
}
