using System;
using System.CodeDom;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Runtime.InteropServices.Marshalling;
using System.Security.Policy;
using System.Text.Encodings.Web;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;
using Seed;

namespace Seed
{
    /// <summary>
    /// The main class from which all Seed scripts derive.
    /// </summary>
    public abstract class GameLogic
    {
        static Color backgroundColor = Color.White;
        private static GameWindow window = new GameWindow(800, 600);
        static Bitmap secondBuffer = new Bitmap(window.Width, window.Height);
        /// <summary>
        /// Object of type <c>Graphics</c> that is used to draw elements on the game window.
        /// </summary>
        public static Graphics G = Graphics.FromImage(secondBuffer);
        static Graphics? gWindow;
        static int desiredFps = 60;
        static bool isRunning = false;
        static Rectangle screenRectangle;
        static List<GameLogic> scripts = new List<GameLogic>();
        /// <summary>
        /// The count of the frames that have been sucessfully rendered. The value of it is 0 at the start. It increases by 1 with each sucessfully rendered frame.
        /// </summary>
        public static int FrameNumber {get; private set;} = 0;
        /// <summary>
        /// The width of the game window. 1300 by default.
        /// </summary>
        public static int Width {get; private set;} = window.Width;
        /// <summary>
        /// The height of the game window. 800 by default.
        /// </summary>
        public static int Height {get; private set;} = window.Height - (screenRectangle.Top - window.Top) - 8;
        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        static IntPtr taskBarHandle = FindWindow("Shell_TrayWnd", "");
        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string className, string windowText);
        /// <summary>
        /// The desired FPS of the game. 60 by default.
        /// </summary>
        /// <exception cref="InvalidDataException">
        /// Thrown when the value is attempted to be set to 0 or less.
        /// </exception>
        public static int DesiredFps 
        {
            get
            {
                return desiredFps;
            }
            set
            {
                if (value <= 0)
                {
                    throw new InvalidDataException("Fps cannot be less than 0");
                }
                else
                {
                    desiredFps = value;
                }
            }
        }

        /// <summary>
        /// The actual FPS of the game.
        /// </summary>
        public static int Fps {get; private set;}
        /// <summary>
        /// The time between the current and last frame.
        /// </summary>
        static public double DeltaTime {get; private set;}
        
        /// <summary>
        /// Called when the game loop starts. It has to be overriden. It can be used to provide code to be executed when the game loop is started.
        /// </summary>
        public abstract void OnStart();
        /// <summary>
        /// Called each frame. It has to be overriden. It can be used to provide code to be executed each frame.
        /// </summary>
        public abstract void OnFrame();
        /// <summary>
        /// Creates a new instance of the GameLogic class.
        /// </summary>
        /// <exception cref="Exception">Thrown if a GameLogic object gets created after the game loop is started.</exception>
        public GameLogic()
        {
            if(isRunning)
            {
                throw new Exception("New GameLogic scripts cannot be created after the game loop has been started");
            }
            scripts.Add(this);
        }

        /// <summary>
        /// Starts the game loop and opens the game window.
        /// </summary>
        /// <exception cref="Exception">Thrown if the method is called more than once.</exception>
        public static void StartGameLoop()
        {
            if(isRunning)
            {
                throw new Exception("Game loop can only be started once");
            }
            Thread startWindow = new Thread(() => Application.Run(window));
            startWindow.Start();
            isRunning = true;
            CallUpdate();
        }

        static void CallUpdate()
        {
            Thread.Sleep(3);
            gWindow = window.Invoke(() => window.CreateGraphics());
            foreach(GameLogic script in scripts)
            {
                script.OnStart();
            }
            long timeAtLastFrameMillis = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            while(true)
            {
                screenRectangle = window.Invoke(() => window.RectangleToScreen(window.ClientRectangle));
                Brush brush = new SolidBrush(backgroundColor);
                Width = window.Width;
                Height = window.Height - (screenRectangle.Top - window.Top) - 8;
                if(secondBuffer.Size != window.Size)
                {
                    secondBuffer = new Bitmap(window.Width, window.Height);
                    G = Graphics.FromImage(secondBuffer);
                    gWindow = window.Invoke(() => window.CreateGraphics());
                }
                long timeNowMillis = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                DeltaTime = (timeNowMillis - timeAtLastFrameMillis) / 1000.0;
                timeAtLastFrameMillis = timeNowMillis;
                G.FillRectangle(brush, 0, 0, Width, Height);
                foreach(GameLogic script in scripts)
                {
                    script.OnFrame();
                }
                gWindow.DrawImage(secondBuffer, Point.Empty);
                long endTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                long timeItTook = endTime - timeAtLastFrameMillis;
                long waitTime = 1000/DesiredFps - timeItTook;
                FrameNumber++;
                if(waitTime > 0)    
                {
                    Thread.Sleep(Convert.ToInt32(waitTime));
                }
                Fps = Convert.ToInt32(1f/DeltaTime);
            }
        }
        /// <summary>
        /// Sets the title of the game window.
        /// </summary>
        /// <param name="title">The text that gets set as the title of the game window.</param>
        public static void SetTitle(string title)
        {
            if(isRunning)
            {
                window.Invoke(() => window.Text = title);
            }
            else
            {
                window.Text = title;
            }
        }
        /// <summary>
        /// Sets the height and width of the game window.
        /// </summary>
        /// <param name="height">A value in pixels that gets set as the height of the game window.</param>
        /// <param name="width">A value in pixels that gets set as the width of the game window.</param>
        public static void SetSize(int width, int height)
        {
            if(isRunning)
            {
                window.Invoke(() => window.Height = height);
                window.Invoke(() => window.Width = width);
            }
            else
            {
                window.Height = height;
                window.Width = width;
            }
        }
        /// <summary>
        /// Sets the icon of the game winodw.
        /// </summary>
        /// <param name="icon">The icon that gets set as the game window's icon.</param>
        public static void SetIcon(Icon icon)
        {
            if(isRunning)
            {
                window.Invoke(() => window.Icon = icon);
            }
            else
            {
                window.Icon = icon;
            }
        }
        /// <summary>
        /// Enables or disables the game window's resizing.
        /// </summary>
        /// <param name="value">Defines whether the window should be able to be resized or not.</param>
        public static void SetLocked(bool value)
        {    
            switch (value)
            {
                case true:
                if(isRunning)
                {
                    window.Invoke(() => window.FormBorderStyle = FormBorderStyle.FixedSingle);
                    window.Invoke(() => window.MaximizeBox = false);
                }
                else
                {
                    window.FormBorderStyle = FormBorderStyle.FixedSingle;
                    window.MaximizeBox = false;
                }
                break;
                case false:
                if(isRunning)
                {
                    window.Invoke(() => window.FormBorderStyle = FormBorderStyle.Sizable);
                    window.Invoke(() => window.MaximizeBox = true);
                }
                else
                {
                    window.FormBorderStyle = FormBorderStyle.Sizable;
                    window.MaximizeBox = true;
                }
                break;
            }
        }
        /// <summary>
        /// Sets the game window's size mode to windowed or full screen.
        /// </summary>
        /// <param name="value">Describes the size mode the game window is to be set. True if full screen, false if windowed.</param>
        public static void SetFullScreen(bool value)
        {
            nint hwnd = FindWindow("Shell_TrayWnd", "");
            switch(value)
            {
                case true:
                if(isRunning)
                {
                    window.Invoke(() => window.WindowState = FormWindowState.Maximized);
                    SetLocked(true);
                    window.Invoke(() => window.FormBorderStyle = FormBorderStyle.None); 
                }
                else 
                {
                    window.WindowState = FormWindowState.Maximized;
                    SetLocked(true);
                    window.FormBorderStyle = FormBorderStyle.None;
                }
                ShowWindow(hwnd, 0);
                break;
                case false:
                    ShowWindow(taskBarHandle, 5);
                    if(isRunning)
                    {
                        window.Invoke(() => window.WindowState = FormWindowState.Normal);
                        SetLocked(false);
                    }
                    else 
                    {
                        window.WindowState = FormWindowState.Normal;
                        SetLocked(false);
                    }
                    ShowWindow(hwnd, 1);
                    break;
            }
            
        }
        /// <summary>
        /// Sets the background color of the game window.
        /// </summary>
        /// <param name="color">The color which the window's background color is to be set to.</param>
        public static void SetColor(Color color)
        {
            backgroundColor = color;
        }

        private class GameWindow : Form
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
                this.SizeGripStyle = SizeGripStyle.Hide;
                this.Text = "Seed Game";
                this.KeyDown += KeyHandler.KeyDown;
                this.KeyUp += KeyHandler.KeyUp;
                this.MouseMove += Mouse.GetMousePos;
                this.MouseDown += Mouse.OnMouseDown;
                this.MouseUp += Mouse.OnMouseUp;
                Assembly assembly = Assembly.GetExecutingAssembly();
                Stream? imageStream = assembly.GetManifestResourceStream("Seed.Icons.Icon.ico");
                if (imageStream != null)
                {
                    this.Icon = new Icon(imageStream);
                }
                this.FormClosing += new FormClosingEventHandler(GameWindow.Close); 
            }
            static void Close(object? sender, FormClosingEventArgs e)
            {
                ShowWindow(taskBarHandle, 1);
                Environment.Exit(0);
            }
        }
    }
}
