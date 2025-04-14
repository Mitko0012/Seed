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
        public Ellipse(double posX, double posY, double width, double height, Color color)
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
            if(Collider.IsColliding(this, GameLogic.IsInScreenRect))
            {
                float neutralX = (float)ScaleConverter.GameToNeutral(PosX, true, true, IsSticky);
                float neutralY = (float)ScaleConverter.GameToNeutral(PosY, true, false, IsSticky);
                float neutralRotationX = (float)ScaleConverter.GameToNeutral(RotationCenterX, false, true, IsSticky);
                float neutralRotationY = (float)ScaleConverter.GameToNeutral(RotationCenterY, false, true, IsSticky);
                float neutralWidth = (float)ScaleConverter.GameToNeutral(Width, false, true, IsSticky);
                float neutralHeight = (float)ScaleConverter.GameToNeutral(Height, false, true, IsSticky);
                GraphicsState state = GameLogic.G.Save();
                Brush brush = new SolidBrush(BackgroundColor);
                GameLogic.G.TranslateTransform(neutralX + neutralRotationX, neutralY + neutralRotationY);
                GameLogic.G.RotateTransform((float)Angle);
                GameLogic.G.TranslateTransform(-(neutralX + neutralRotationX), -(neutralY + neutralRotationY));
                GameLogic.G.FillEllipse(brush, neutralX, neutralY, neutralWidth, neutralHeight);
                GameLogic.G.Restore(state);
                brush.Dispose();
            }
        }
    }
}
