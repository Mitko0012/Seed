using System;
using System.CodeDom;
using System.Diagnostics;
using System.Runtime.InteropServices.Marshalling;
using System.Security.Policy;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;

namespace Seed
{
    public abstract class GameLogic
    {
        public static GameWindow window = new GameWindow(1300, 800);
        static int desiredFps = 60;
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
        static public double deltaTime {get; private set;}
        
        public abstract void Start();
        public abstract void Update();
        public GameLogic()
        {
            Thread startUpdate = new Thread(() => CallUpdate());
            Thread startWindow = new Thread(() => window.ShowDialog());
            Start();
            startWindow.Start();
            Thread.Sleep(5);
            startUpdate.Start();
        }

        public void CallUpdate()
        {
            Thread.Sleep(3);
            long timeAtLastFrameMillis = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            while(true)
            {
                long timeNowMillis = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                deltaTime = (timeNowMillis - timeAtLastFrameMillis) / 1000.0;
                timeAtLastFrameMillis = timeNowMillis;
                Update();
                long endTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                long timeItTook = endTime - timeAtLastFrameMillis;
                long waitTime = 1000/DesiredFps - timeItTook;
                if(waitTime > 0)
                {
                    Thread.Sleep(Convert.ToInt32(waitTime));
                }
                Fps = Convert.ToInt32(1f/deltaTime);
            }
        } 
    }
}