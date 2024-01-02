using System;
using System.Windows.Forms;
using MyGame;

namespace Seed
{
    public static class Mouse
    {
        public static int MouseX{get; private set;}
        public static int MouseY{get; private set;}

        public static void GetMousePos(object sender, MouseEventArgs e)
        {
            MouseX = e.X;
            MouseY = e.Y;
        }
    }
}
