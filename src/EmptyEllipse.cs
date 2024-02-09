using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Seed
{
    public class EmptyEllipse : CollidableElement
    {
        public float OvalWidth;
        public Color Color;
        public EmptyEllipse(int posX, int posY, int height, int width, float ellipseWidth, Color color)
        {
            PosX = posX;
            PosY = posY;
            Width = width;
            Height = height;
            Color = color;
            OvalWidth = ellipseWidth;
        }
        protected override void SpecificDraw()
        {
            GraphicsState state = GameLogic.G.Save();
            Pen pen = new Pen(Color, OvalWidth);
            GameLogic.G.TranslateTransform(this.PosX + RotationCenterX, this.PosY + RotationCenterY);
            GameLogic.G.RotateTransform(Angle);
            GameLogic.G.TranslateTransform(-(this.PosX + RotationCenterX), -(this.PosY + RotationCenterY));
            GameLogic.G.DrawEllipse(pen, PosX, PosY, Width, Height);
            GameLogic.G.Restore(state);
            pen.Dispose();
        }
    }
}
