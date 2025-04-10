namespace Seed
{
    /// <summary>
    /// A line element.
    /// </summary>
    public class Line:Element
    {
        /// <summary>
        /// The X position of the end point of the line in game units.
        /// </summary>
        public double EndPosX;
        
        /// <summary>
        /// The Y position of the end point of the line in game units.
        /// </summary>
        public double EndPosY;
        /// <summary>
        /// The width of the line in game units.
        /// </summary>
        public double Width;
        /// <summary>
        /// The color of the line in game units.
        /// </summary>
        public Color Color;

        /// <summary>
        /// Creates a new instance of the Line class.
        /// </summary>
        /// <param name="posX">Value to be set as the X position.</param>
        /// <param name="posY">Value to be set as the Y position.</param>
        /// <param name="endPosX">Value to be set as the end X position.</param>
        /// <param name="endPosY">Value to be set as the end Y position.</param>
        /// <param name="width">Value to be set as the width of the line.</param>
        /// <param name="color">Value to be set as the color.</param>
        public Line(double posX, double posY, double endPosX, double endPosY, double width, Color color)
        {
            PosX = posX;
            PosY = posY;
            EndPosX = endPosX;
            EndPosY = endPosY;
            Width = width;
            Color = color;
        }
        /// <summary>
        /// Draws a line on the game window.
        /// </summary>
        public override void Draw()
        {
            Collider col = new Collider(0, EndPosX, 0, EndPosY, this);
            if(Collider.IsColliding(GameLogic.IsInScreenRect, col))
            {
                Pen pen = new Pen(Color, ScaleConverter.GameToNeutral(Width, false, false, IsSticky));
                GameLogic.G.DrawLine(pen, ScaleConverter.GameToNeutral(PosX, true, true, IsSticky), ScaleConverter.GameToNeutral(PosY, true, false, IsSticky), ScaleConverter.GameToNeutral(EndPosX, true, true, IsSticky), ScaleConverter.GameToNeutral(EndPosY, true, false, IsSticky));
            }
        }
    }
}
