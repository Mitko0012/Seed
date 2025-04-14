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
        
        /// <summary>
        /// True if the element should be sticky(independent on the camera positionm), false if not.
        /// </summary>
        public bool IsSticky = false;
        /// <summary>
        /// Draws the element on the game window. 
        /// </summary>
        public virtual void Draw(){}
    }
}
