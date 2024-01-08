using System;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Xml;
using Microsoft.VisualBasic;

namespace Seed
{
    public class Sprite
    {
        public int PosX {get; private set;}
        public int PosY {get; private set;}
        public int SizeX {get; private set;}
        public int SizeY {get; private set;}
        public string Texture {get; private set;}    
    

        public PictureBox PictureBox = new PictureBox();
        public Sprite(int posX, int posY, int sizeX, int sizeY, string texture)
        {
            PosX = posX;
            PosY = posY;
            SizeX = sizeX;
            SizeY = sizeY;
            Texture = texture;
            Image myImage;
            myImage = Image.FromFile(Texture);
            PictureBox.Location = new Point(posX, posY);
            PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBox.Size = new System.Drawing.Size(sizeX, sizeY);
            PictureBox.Image = myImage;
            if (GameLogic.IsRunning == false)
            {
                GameLogic.Window.Controls.Add(PictureBox);
            }
            else
            {
                try
                {
                    GameLogic.Window.Invoke(() => GameLogic.Window.Controls.Add(PictureBox));
                }
                catch
                {
                    Environment.Exit(0);
                }
            }
        }

        public void SetPosition(int x, int y)
        {
            try
            {
                PosX = x;
                PosY = y;
                GameLogic.Window.Invoke(new Action(() => PictureBox.Location = new Point(PosX, PosY)));
            }
            catch
            {
                Environment.Exit(0);
            }
        }
        
        public void SetSize(int x, int y)
        {
            try
            {
                SizeX = x;
                SizeY = y;
                GameLogic.Window.Invoke(new Action(() => PictureBox.Size = new Size(PosX, PosY)));
            }
            catch
            {
                Environment.Exit(0);
            }
        }

        public void SetSprite(string Texture)
        {
            Image myImage = Image.FromFile(Texture);
            if(GameLogic.IsRunning)
            {
                PictureBox.Image = myImage;
            }
            else
            {
                try
                {
                    GameLogic.Window.Invoke(new Action(() => PictureBox.Image = myImage));
                }
                catch
                {   
                    Environment.Exit(0);
                }
            }
        }
    }
}
