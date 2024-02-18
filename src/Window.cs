using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections;
using System.Reflection;

namespace Seed
{
    public class GameWindow : Form
    {  
        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        static IntPtr taskBarHandle;
        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string className, string windowText);
        public GameWindow(int width, int height)
        {
            taskBarHandle = FindWindow("Shell_TrayWnd", "");
            Height = height;
            Width = width;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Seed Game";
            this.KeyDown += KeyHandler.KeyDown;
            this.KeyUp += KeyHandler.KeyUp;
            this.MouseMove += Mouse.GetMousePos;
            this.MouseDown += Mouse.OnMouseDown;
            this.MouseUp += Mouse.OnMouseUp;
            this.Paint += GameLogic.Paint;
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream imageStream = assembly.GetManifestResourceStream("Seed.Icons.Icon.ico");
            this.Icon = new Icon(imageStream);
            this.FormClosing += new FormClosingEventHandler(GameWindow.Close);
            DoubleBuffered = true;
            this.UpdateStyles();
        }
        static void Close(object sender, FormClosingEventArgs e)
        {
            ShowWindow(taskBarHandle, 1);
            Environment.Exit(0);
        }
    }
}
