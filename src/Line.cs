using System;

namespace Seed
{
    public class Line:Element
    {
        public int EndPosX;
        public int EndPosY;
        public float Width;
        public Color Color;

        public Line(int posX, int posY, int endPosX, int endPosY, float width, Color color)
        {
            PosX = posX;
            PosY = posY;
            EndPosX = endPosX;
            EndPosY = endPosY;
            Width = width;
            Color = color;
        }
        protected override void SpecificDraw()
        {
            Pen pen = new Pen(Color, Width);
            GameLogic.G.DrawLine(pen, PosX, PosY, EndPosX, EndPosY);
        }
    }
}
