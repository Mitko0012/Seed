using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Seed
{
    /// <summary>
    /// An empty rectange element.
    /// </summary>
    public class EmptyRectangle : CollidableElement
    {
        /// <summary>
        /// The color of the outline of the rectangle.
        /// </summary>
        public Color Color;
        /// <summary>
        /// The width of the outline of the rectangle.
        /// </summary>
        public float RectangleWidth;
        
        /// <summary>
        /// Creates a new instance of the EmptyRectange class.
        /// </summary>
        /// <param name="posX">Value to be set as the X position.</param>
        /// <param name="posY">Value to be set as the Y position.</param>
        /// <param name="width">Value to be set as the width.</param>
        /// <param name="height">Value to be set as the height.</param>
        /// <param name="rectangleWidth">Value to be set as the outline width</param>
        /// <param name="color">Value to be set as the color.</param>
        public EmptyRectangle(int posX, int posY, int width, int height, int rectangleWidth, Color color)
        {
            PosX = posX;
            PosY = posY;
            Width = width;
            Height = height;
            Color = color;
            RectangleWidth = rectangleWidth;
        }

        /// <summary>
        /// Draws an empty rectangle on the window.
        /// </summary>
        public override void Draw()
        {
            GraphicsState state = GameLogic.G.Save();
            Pen pen = new Pen(Color, Convert(RectangleWidth, false, false));
            GameLogic.G.TranslateTransform((float)this.PosX + (float)RotationCenterX, (float)this.PosY + (float)RotationCenterY);
            GameLogic.G.RotateTransform((float)Angle);
            GameLogic.G.TranslateTransform(-((float)this.PosX + (float)RotationCenterX), -((float)this.PosY + (float)RotationCenterY));
            GameLogic.G.DrawRectangle(pen, Convert(PosX, true, true), Convert(PosY, true, false), Convert(Width, false, true), Convert(Height, false, true));
            GameLogic.G.Restore(state);
            pen.Dispose();
        }
    }
}
