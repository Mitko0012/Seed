namespace Seed
{
    /// <summary>
    /// A text element.
    /// </summary>
    public class Text : Element
    {
        Brush _brush = new SolidBrush(Color.Black);

        Color _color;
        /// <summary>
        /// The color of the text. Black by default.
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
                _brush.Dispose();
                _brush = new SolidBrush(value);
            }
        }
        /// <summary>
        /// The font of the text.
        /// </summary>
        Font _font;
        /// <summary>
        /// The string format of the text.
        /// </summary>
        StringFormat format = new StringFormat();
        /// <summary>
        /// The content of the text.
        /// </summary>
        public string DisplayText;

        string _fontString;
        /// <summary>
        /// The font family of the text. Arial by default.
        /// </summary>
        public string Font
        {
            get
            {
                return _fontString;
            }
            set
            {
                _fontString = value;
                _font?.Dispose();
                float neutralSize = (float)ScaleConverter.GameToNeutral(Size, false, false, IsSticky);
                if (neutralSize != 0)
                    _font = new Font(Font, neutralSize);
            }
        }
        double _size = 0;
        /// <summary>
        /// The size of the text in game units.
        /// </summary>
        public double Size
        {
            get
            {
                return _size;
            }
            set
            {
                _size = value;
                _font?.Dispose();
                float neutralSize = (float)ScaleConverter.GameToNeutral(Size, false, false, IsSticky);
                if (neutralSize != 0)
                    _font = new Font(Font, neutralSize);
            }
        }

        /// <summary>
        /// The horizontal alignment of the text. Left by default.
        /// </summary>
        public HTextAlignment HorisontalAlignment = HTextAlignment.Left;
        /// <summary>
        /// The vertical aligment of the text. Bottom by default.
        /// </summary>
        public VTextAlignment VerticalAlignment = VTextAlignment.Bottom;
        private const double _heightLetters = 1.5;
        double _widthAtLastDraw = -1;
        double _heightAtLastDraw = -1;
        double _unitsAtLastDraw;

        /// <summary>
        /// Creates a new instance of the Text class.
        /// </summary>
        /// <param name="posX">Value to be set as the X position.</param>
        /// <param name="posY">Value to be set as the Y position.</param>
        /// <param name="size">Value to be set as the size </param>
        /// <param name="font">Value to be set as the font.</param>
        /// <param name="text">Value to be set as the display text.</param>
        public Text(double posX, double posY, double size, string font, string text)
        {
            PosX = posX;
            PosY = posY;
            Font = font;
            Size = size;
            DisplayText = text;
            Color = Color.Black;
            _unitsAtLastDraw = GameLogic.UnitsOnCanvas;
            _font = new Font(Font, (float)ScaleConverter.GameToNeutral(Size, false, false, IsSticky));
        }

        /// <summary>
        /// Draws text on the screen.
        /// </summary>
        public override void Draw()
        {
            Collider col = new Collider(0, Size * DisplayText.Length, 0, Size * _heightLetters, this);
            if (HorisontalAlignment == HTextAlignment.Center)
            {
                col.RelativeXStart = 0 - Size * DisplayText.Length / 2;
                col.RelativeXEnd = 0 + Size * DisplayText.Length / 2;
            }
            else if (HorisontalAlignment == HTextAlignment.Right)
            {
                col.RelativeXStart = 0 - Size * DisplayText.Length;
                col.RelativeXEnd = 0;
            }
            if (VerticalAlignment == VTextAlignment.Center)
            {
                col.RelativeYStart = 0 - Size * _heightLetters / 2;
                col.RelativeYEnd = 0 + Size * _heightLetters / 2;
            }
            else if (VerticalAlignment == VTextAlignment.Top)
            {
                col.RelativeYStart = 0;
                col.RelativeYEnd = -(Size * _heightLetters);
            }
            float neutralSize = (float)ScaleConverter.GameToNeutral(Size, false, false, IsSticky);
            if (neutralSize != 0 && Collider.IsColliding(GameLogic.IsInScreenRect, col))
            {
                if (GameLogic.Width != _widthAtLastDraw || GameLogic.Height != _heightAtLastDraw || _unitsAtLastDraw != GameLogic.UnitsOnCanvas)
                {
                    _font?.Dispose();
                    _font = new Font(Font, (float)ScaleConverter.GameToNeutral(Size, false, false, IsSticky));
                }
                format.Alignment = (StringAlignment)HorisontalAlignment;
                format.LineAlignment = (StringAlignment)VerticalAlignment;
                GameLogic.G.DrawString(DisplayText, _font, _brush, (float)ScaleConverter.GameToNeutral(PosX, true, true, IsSticky), (float)ScaleConverter.GameToNeutral(PosY, true, false, IsSticky), format);
                _widthAtLastDraw = GameLogic.Width;
                _heightAtLastDraw = GameLogic.Height;
                _unitsAtLastDraw = GameLogic.UnitsOnCanvas;
            }
        }

        public override void DrawOnSection(DrawingSection section)
        {
            Collider col = new Collider(0, Size * DisplayText.Length, 0, Size * _heightLetters, this);
            if (HorisontalAlignment == HTextAlignment.Center)
            {
                col.RelativeXStart = 0 - Size * DisplayText.Length / 2;
                col.RelativeXEnd = 0 + Size * DisplayText.Length / 2;
            }
            else if (HorisontalAlignment == HTextAlignment.Right)
            {
                col.RelativeXStart = 0 - Size * DisplayText.Length;
                col.RelativeXEnd = 0;
            }
            if (VerticalAlignment == VTextAlignment.Center)
            {
                col.RelativeYStart = 0 - Size * _heightLetters / 2;
                col.RelativeYEnd = 0 + Size * _heightLetters / 2;
            }
            else if (VerticalAlignment == VTextAlignment.Top)
            {
                col.RelativeYStart = 0;
                col.RelativeYEnd = -(Size * _heightLetters);
            }
            float neutralSize = (float)ScaleConverter.GameToNeutral(Size, false, false, IsSticky);
            if (neutralSize != 0 && Collider.IsColliding(GameLogic.IsInScreenRect, col) && Collider.IsColliding(section, col))
            {
                if (GameLogic.Width != _widthAtLastDraw || GameLogic.Height != _heightAtLastDraw || _unitsAtLastDraw != GameLogic.UnitsOnCanvas)
                {
                    _font?.Dispose();
                    _font = new Font(Font, (float)ScaleConverter.GameToNeutral(Size, false, false, IsSticky));
                }
                format.Alignment = (StringAlignment)HorisontalAlignment;
                format.LineAlignment = (StringAlignment)VerticalAlignment;
                _font = new Font(Font, neutralSize);
                float neutralX = (float)ScaleConverter.GameToNeutral(PosX, true, true, IsSticky) - (float)ScaleConverter.GameToNeutral(section.PosX, true, true, section.IsSticky);
                float neutralY = (float)ScaleConverter.GameToNeutral(PosY, true, false, IsSticky) - (float)ScaleConverter.GameToNeutral(section.PosY, true, false, section.IsSticky);
                section.G.DrawString(DisplayText, _font, _brush, neutralX, neutralY, format);
                _widthAtLastDraw = GameLogic.Width;
                _heightAtLastDraw = GameLogic.Height;
                _unitsAtLastDraw = GameLogic.UnitsOnCanvas;
            }
        }
    }

    /// <summary>
    /// Represents horizontal text alignment.
    /// </summary>
    public enum HTextAlignment
    {
        /// <summary>
        /// Left alignment.
        /// </summary>
        Left,
        /// <summary>
        /// Center alignment.
        /// </summary>
        Center,
        /// <summary>
        /// Right alignment.
        /// </summary>
        Right
    }

    /// <summary>
    /// Represents vertical aligment.
    /// </summary>
    public enum VTextAlignment
    {
        /// <summary>
        /// Bottom aligment.
        /// </summary>
        Bottom,
        /// <summary>
        /// Center aligment. 
        /// </summary>
        Center,
        /// <summary>
        /// Top aligment.
        /// </summary>
        Top
    }
}
