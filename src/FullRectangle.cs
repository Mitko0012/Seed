using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Seed
{
    public class FullRectangle : CollidableElement
    {
         public Color BackgroundColor;
        public FullRectangle(int posX, int posY, int width, int height, Color color)
        {
            PosX = posX;
            PosY = posY;
            Width = width;
            Height = height;
            BackgroundColor = color;
        }

        protected override void SpecificDraw()
        {
            GraphicsState state = GameLogic.G.Save();
            Brush brush = new SolidBrush(BackgroundColor);
            GameLogic.G.TranslateTransform(this.PosX + RotationCenterX, this.PosY + RotationCenterY);
            GameLogic.G.RotateTransform(Angle);
            GameLogic.G.TranslateTransform(-(this.PosX + RotationCenterX), -(this.PosY + RotationCenterY));
            GameLogic.G.FillRectangle(brush, PosX, PosY, Width, Height);
            GameLogic.G.Restore(state);
            brush.Dispose();
        }
    }
}
