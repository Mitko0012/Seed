using System;
using System.Windows.Forms;

namespace Seed
{
    public static class Mouse
    {
        public static int MouseX{get; private set;}
        public static int MouseY{get; private set;}
        public static bool LeftDown{get; private set;}
        public static bool RightDown{get; private set;}
        public static bool MiddleDown{get; private set;}

        public static void GetMousePos(object? sender, MouseEventArgs e)
        {
            MouseX = e.X;
            MouseY = e.Y;
        }

        public static void OnMouseDown(object? sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                LeftDown = true;
            }
            if(e.Button == MouseButtons.Right)
            {
                RightDown = true;
            }
            if(e.Button == MouseButtons.Middle)
            {
                MiddleDown = true;
            }
        }

        public static void OnMouseUp(object? sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                LeftDown = false;
            }
            if(e.Button == MouseButtons.Right)
            {
                RightDown = false;
            }
            if(e.Button == MouseButtons.Middle)
            {
                MiddleDown = false;
            }
        }
    }
}
