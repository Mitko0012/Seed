using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Seed
{
    public class Text : Element
    {
        public Color Color = Color.Black;
        public Font Font;
        public StringFormat Format = new StringFormat();
        public string DisplayText;
        public Text(int posX, int posY, Font font, string text)
        {
            PosX = posX;
            PosY = posY;
            Font = font;
            DisplayText = text;
        }

        public override void Draw()
        {
            Brush brush = new SolidBrush(Color);
            GameLogic.G.DrawString(DisplayText, Font, brush, PosX, PosY , Format);
            brush.Dispose();
        }
    }
}
