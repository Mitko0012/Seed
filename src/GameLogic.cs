using System;
using System.CodeDom;
using System.Diagnostics;
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
        public static GameWindow Window = new GameWindow(1300, 800);
        public static Graphics G {get; private set;}
        static int desiredFps = 60;
        static List<GameLogic> scripts = new List<GameLogic>();
        public static int FrameNumber {get; private set;} = 0;
        public static bool IsRunning {get; private set;} = false;
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
            scripts.Add(this);
            Thread startUpdate = new Thread(() => CallUpdate());
            Thread startWindow = new Thread(() => Window.ShowDialog());
            IsRunning = true;
            startWindow.Start();
            Thread.Sleep(5);
            G = Window.Invoke(() => Window.CreateGraphics());
            startUpdate.Start();
        }

        public void CallUpdate()
        {
            Thread.Sleep(3);
            OnStart();
            long timeAtLastFrameMillis = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            while(true)
            {
                long timeNowMillis = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                DeltaTime = (timeNowMillis - timeAtLastFrameMillis) / 1000.0;
                timeAtLastFrameMillis = timeNowMillis;
                OnUpdate();
                Window.Invalidate();
                FrameNumber++;
                long endTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                long timeItTook = endTime - timeAtLastFrameMillis;
                long waitTime = 1000/DesiredFps - timeItTook;
                if(waitTime > 0)
                {
                    Thread.Sleep(Convert.ToInt32(waitTime));
                }
                Fps = Convert.ToInt32(1f/DeltaTime);
            }
        }
        public static void Paint(object sender, PaintEventArgs e)
        {
            Console.WriteLine(sender.GetType() + " " + e.GetType());;
            G = e.Graphics;
            foreach(GameLogic script in scripts)
            {
                script.OnDraw();
            }
        } 
    }
}
