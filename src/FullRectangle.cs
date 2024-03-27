using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Seed
{
    /// <summary>
    /// A full rectangle element.
    /// </summary>
    public class FullRectangle : CollidableElement
    {
        /// <summary>
        /// The color of the rectangle.
        /// </summary>
        public Color BackgroundColor;
        
        /// <summary>
        /// Creates a new instance of the FullRectange class.
        /// </summary>
        /// <param name="posX">Value to be set as the X position.</param>
        /// <param name="posY">Value to be set as the Y position.</param>
        /// <param name="width">Value to be set as the width.</param>
        /// <param name="height">Value to be set as the height.</param>
        /// <param name="color">Value to be set as the background color.</param>

        public FullRectangle(int posX, int posY, int width, int height, Color color)
        {
            PosX = posX;
            PosY = posY;
            Width = width;
            Height = height;
            BackgroundColor = color;
        }

        /// <summary>
        /// Draws a full rectangle on the game window.
        /// </summary>
        public override void Draw()
        {
            GraphicsState state = GameLogic.G.Save();
            Brush brush = new SolidBrush(BackgroundColor);
            GameLogic.G.TranslateTransform(this.PosX + RotationCenterX, this.PosY + RotationCenterY);
            GameLogic.G.RotateTransform(Angle);
            GameLogic.G.TranslateTransform(-(this.PosX + RotationCenterX), -(this.PosY + RotationCenterY));
            GameLogic.G.FillRectangle(brush, PosX, PosY, Width, Height);
            GameLogic.G.Restore(state);
            brush.Dispose();
        }
    }
}
