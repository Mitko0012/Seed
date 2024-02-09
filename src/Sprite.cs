using System;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Dynamic;
using System.Windows.Forms;

namespace Seed
{
    public class Sprite : CollidableElement
    {
        public Image Texture {get; set;}    
        public Sprite(int posX, int posY, int sizeX, int sizeY, Image texture)
        {
            PosX = posX;
            PosY = posY;
            Width = sizeX;
            Height = sizeY;
            Texture = texture;
        }

        protected override void SpecificDraw()
        {
            GraphicsState state = GameLogic.G.Save();
            GameLogic.G.TranslateTransform(this.PosX + RotationCenterX, this.PosY + RotationCenterY);
            GameLogic.G.RotateTransform(Angle);
            GameLogic.G.TranslateTransform(-(this.PosX + RotationCenterX), -(this.PosY + RotationCenterY));
            GameLogic.G.DrawImage(Texture, PosX, PosY, Width, Height);
            GameLogic.G.Restore(state);
        }
    }
}
