using System;
using System.Drawing;

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

        public void Draw()
        {
            if(GameLogic.Drawing)
            {
                if(LastDrawnFrame == GameLogic.FrameNumber && GameLogic.FrameNumber != 1)
                {
                    throw new Exception("Element cannot be drawn more than once per frame");
                }
                else
                {
                    Pen pen = new Pen(Color, RectangleWidth);
                    GameLogic.G.TranslateTransform(this.PosX + RotationCenterX, this.PosY + RotationCenterY);
                    GameLogic.G.RotateTransform(Angle);
                    GameLogic.G.TranslateTransform(-(this.PosX + RotationCenterX), -(this.PosY + RotationCenterY));
                    GameLogic.G.DrawRectangle(pen, PosX, PosY, Width, Height);
                }
            }
            else
            {
                throw new Exception("The game is not drawing yet. Please draw the element using the OnDraw method.");
            }
        }
    }
}
