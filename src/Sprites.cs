using System;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Xml;

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
            try
            {
                myImage = Image.FromFile(Texture);
            }
            catch
            {
                myImage = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Textures/NotFound.png"));
            }
            PictureBox.Location = new Point(posX, posY);
            PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBox.Size = new System.Drawing.Size(sizeX, sizeY);
            PictureBox.Image = myImage;
            if (GameLogic.isRunning == false)
            {
                GameLogic.window.Controls.Add(PictureBox);
            }
            else
            {
                try
                {
                    GameLogic.window.Invoke(() => GameLogic.window.Controls.Add(PictureBox));
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
                GameLogic.window.Invoke(new Action(() => PictureBox.Location = new Point(PosX, PosY)));
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
                GameLogic.window.Invoke(new Action(() => PictureBox.Size = new Size(PosX, PosY)));
            }
            catch
            {
                Environment.Exit(0);
            }
        }

        public void SetSprite(string Texture)
        {
            try
            {
                Image myImage = Image.FromFile(Texture);
                GameLogic.window.Invoke(new Action(() => PictureBox.Image = myImage));
            }
            catch(FileNotFoundException)
            {
                Image myImage = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Textures/NotFound.png"));
                GameLogic.window.Invoke(new Action(() => PictureBox.Image = myImage));
            }
            catch
            {
                Environment.Exit(0);
            }
        }


        public bool IsColliding(Sprite sprite)
        {
            if(this.PosX < sprite.PosX + sprite.SizeX && this.PosX + this.SizeX > sprite.PosX &&
            this.PosY < sprite.PosY + sprite.SizeY && this.PosY + this.SizeY > sprite.PosY)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsPointInside(int pointX, int pointY)
        {
            if(this.PosX < pointX && this.PosX + this.SizeX > pointX &&
            this.PosY < pointY && this.PosY + this.SizeY > pointY)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
