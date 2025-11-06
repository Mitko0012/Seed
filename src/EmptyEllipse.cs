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
                if (_pen != null)
                {
                    _pen?.Dispose();
                    _pen = new Pen(Color, (float)ScaleConverter.GameToNeutral(OvalWidth, false, false, IsSticky, false));
                }
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
                if (_pen != null)
                {
                    _pen?.Dispose();
                    _pen = new Pen(Color, (float)ScaleConverter.GameToNeutral(OvalWidth, false, false, IsSticky, false));
                }
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
        }
        /// <summary>
        /// Draws the empty ellipse on the game window.
        /// </summary>
        public override void Draw()
        {
            if (Collider.IsColliding(this, GameLogic.IsInScreenRect))
            {
                if (GameLogic.Width != _widthAtLastDraw || GameLogic.Height != _heightAtLastDraw || _unitsAtLastDraw != GameLogic.UnitsOnCanvas || _pen == null)
                {
                    _pen?.Dispose();
                    _pen = new Pen(Color, (float)ScaleConverter.GameToNeutral(OvalWidth, false, false, IsSticky, false));
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
                GameLogic.G.DrawEllipse(_pen, neutralX, neutralY, neutralWidth, neutralHeight);
                GameLogic.G.Restore(state);
                _widthAtLastDraw = GameLogic.Width;
                _heightAtLastDraw = GameLogic.Height;
                _unitsAtLastDraw = GameLogic.UnitsOnCanvas;
            }
        }

        /// <summary>
        /// Draws the empty ellipse on a DrawingSection.
        /// </summary>
        /// <param name="section">The section for the ellipse to be drawn on.</param>
        public override void DrawOnSection(DrawingSection section)
        {
            if (Collider.IsColliding(this, section) && Collider.IsColliding(this, GameLogic.IsInScreenRect))
            {
                if (GameLogic.Width != _widthAtLastDraw || GameLogic.Height != _heightAtLastDraw || _unitsAtLastDraw != GameLogic.UnitsOnCanvas || _pen == null)
                {
                    _pen?.Dispose();
                    _pen = new Pen(Color, (float)ScaleConverter.GameToNeutral(OvalWidth, false, false, IsSticky, false));
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
                section.G.DrawEllipse(_pen, neutralX, neutralY, neutralWidth, neutralHeight);
                section.G.Restore(state);
                _widthAtLastDraw = GameLogic.Width;
                _heightAtLastDraw = GameLogic.Height;
                _unitsAtLastDraw = GameLogic.UnitsOnCanvas;
            }
        }

        /// <summary>
        /// Disposes the resources used by this empty ellipse.
        /// </summary>
        public override void Dispose()
        {
            _pen?.Dispose();
        }
    }
}
