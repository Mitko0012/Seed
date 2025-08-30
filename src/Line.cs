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
                    _pen = new Pen(Color, (float)ScaleConverter.GameToNeutral(Width, false, false, IsSticky));
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
                    _pen = new Pen(Color, (float)ScaleConverter.GameToNeutral(Width, false, false, IsSticky));
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
        /// Draws a line on the game window.
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
                    _pen = new Pen(Color, (float)ScaleConverter.GameToNeutral(Width, false, false, IsSticky));
                }
                GameLogic.G.DrawLine(_pen, (float)ScaleConverter.GameToNeutral(PosX, true, true, IsSticky), (float)ScaleConverter.GameToNeutral(PosY, true, false, IsSticky), (float)ScaleConverter.GameToNeutral(EndPosX, true, true, IsSticky), (float)ScaleConverter.GameToNeutral(EndPosY, true, false, IsSticky));
                _widthAtLastDraw = GameLogic.Width;
                _heightAtLastDraw = GameLogic.Height;
                _unitsAtLastDraw = GameLogic.UnitsOnCanvas;
            }
        }

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
                    _pen = new Pen(Color, (float)ScaleConverter.GameToNeutral(Width, false, false, IsSticky));
                }
                float neutralX = (float)ScaleConverter.GameToNeutral(PosX, true, true, IsSticky) - (float)ScaleConverter.GameToNeutral(section.PosX, true, true, section.IsSticky);
                float neutralY = (float)ScaleConverter.GameToNeutral(PosY, true, false, IsSticky) - (float)ScaleConverter.GameToNeutral(section.PosY, true, false, section.IsSticky);
                float neutralEndX = (float)ScaleConverter.GameToNeutral(EndPosX, true, true, IsSticky) - (float)ScaleConverter.GameToNeutral(section.PosX, true, true, section.IsSticky);
                float neutralEndY = (float)ScaleConverter.GameToNeutral(EndPosX, true, false, IsSticky) - (float)ScaleConverter.GameToNeutral(section.PosY, true, false, section.IsSticky);
                section.G.DrawLine(_pen, neutralX, neutralY, neutralEndX, neutralEndY);
                _widthAtLastDraw = GameLogic.Width;
                _heightAtLastDraw = GameLogic.Height;
                _unitsAtLastDraw = GameLogic.UnitsOnCanvas;
            }
        }
    }
}