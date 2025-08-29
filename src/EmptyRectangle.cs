using System.Drawing.Drawing2D;

namespace Seed
{
    /// <summary>
    /// An empty rectange element.
    /// </summary>
    public class EmptyRectangle : CollidableElement
    {
        Pen _pen;
        Color _color;
        /// <summary>
        /// The color of the outline of the rectangle.
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
                _pen = new Pen(Color, (float)ScaleConverter.GameToNeutral(RectangleWidth, false, false, IsSticky));
            }
        }
        double _rectangleWidth;
        /// <summary>
        /// The width of the outline of the rectangle in game units.
        /// </summary>
        public double RectangleWidth
        {
            get
            {
                return _rectangleWidth;
            }
            set
            {
                _rectangleWidth = value;
                _pen?.Dispose();
                _pen = new Pen(Color, (float)ScaleConverter.GameToNeutral(RectangleWidth, false, false, IsSticky));
            }
        }

        int _widthAtLastDraw = -1;
        int _heightAtLastDraw = -1;
        double _unitsAtLastDraw;

        /// <summary>
        /// Creates a new instance of the EmptyRectange class.
        /// </summary>
        /// <param name="posX">Value to be set as the X position.</param>
        /// <param name="posY">Value to be set as the Y position.</param>
        /// <param name="width">Value to be set as the width.</param>
        /// <param name="height">Value to be set as the height.</param>
        /// <param name="rectangleWidth">Value to be set as the outline width</param>
        /// <param name="color">Value to be set as the color.</param>
        public EmptyRectangle(double posX, double posY, double width, double height, double rectangleWidth, Color color)
        {
            PosX = posX;
            PosY = posY;
            Width = width;
            Height = height;
            Color = color;
            RectangleWidth = rectangleWidth;
            _pen = new Pen(Color, (float)ScaleConverter.GameToNeutral(RectangleWidth, false, false, IsSticky));
        }

        /// <summary>
        /// Draws an empty rectangle on the window.
        /// </summary>
        public override void Draw()
        {
            if (Collider.IsColliding(this, GameLogic.IsInScreenRect))
            {
                if (GameLogic.Width != _widthAtLastDraw || GameLogic.Height != _heightAtLastDraw || _unitsAtLastDraw != GameLogic.UnitsOnCanvas)
                {
                    _pen?.Dispose();
                    _pen = new Pen(Color, (float)ScaleConverter.GameToNeutral(RectangleWidth, false, false, IsSticky));
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
                GameLogic.G.DrawRectangle(_pen, neutralX, neutralY, neutralWidth, neutralHeight);
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
                    _pen = new Pen(Color, (float)ScaleConverter.GameToNeutral(RectangleWidth, false, false, IsSticky));
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
                section.G.DrawRectangle(_pen, neutralX, neutralY, neutralWidth, neutralHeight);
                section.G.Restore(state);
                _widthAtLastDraw = GameLogic.Width;
                _heightAtLastDraw = GameLogic.Height;
                _unitsAtLastDraw = GameLogic.UnitsOnCanvas;
            }
        }
    }
}