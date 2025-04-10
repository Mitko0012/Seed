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

        public FullRectangle(double posX, double posY, double width, double height, Color color)
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
            if(Collider.IsColliding(this, GameLogic.IsInScreenRect))
            {
                double neutralX = ScaleConverter.GameToNeutral(PosX, true, true, IsSticky);
                double neutralY = ScaleConverter.GameToNeutral(PosY, true, false, IsSticky);
                double neutralRotationX = ScaleConverter.GameToNeutral(RotationCenterX, false, true, IsSticky);
                double neutralRotationY = ScaleConverter.GameToNeutral(RotationCenterY, false, true, IsSticky);
                double neutralWidth = ScaleConverter.GameToNeutral(Width, false, true, IsSticky);
                double neutralHeight = ScaleConverter.GameToNeutral(Height, false, true, IsSticky);
                GraphicsState state = GameLogic.G.Save();
                Brush brush = new SolidBrush(BackgroundColor);
                GameLogic.G.TranslateTransform(neutralX + neutralRotationX, neutralY + neutralRotationY);
                GameLogic.G.RotateTransform((float)Angle);
                GameLogic.G.TranslateTransform(-(neutralX + neutralRotationX), -(neutralY + neutralRotationY));
                GameLogic.G.FillRectangle(brush, neutralX, neutralY, neutralWidth, neutralHeight);
                GameLogic.G.Restore(state);
                brush.Dispose();
            }
        }
    }
}
