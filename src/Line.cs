using System;

namespace Seed
{
    /// <summary>
    /// A line element.
    /// </summary>
    public class Line:Element
    {
        /// <summary>
        /// The X position of the end point of the line.
        /// </summary>
        public int EndPosX;
        
        /// <summary>
        /// The Y position of the end point of the line.
        /// </summary>
        public int EndPosY;
        /// <summary>
        /// The width of the line.
        /// </summary>
        public float Width;
        /// <summary>
        /// The color of the line.
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
        public Line(int posX, int posY, int endPosX, int endPosY, float width, Color color)
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
            Pen pen = new Pen(Color, Width);
            GameLogic.G.DrawLine(pen, Convert(PosX, true, true), Convert(PosY, true, false), Convert(PosX, true, true), Convert(PosY, true, false));
        }
    }
}
