using System.Drawing.Drawing2D;

namespace Seed
{
    /// <summary>
    /// An empty ellipse element.
    /// </summary>
    public class EmptyEllipse : CollidableElement
    {
        Pen _pen;
        double _ovalWidth;
        /// <summary>
        /// The width of the outline of the ellipse in game units.
        /// </summary>
        public double OvalWidth
        {
            get
            {
                return _ovalWidth;
            }
            set
            {
                _ovalWidth = value;
                _pen?.Dispose();
                _pen = new Pen(Color, (float)ScaleConverter.GameToNeutral(OvalWidth, false, false, IsSticky));
            }
        }
        Color _color;
        /// <summary>
        /// The color of the outline of the ellipse.
        /// </summary>
        public Color Color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
                _pen?.Dispose();
                _pen = new Pen(Color, (float)ScaleConverter.GameToNeutral(OvalWidth, false, false, IsSticky));
            }
        }
        int _widthAtLastDraw = -1;
        int _heightAtLastDraw = -1;
        double _unitsAtLastDraw;
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
            _unitsAtLastDraw = GameLogic.UnitsOnCanvas;
            _pen = new Pen(Color, (float)ScaleConverter.GameToNeutral(OvalWidth, false, false, IsSticky));
        }
        /// <summary>
        /// Draws an empty ellipse on the game window.
        /// </summary>
        public override void Draw()
        {
            if (Collider.IsColliding(this, GameLogic.IsInScreenRect))
            {
                if (GameLogic.Width != _widthAtLastDraw || GameLogic.Height != _heightAtLastDraw || _unitsAtLastDraw != GameLogic.UnitsOnCanvas)
                {
                    _pen?.Dispose();
                    _pen = new Pen(Color, (float)ScaleConverter.GameToNeutral(OvalWidth, false, false, IsSticky));
                }
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
                GameLogic.G.DrawEllipse(_pen, neutralX, neutralY, neutralWidth, neutralHeight);
                GameLogic.G.Restore(state);
                _widthAtLastDraw = GameLogic.Width;
                _heightAtLastDraw = GameLogic.Height;
                _unitsAtLastDraw = GameLogic.UnitsOnCanvas;
            }
        }

        public override void DrawOnSection(DrawingSection section)
        {
            if (Collider.IsColliding(this, section) && Collider.IsColliding(this, GameLogic.IsInScreenRect))
            {
                if (GameLogic.Width != _widthAtLastDraw || GameLogic.Height != _heightAtLastDraw || _unitsAtLastDraw != GameLogic.UnitsOnCanvas)
                {
                    _pen?.Dispose();
                    _pen = new Pen(Color, (float)ScaleConverter.GameToNeutral(OvalWidth, false, false, IsSticky));
                }
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
                section.G.DrawEllipse(_pen, neutralX, neutralY, neutralWidth, neutralHeight);
                section.G.Restore(state);
                _widthAtLastDraw = GameLogic.Width;
                _heightAtLastDraw = GameLogic.Height;
                _unitsAtLastDraw = GameLogic.UnitsOnCanvas;
            }
        }
    }
}
