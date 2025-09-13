using System.Drawing.Drawing2D;

namespace Seed
{
    /// <summary>
    /// A full rectangle element.
    /// </summary>
    public class FullRectangle : CollidableElement
    {
        Brush _brush;
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
                if (_brush != null)
                {
                    _brush?.Dispose();
                    _brush = new SolidBrush(value);
                }
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
        }

        /// <summary>
        /// Draws the full rectangle on the game window.
        /// </summary>
        public override void Draw()
        {
            if (Collider.IsColliding(this, GameLogic.IsInScreenRect))
            {
                if (_brush == null)
                {
                    _brush = new SolidBrush(_backgroundColor);
                }
                float neutralX = (float)ScaleConverter.GameToNeutral(PosX, true, true, IsSticky, false);
                float neutralY = (float)ScaleConverter.GameToNeutral(PosY, true, false, IsSticky, false);
                float neutralRotationX = (float)ScaleConverter.GameToNeutral(RotationCenterX, false, true, IsSticky, false);
                float neutralRotationY = (float)ScaleConverter.GameToNeutral(RotationCenterY, false, true, IsSticky, false);
                float neutralWidth = (float)ScaleConverter.GameToNeutral(Width, false, true, IsSticky, false);
                float neutralHeight = (float)ScaleConverter.GameToNeutral(Height, false, true, IsSticky, false);
                GraphicsState state = GameLogic.G.Save();
                GameLogic.G.TranslateTransform(neutralX + neutralRotationX, neutralY + neutralRotationY);
                GameLogic.G.RotateTransform((float)Angle);
                GameLogic.G.TranslateTransform(-(neutralX + neutralRotationX), -(neutralY + neutralRotationY));
                GameLogic.G.FillRectangle(_brush, neutralX, neutralY, neutralWidth, neutralHeight);
                GameLogic.G.Restore(state);
            }
        }

        /// <summary>
        /// Draws the full rectangle on a DrawingSection.
        /// </summary>
        /// <param name="section">The section for the full rectangle to be drawn on.</param>
        public override void DrawOnSection(DrawingSection section)
        {
            if (Collider.IsColliding(this, section) && Collider.IsColliding(this, GameLogic.IsInScreenRect))
            {
                if (_brush == null)
                {
                    _brush = new SolidBrush(_backgroundColor);
                }
                float neutralX = (float)ScaleConverter.GameToNeutral(PosX, true, true, IsSticky, false) - (float)ScaleConverter.GameToNeutral(section.PosX, true, true, section.IsSticky, false);
                float neutralY = (float)ScaleConverter.GameToNeutral(PosY, true, false, IsSticky, false) - (float)ScaleConverter.GameToNeutral(section.PosY, true, false, section.IsSticky, false);
                float neutralRotationX = (float)ScaleConverter.GameToNeutral(RotationCenterX, false, true, IsSticky, false);
                float neutralRotationY = (float)ScaleConverter.GameToNeutral(RotationCenterY, false, true, IsSticky, false);
                float neutralWidth = (float)ScaleConverter.GameToNeutral(Width, false, true, IsSticky, false);
                float neutralHeight = (float)ScaleConverter.GameToNeutral(Height, false, true, IsSticky, false);
                GraphicsState state = section.G.Save();
                section.G.TranslateTransform(neutralX + neutralRotationX, neutralY + neutralRotationY);
                section.G.RotateTransform((float)Angle);
                section.G.TranslateTransform(-(neutralX + neutralRotationX), -(neutralY + neutralRotationY));
                section.G.FillRectangle(_brush, neutralX, neutralY, neutralWidth, neutralHeight);
                section.G.Restore(state);
            }
        }
        
        /// <summary>
        /// Disposes the resources used by this full rectangle.
        /// </summary>
        public override void Dispose()
        {
            _brush.Dispose();
        }
    }
}
