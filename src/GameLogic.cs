using System;
using System.CodeDom;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using System.Security.Policy;
using System.Text.Encodings.Web;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;
using Seed;

namespace Seed
{
    public abstract class GameLogic
    {
        private static GameWindow Window = new GameWindow(1300, 800);
        public static Graphics G {get; private set;}
        static int desiredFps = 60;
        static bool isRunning = false;
        static List<WeakReference<GameLogic>> scripts = new List<WeakReference<GameLogic>>();
        public static int FrameNumber {get; private set;} = 0;
        public static int Width {get; private set;} = Window.Width;
        public static int Height {get; private set;} = Window.Height;
        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        static IntPtr taskBarHandle = FindWindow("Shell_TrayWnd", "");
        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string className, string windowText);
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

        public static int Fps {get; private set;}
        static public double DeltaTime {get; private set;}
        
        public abstract void OnStart();
        public abstract void OnUpdate();
        public abstract void OnDraw();
        public GameLogic()
        {
            scripts.Add(new WeakReference<GameLogic>(this));
            OnStart();
            Thread.Sleep(5);
        }

        static GameLogic()
        {
            Thread startWindow = new Thread(() => Window.ShowDialog());
            isRunning = true;
            startWindow.Start();
            Thread callUpdate = new Thread(() => CallUpdate());
            callUpdate.Start();
        }

        public static void CallUpdate()
        {
            Thread.Sleep(3);
            long timeAtLastFrameMillis = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            while(true)
            {
                Width = Window.Width;
                Height = Window.Height;
                long timeNowMillis = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                DeltaTime = (timeNowMillis - timeAtLastFrameMillis) / 1000.0;
                timeAtLastFrameMillis = timeNowMillis;
                foreach(WeakReference<GameLogic> script in scripts)
                {
                    if(script.TryGetTarget(out GameLogic target))
                    {
                        target.OnUpdate();
                    }
                }
                Window.Invalidate();
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
        public static void Paint(object? sender, PaintEventArgs e)
        {
                G = e.Graphics;
                foreach(WeakReference<GameLogic> script in scripts)
                {
                        if(script.TryGetTarget(out GameLogic target))
                        {
                            target.OnDraw();
                        }
                }
        }
        public static void SetTitle(string title)
        {
            if(isRunning)
            {
                Window.Invoke(() => Window.Text = title);
            }
            else
            {
                Window.Text = title;
            }
        }
        public static void SetSize(int height, int width)
        {
            if(isRunning)
            {
                Window.Invoke(() => Window.Height = height);
                Window.Invoke(() => Window.Width = width);
            }
            else
            {
                Window.Height = height;
                Window.Width = width;
            }
        }
        public static void SetIcon(Icon icon)
        {
            if(isRunning)
            {
                Window.Invoke(() => Window.Icon = icon);
            }
            else
            {
                Window.Icon = icon;
            }
        }
        public static void SetLocked(bool value)
        {    
            switch (value)
            {
                case true:
                if(isRunning)
                {
                    Window.Invoke(() => Window.FormBorderStyle = FormBorderStyle.FixedDialog);
                }
                else
                {
                    Window.FormBorderStyle = FormBorderStyle.FixedDialog;
                }
                break;
                case false:
                if(isRunning)
                {
                    Window.Invoke(() => Window.FormBorderStyle = FormBorderStyle.Sizable);
                }
                else
                {
                    Window.FormBorderStyle = FormBorderStyle.Sizable;
                }
                break;
            }
        }
        public static void SetFullScreen(bool value)
        {
            nint hwnd = FindWindow("Shell_TrayWnd", "");
            switch(value)
            {
                case true:
                if(isRunning)
                {
                    Window.Invoke(() => Window.WindowState = FormWindowState.Maximized);
                    SetLocked(true);
                    Window.Invoke(() => Window.FormBorderStyle = FormBorderStyle.None); 
                }
                else 
                {
                    Window.WindowState = FormWindowState.Maximized;
                    SetLocked(true);
                    Window.FormBorderStyle = FormBorderStyle.None;
                }
                ShowWindow(hwnd, 0);
                break;
                case false:
                    ShowWindow(taskBarHandle, 5);
                    if(isRunning)
                    {
                        Window.Invoke(() => Window.WindowState = FormWindowState.Normal);
                        SetLocked(false);
                    }
                    else 
                    {
                        Window.WindowState = FormWindowState.Normal;
                        SetLocked(false);
                    }
                    ShowWindow(hwnd, 1);
                    break;
            }
            
        }
        public static void SetColor(Color color)
        {
            if(isRunning)
            {
                Window.Invoke(() => Window.BackColor = color);
            }
            else
            {
                Window.BackColor = color;
            }
        }
    }
}
