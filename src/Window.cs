using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace Seed
{
    public class GameWindow : Form
    {   
        public GameWindow(int width, int height)
        {
            Height = height;
            Width = width;
            foreach (Sprite sprite in Sprite.Sprites)
            {
                this.Controls.Add(sprite.PictureBox);
            }
        }
    }
}