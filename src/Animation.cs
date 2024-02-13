using System;
using System.CodeDom;
using System.Diagnostics;
using System.Windows.Forms;

namespace Seed
{
    public class Animation
    {
        Sprite sprite;
        public int[] WaitTimes {get; set;}
        Image[] frames;
        public bool IsRunning {get; private set;}
        public bool Looping {get; set;}
        
        public Animation(Sprite sprite, int waitTime, bool isLooping, params Image[] frames)
        {
            this.frames = frames;
            this.sprite = sprite;
            Looping = isLooping;
            List<int> waitTimes = new List<int>();
            foreach(Image frame in frames)
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
            IsRunning = true;
            foreach(Image frame in this.frames)
            {
                if(IsRunning)
                {
                    sprite.Texture = frames[Array.IndexOf(frames, frame)];
                }
                else
                {
                    break;
                }
            }
            if(Looping && IsRunning)
            {
                PlayAnimation();
            }
            else
            {
                IsRunning = false;
            }
        }

        public void StopAnimation()
        {
            this.IsRunning = false;
        }
    }
}
