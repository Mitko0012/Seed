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
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();
        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string className, string windowText);
        const int hide = 0;
        const int show = 5;
        static IntPtr taskBarHandle = FindWindow("Shell_TrayWnd", "");
        private bool showConsole;
        public bool ShowConsole {
            get
            {
                return showConsole;
            }
            set
            {
                var handle = GetConsoleWindow();
                switch(value)
                {
                    case true:
                        ShowWindow(handle, show);
                        break;
                    case false:
                        ShowWindow(handle, hide);
                        break;
                }
            }
        }
        private bool isFullScren;
        public bool FullScreen {
        get
            {
                return isFullScren;
            } 
        set
            {
                switch(value)
                {
                    case true:
                        ShowWindow(taskBarHandle, 0);
                        this.FormBorderStyle = FormBorderStyle.None;
                        this.WindowState = FormWindowState.Maximized;
                        this.MaximumSize = this.Size;
                        this.MinimumSize = this.Size;
                        break;
                    case false:
                        ShowWindow(taskBarHandle, 5);
                        this.WindowState = FormWindowState.Normal;
                        this.FormBorderStyle = FormBorderStyle.Sizable;
                        this.MaximumSize = Size.Empty;
                        this.MinimumSize = Size.Empty;
                        break;
                }
                isFullScren = value;
            }
        }
        public GameWindow(int width, int height)
        {
            ShowConsole = true;
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
            ShowWindow(taskBarHandle, 5);
            Environment.Exit(0);
        }
    }
}
