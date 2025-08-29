using System.Drawing.Drawing2D;

namespace Seed
{
    /// <summary>
    /// A full rectangle element.
    /// </summary>
    public class FullRectangle : CollidableElement
    {
        Brush _brush = new SolidBrush(Color.Black);
        Color _backgroundColor;
        /// <summary>
        /// The color of the rectangle.
        /// </summary>
        public Color BackgroundColor
        {
            get
            {
                return _backgroundColor;
            }
            set
            {
                _backgroundColor = value;
                _brush.Dispose();
                _brush = new SolidBrush(value);
            }
        }

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
            _brush = new SolidBrush(color);
        }

        /// <summary>
        /// Draws a full rectangle on the game window.
        /// </summary>
        public override void Draw()
        {
            if (Collider.IsColliding(this, GameLogic.IsInScreenRect))
            {
                float neutralX = (float)ScaleConverter.GameToNeutral(PosX, true, true, IsSticky);
                float neutralY = (float)ScaleConverter.GameToNeutral(PosY, true, false, IsSticky);
                float neutralRotationX = (float)ScaleConverter.GameToNeutral(RotationCenterX, false, true, IsSticky);
                float neutralRotationY = (float)ScaleConverter.GameToNeutral(RotationCenterY, false, true, IsSticky);
                float neutralWidth = (float)ScaleConverter.GameToNeutral(Width, false, true, IsSticky);
                float neutralHeight = (float)ScaleConverter.GameToNeutral(Height, false, true, IsSticky);
                GraphicsState state = GameLogic.G.Save();
                GameLogic.G.TranslateTransform(neutralX + neutralRotationX, neutralY + neutralRotationY);
                GameLogic.G.RotateTransform((float)Angle);
                GameLogic.G.TranslateTransform(-(neutralX + neutralRotationX), -(neutralY + neutralRotationY));
                GameLogic.G.FillRectangle(_brush, neutralX, neutralY, neutralWidth, neutralHeight);
                GameLogic.G.Restore(state);
            }
        }

        public override void DrawOnSection(DrawingSection section)
        {
            if (Collider.IsColliding(this, section) && Collider.IsColliding(this, GameLogic.IsInScreenRect))
            {
                float neutralX = (float)ScaleConverter.GameToNeutral(PosX, true, true, IsSticky) - (float)ScaleConverter.GameToNeutral(section.PosX, true, true, section.IsSticky);
                float neutralY = (float)ScaleConverter.GameToNeutral(PosY, true, false, IsSticky) - (float)ScaleConverter.GameToNeutral(section.PosY, true, false, section.IsSticky);
                float neutralRotationX = (float)ScaleConverter.GameToNeutral(RotationCenterX, false, true, IsSticky);
                float neutralRotationY = (float)ScaleConverter.GameToNeutral(RotationCenterY, false, true, IsSticky);
                float neutralWidth = (float)ScaleConverter.GameToNeutral(Width, false, true, IsSticky);
                float neutralHeight = (float)ScaleConverter.GameToNeutral(Height, false, true, IsSticky);
                GraphicsState state = section.G.Save();
                section.G.TranslateTransform(neutralX + neutralRotationX, neutralY + neutralRotationY);
                section.G.RotateTransform((float)Angle);
                section.G.TranslateTransform(-(neutralX + neutralRotationX), -(neutralY + neutralRotationY));
                section.G.FillRectangle(_brush, neutralX, neutralY, neutralWidth, neutralHeight);
                section.G.Restore(state);
            }
        }
    }
}
