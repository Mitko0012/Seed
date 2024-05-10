namespace Seed
{
    /// <summary>
    /// A text element.
    /// </summary>
    public class Text : Element
    {
        /// <summary>
        /// The color of the text. Black by default.
        /// </summary>
        public Color Color = Color.Black;
        /// <summary>
        /// The font of the text.
        /// </summary>
        Font font;
        /// <summary>
        /// The string format of the text.
        /// </summary>
        StringFormat format = new StringFormat();
        /// <summary>
        /// The content of the text.
        /// </summary>
        public string DisplayText;
        
        /// <summary>
        /// The font of the text. Arial by default.
        /// </summary>
        public string Font = "Arial";
        /// <summary>
        /// The size of the text in game units.
        /// </summary>
        public double Size;

        /// <summary>
        /// The horizontal alignment of the text. Left by default.
        /// </summary>
        public HTextAlignment HorisontalAlignment = HTextAlignment.Left;
        /// <summary>
        /// The vertical aligment of the text. Bottom by default.
        /// </summary>
        public VTextAlignment VerticalAlignment = VTextAlignment.Bottom;
        
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
            this.font = new Font(Font, Convert(Size, false, false));
        }

        /// <summary>
        /// Draws text on the screen.
        /// </summary>
        public override void Draw()
        {
            if(Convert(Size, false, false) != 0)
            {
                format.Alignment = (StringAlignment)HorisontalAlignment;
                format.LineAlignment = (StringAlignment)VerticalAlignment;
                font = new Font(Font, Convert(Size, false, false));
                Brush brush = new SolidBrush(Color);
                GameLogic.G.DrawString(DisplayText, font, brush, Convert(PosX, true, true), Convert(PosY, true, false), format);
                brush.Dispose();
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
