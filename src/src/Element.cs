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

        /// <summary>
        /// Converts a value from game units to pixels. Used for drawing the elements.
        /// </summary>
        /// <param name="value">The value to be converted.</param>
        /// <param name="pos">True if the value represents a position, false if it represents a scale.</param>
        /// <param name="x">True if the value represents a position on the X axis, false if it represents one on the Y axis.</param>
        /// <returns>The value in pixels.</returns>
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
