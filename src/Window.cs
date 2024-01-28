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
            this.KeyDown += KeyHandler.KeyDown;
            this.KeyUp += KeyHandler.KeyUp;
            this.MouseMove += Mouse.GetMousePos;
            this.MouseDown += Mouse.OnMouseDown;
            this.MouseUp += Mouse.OnMouseUp;
            this.Paint += GameLogic.Paint;
            DoubleBuffered = true;
            this.UpdateStyles();
        }
    }
}
