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
        static List<WeakReference<GameLogic>> scripts = new List<WeakReference<GameLogic>>();
        public static int FrameNumber {get; private set;} = 0;
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
                long timeNowMillis = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                DeltaTime = (timeNowMillis - timeAtLastFrameMillis) / 1000.0;
                timeAtLastFrameMillis = timeNowMillis;
                foreach(WeakReference<GameLogic> script in scripts)
                {
                    script.TryGetTarget(out GameLogic target);
                    target.OnUpdate();
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
        public static void Paint(object sender, PaintEventArgs e)
        {
                G = e.Graphics;
                foreach(WeakReference<GameLogic> script in scripts)
                {
                    script.TryGetTarget(out GameLogic target);
                    target.OnDraw();
                }
        } 
    }
}
