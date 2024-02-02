using System;
using System.Drawing;
using System.Drawing.Design;
using System.Dynamic;
using System.Windows.Forms;

namespace Seed
{
    public class Sprite : CollidableElement
    {
        public string Texture {get; set;}    
        public Sprite(int posX, int posY, int sizeX, int sizeY, string texture)
        {
            PosX = posX;
            PosY = posY;
            Width = sizeX;
            Height = sizeY;
            Texture = texture;
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
                    Image myImage = Image.FromFile(Texture);
                    GameLogic.G.TranslateTransform(this.PosX + RotationCenterX, this.PosY + RotationCenterY);
                    GameLogic.G.RotateTransform(Angle);
                    GameLogic.G.TranslateTransform(-(this.PosX + RotationCenterX), -(this.PosY + RotationCenterY));
                    GameLogic.G.DrawImage(myImage, PosX, PosY, Width, Height);
                    LastDrawnFrame = GameLogic.FrameNumber;
                }
            }
            else
            {
                throw new Exception("The game is not drawing yet. Please draw the element using the OnDraw method.");
            }
        }
    }
}
