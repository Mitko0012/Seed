using System;
using System.Drawing;
using System.Drawing.Design;
using System.Dynamic;
using System.Windows.Forms;

namespace Seed
{
    public class Sprite : Element
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
            Image myImage = Image.FromFile(Texture);
            GameLogic.G.DrawImage(myImage, PosX, PosY, Width, Height);
        }
    }
}
