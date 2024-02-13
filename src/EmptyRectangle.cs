using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Seed
{
    public class EmptyRectangle : CollidableElement
    {
        public Color Color;
        public float RectangleWidth;
        public EmptyRectangle(int posX, int posY, int width, int height, int rectangleWidth, Color color)
        {
            PosX = posX;
            PosY = posY;
            Width = width;
            Height = height;
            Color = color;
            RectangleWidth = rectangleWidth;
        }

        protected override void Draw()
        {
            GraphicsState state = GameLogic.G.Save();
            Pen pen = new Pen(Color, RectangleWidth);
            GameLogic.G.TranslateTransform(this.PosX + RotationCenterX, this.PosY + RotationCenterY);
            GameLogic.G.RotateTransform(Angle);
            GameLogic.G.TranslateTransform(-(this.PosX + RotationCenterX), -(this.PosY + RotationCenterY));
            GameLogic.G.DrawRectangle(pen, PosX, PosY, Width, Height);
            GameLogic.G.Restore(state);
            pen.Dispose();
        }
    }
}
