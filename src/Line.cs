namespace Seed
{
    /// <summary>
    /// A line element.
    /// </summary>
    public class Line : Element
    {
        Pen _pen;
        /// <summary>
        /// The X position of the end point of the line in game units.
        /// </summary>
        public double EndPosX;

        /// <summary>
        /// The Y position of the end point of the line in game units.
        /// </summary>
        public double EndPosY;
        double _width;
        /// <summary>
        /// The width of the line in game units.
        /// </summary>
        public double Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
                if (_pen != null)
                {
                    _pen?.Dispose();
                    _pen = new Pen(Color, (float)ScaleConverter.GameToNeutral(Width, false, false, IsSticky, false));
                }
            }
        }

        Color _color;
        /// <summary>
        /// The color of the line in game units.
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
                    _pen = new Pen(Color, (float)ScaleConverter.GameToNeutral(Width, false, false, IsSticky, false));
                }
            }
        }

        double _widthAtLastDraw = -1;
        double _heightAtLastDraw = -1;
        double _unitsAtLastDraw;

        /// <summary>
        /// Creates a new instance of the Line class.
        /// </summary>
        /// <param name="posX">Value to be set as the X position.</param>
        /// <param name="posY">Value to be set as the Y position.</param>
        /// <param name="endPosX">Value to be set as the end X position.</param>
        /// <param name="endPosY">Value to be set as the end Y position.</param>
        /// <param name="width">Value to be set as the width of the line.</param>
        /// <param name="color">Value to be set as the color.</param>
        public Line(double posX, double posY, double endPosX, double endPosY, double width, Color color)
        {
            PosX = posX;
            PosY = posY;
            EndPosX = endPosX;
            EndPosY = endPosY;
            Width = width;
            Color = color;
            _unitsAtLastDraw = GameLogic.UnitsOnCanvas;
        }
        /// <summary>
        /// Draws the line on the game window.
        /// </summary>
        public override void Draw()
        {
            double MinX = Math.Min(EndPosX, PosX);
            double MaxX = Math.Max(EndPosX, PosX);
            double MinY = Math.Min(EndPosY, PosY);
            double MaxY = Math.Max(EndPosY, PosY);
            Collider col = new Collider(MinX - PosX, MaxX - MinX, MinY - PosY, MaxY - MinY, this);
            if (Collider.IsColliding(GameLogic.IsInScreenRect, col))
            {
                if (GameLogic.Width != _widthAtLastDraw || GameLogic.Height != _heightAtLastDraw || _unitsAtLastDraw != GameLogic.UnitsOnCanvas || _pen == null)
                {
                    _pen?.Dispose();
                    _pen = new Pen(Color, (float)ScaleConverter.GameToNeutral(Width, false, false, IsSticky, false));
                }
                GameLogic.G.DrawLine(_pen, (float)ScaleConverter.GameToNeutral(PosX, true, true, IsSticky, false), (float)ScaleConverter.GameToNeutral(PosY, true, false, IsSticky, false), (float)ScaleConverter.GameToNeutral(EndPosX, true, true, IsSticky, false), (float)ScaleConverter.GameToNeutral(EndPosY, true, false, IsSticky, false));
                _widthAtLastDraw = GameLogic.Width;
                _heightAtLastDraw = GameLogic.Height;
                _unitsAtLastDraw = GameLogic.UnitsOnCanvas;
            }
        }

        /// <summary>
        /// Draws the line on a DrawingSection.
        /// </summary>
        /// <param name="section">The section for the line to be drawn on.</param>
        public override void DrawOnSection(DrawingSection section)
        {
            double MinX = Math.Min(EndPosX, PosX);
            double MaxX = Math.Max(EndPosX, PosX);
            double MinY = Math.Min(EndPosY, PosY);
            double MaxY = Math.Max(EndPosY, PosY);
            Collider col = new Collider(MinX - PosX, MaxX - MinX, MinY - PosY, MaxY - MinY, this);
            if (Collider.IsColliding(GameLogic.IsInScreenRect, col) && Collider.IsColliding(section, col))
            {
                if (GameLogic.Width != _widthAtLastDraw || GameLogic.Height != _heightAtLastDraw || _unitsAtLastDraw != GameLogic.UnitsOnCanvas || _pen == null)
                {
                    _pen?.Dispose();
                    _pen = new Pen(Color, (float)ScaleConverter.GameToNeutral(Width, false, false, IsSticky, false));
                }
                float neutralX = (float)ScaleConverter.GameToNeutral(PosX, true, true, IsSticky, false) - (float)ScaleConverter.GameToNeutral(section.PosX, true, true, section.IsSticky, false);
                float neutralY = (float)ScaleConverter.GameToNeutral(PosY, true, false, IsSticky, false) - (float)ScaleConverter.GameToNeutral(section.PosY, true, false, section.IsSticky, false);
                float neutralEndX = (float)ScaleConverter.GameToNeutral(EndPosX, true, true, IsSticky, false) - (float)ScaleConverter.GameToNeutral(section.PosX, true, true, section.IsSticky, false);
                float neutralEndY = (float)ScaleConverter.GameToNeutral(EndPosX, true, false, IsSticky, false) - (float)ScaleConverter.GameToNeutral(section.PosY, true, false, section.IsSticky, false);
                section.G.DrawLine(_pen, neutralX, neutralY, neutralEndX, neutralEndY);
                _widthAtLastDraw = GameLogic.Width;
                _heightAtLastDraw = GameLogic.Height;
                _unitsAtLastDraw = GameLogic.UnitsOnCanvas;
            }
        }
        
        /// <summary>
        /// Disposes the resources used by this line.
        /// </summary>
        public override void Dispose()
        {
            _pen.Dispose();
        }
    }
}