using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq.Expressions;

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
        public StringFormat Format = new StringFormat();
        /// <summary>
        /// The content of the text.
        /// </summary>
        public string DisplayText;
        
        public string Font;
        public double Size;
        
        /// <summary>
        /// Creates a new instance of the Text class.
        /// </summary>
        /// <param name="posX">Value to be set as the X position.</param>
        /// <param name="posY">Value to be set as the Y position.</param>
        /// <param name="font">Value to be set as the font.</param>
        /// <param name="text">Value to be set as the display text.</param>
        public Text(int posX, int posY, string font, double size, string text)
        {
            PosX = posX;
            PosY = posY;
            Font = font;
            Size = size;
            DisplayText = text;
        }

        /// <summary>
        /// Draws text on the screen.
        /// </summary>
        public override void Draw()
        {
            font = new Font(Font, Convert(Size, false, false));
            Brush brush = new SolidBrush(Color);
            GameLogic.G.DrawString(DisplayText, font, brush, Convert(PosX, true, true), Convert(PosY, true, false), Format);
            brush.Dispose();
        }
    }
}
