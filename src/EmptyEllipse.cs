using System.Drawing.Drawing2D;

namespace Seed
{
    /// <summary>
    /// An empty ellipse element.
    /// </summary>
    public class EmptyEllipse : CollidableElement
    {
        /// <summary>
        /// The width of the outline of the ellipse in game units.
        /// </summary>
        public double OvalWidth;
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
        public EmptyEllipse(double posX, double posY, double height, double width, double ellipseWidth, Color color)
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
            if(Collider.IsColliding(this, GameLogic.IsInScreenRect))
            {
                double neutralX = ScaleConverter.GameToNeutral(PosX, true, true, IsSticky);
                double neutralY = ScaleConverter.GameToNeutral(PosY, true, false, IsSticky);
                double neutralRotationX = ScaleConverter.GameToNeutral(RotationCenterX, false, true, IsSticky);
                double neutralRotationY = ScaleConverter.GameToNeutral(RotationCenterY, false, true, IsSticky);
                double neutralWidth = ScaleConverter.GameToNeutral(Width, false, true, IsSticky);
                double neutralHeight = ScaleConverter.GameToNeutral(Height, false, true, IsSticky);
                GraphicsState state = GameLogic.G.Save();
                Pen pen = new Pen(Color, ScaleConverter.GameToNeutral(OvalWidth, false, false, IsSticky));
                GameLogic.G.TranslateTransform(neutralX + neutralRotationX, neutralY + neutralRotationY);
                GameLogic.G.RotateTransform((float)Angle);
                GameLogic.G.TranslateTransform(-(neutralX + neutralRotationX), -(neutralY + neutralRotationY));
                GameLogic.G.DrawEllipse(pen, neutralX, neutralY, neutralWidth, neutralHeight);
                GameLogic.G.Restore(state);
                pen.Dispose();
            }
        }
    }
}
