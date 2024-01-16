using System;
using System.Drawing;
using System.Drawing.Design;
using System.Dynamic;
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
        public bool IsVisible {get; private set;} = true;
        public bool IsActive {get; private set;} = true;

        public PictureBox PictureBox {get; set;} = new PictureBox();
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

        public Sprite(int posX, int posY, int sizeX, int sizeY, int R, int G, int B)
        {
            PosX = posX;
            PosY = posY;
            SizeX = sizeX;
            SizeY = sizeY;
            PictureBox.Location = new Point(posX, posY);
            PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBox.Size = new System.Drawing.Size(sizeX, sizeY);
            PictureBox.BackColor = Color.FromArgb(R, G, B);
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
                GameLogic.Window.Invoke(new Action(() => PictureBox.Size = new Size(SizeX, SizeY)));
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
        public void SetVisibility(bool a)
        {
            if (IsActive)
            {
                switch (a)
                {
                    case true:
                    GameLogic.Window.Invoke(() => GameLogic.Window.Controls.Add(this.PictureBox));
                    break;
                    case false:
                    GameLogic.Window.Invoke(() => GameLogic.Window.Controls.Remove(this.PictureBox));
                    break;
                }
                IsVisible = a;
            }
        }

        public void SetActive(bool a)
        {
            SetVisibility(a);
            IsActive = a;
        }
    }
}
