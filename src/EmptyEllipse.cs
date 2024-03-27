using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Seed
{
    /// <summary>
    /// An empty ellipse element.
    /// </summary>
    public class EmptyEllipse : CollidableElement
    {
        /// <summary>
        /// The width of the outline of the ellipse.
        /// </summary>
        public float OvalWidth;
        /// <summary>
        /// The color of the outline of the ellipse.
        /// </summary>
        public Color Color;
        /// <summary>
        /// Creates a new instance of the EmptyEllipse class.
        /// </summary>
        /// <param name="posX">Value to be set as the X position.</param>
        /// <param name="posY">Value to be set as the Y position.</param>
        /// <param name="width">Value to be set as the width.</param>
        /// <param name="height">Value to be set as the height.</param>
        /// <param name="ellipseWidth">Value to be set as the outline width</param>
        /// <param name="color">Value to be set as the color.</param>
        public EmptyEllipse(int posX, int posY, int height, int width, float ellipseWidth, Color color)
        {
            PosX = posX;
            PosY = posY;
            Width = width;
            Height = height;
            Color = color;
            OvalWidth = ellipseWidth;
        }
        /// <summary>
        /// Draws an empty ellipse on the game window.
        /// </summary>
        public override void Draw()
        {
            GraphicsState state = GameLogic.G.Save();
            Pen pen = new Pen(Color, OvalWidth);
            GameLogic.G.TranslateTransform(this.PosX + RotationCenterX, this.PosY + RotationCenterY);
            GameLogic.G.RotateTransform(Angle);
            GameLogic.G.TranslateTransform(-(this.PosX + RotationCenterX), -(this.PosY + RotationCenterY));
            GameLogic.G.DrawEllipse(pen, PosX, PosY, Width, Height);
            GameLogic.G.Restore(state);
            pen.Dispose();
        }
    }
}
