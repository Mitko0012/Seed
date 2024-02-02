using System;
using System.Drawing;

namespace Seed
{
    public class FullRectangle : CollidableElement
    {
        
        Color BackgroundColor;
        public FullRectangle(int posX, int posY, int width, int height, Color color)
        {
            PosX = posX;
            PosY = posY;
            Width = width;
            Height = height;
            BackgroundColor = color;
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
                    Brush brush = new SolidBrush(BackgroundColor);
                    GameLogic.G.TranslateTransform(this.PosX + RotationCenterX, this.PosY + RotationCenterY);
                    GameLogic.G.RotateTransform(Angle);
                    GameLogic.G.TranslateTransform(-(this.PosX + RotationCenterX), -(this.PosY + RotationCenterY));
                    GameLogic.G.FillRectangle(brush, PosX, PosY, Width, Height);
                }
            }
            else
            {
                throw new Exception("The game is not drawing yet. Please draw the element using the OnDraw method.");
            }
        }
    }
}
