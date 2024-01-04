using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Seed
{
    public class Animation
    {
        Sprite sprite;
        public int[] WaitTimes {get; set;}
        string[] frames;
        public static bool IsRunning {get; private set;}
        
        public Animation(Sprite sprite, int waitTime, params string[] frames)
        {
            this.frames = frames;
            this.sprite = sprite;
            List<int> waitTimes = new List<int>();
            foreach(string frame in frames)
            {
                waitTimes.Add(waitTime);
            }
            WaitTimes = waitTimes.ToArray();
        }

        public void StartAnimation()
        {
            Thread animThread = new Thread(PlayAnimation);
            animThread.Start();
        }

        void PlayAnimation()
        {
            Stopwatch stopwatch = new Stopwatch();
            IsRunning = true;
            stopwatch.Start();
            foreach(string frame in this.frames)
            {
                if(IsRunning)
                {
                    int i = GameLogic.FrameNumber;
                    bool completedFrame = false;
                    while(stopwatch.ElapsedMilliseconds < this.WaitTimes[Array.IndexOf(frames, frame)])
                    {
                        if (GameLogic.FrameNumber > i && !completedFrame)
                        {
                            sprite.SetSprite(frames[Array.IndexOf(frames, frame)]);
                            completedFrame = true;
                        }
                    }
                    stopwatch.Restart();
                    completedFrame = false;
                }
                else
                {
                    break;
                }
            }
            IsRunning = false;
        }

        public static void StopAnimation()
        {
            IsRunning = false;
        }
    }
}
