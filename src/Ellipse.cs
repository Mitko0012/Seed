using System;
using System.Drawing.Drawing2D;

namespace Seed
{
    /// <summary>
    /// A full ellipse element.
    /// </summary>
    public class Ellipse : CollidableElement
    {
        /// <summary>
        /// The color of the ellipse.
        /// </summary>
        public Color BackgroundColor;
        
        /// <summary>
        /// Creates a new instance of the Ellipse class.
        /// </summary>
        /// <param name="posX">Value to be set as the X position.</param>
        /// <param name="posY">Value to be set as the Y position.</param>
        /// <param name="width">Value to be set as the width.</param>
        /// <param name="height">Value to be set as the height.</param>
        /// <param name="color">Value to be set as the background color.</param>
        public Ellipse(int posX, int posY, int width, int height, Color color)
        {
            PosX = posX;
            PosY = posY;
            Width = width;
            Height = height;
            BackgroundColor = color;
        }
        /// <summary>
        /// Draws an ellipse on the game window.
        /// </summary>
        public override void Draw()
        {
            GraphicsState state = GameLogic.G.Save();
            Brush brush = new SolidBrush(BackgroundColor);
            GameLogic.G.TranslateTransform((float)this.PosX + (float)RotationCenterX, (float)this.PosY + (float)RotationCenterY);
            GameLogic.G.RotateTransform((float)Angle);
            GameLogic.G.TranslateTransform(-((float)this.PosX + (float)RotationCenterX), -((float)this.PosY + (float)RotationCenterY));
            GameLogic.G.FillEllipse(brush, Convert(PosX, true, true), Convert(PosY, true, false), Convert(Width, false, true), Convert(Height, false, true));
            GameLogic.G.Restore(state);
            brush.Dispose();
        }
    }
}
