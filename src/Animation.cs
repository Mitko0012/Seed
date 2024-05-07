using System;
using System.CodeDom;
using System.Diagnostics;
using System.Windows.Forms;

namespace Seed
{
    /// <summary>
    /// Simple animations for sprites.
    /// </summary>
    public class Animation
    {
        Sprite sprite;
        /// <summary>
        /// Represents the time each animation frame is shown. 
        /// </summary>
        public int[] WaitTimes {get; set;}
        STexture[] frames;
        /// <summary>
        /// True if the animation is currently running, false if not.
        /// </summary>
        public bool IsRunning {get; private set;}
        /// <summary>
        /// Whether the animation should loop after it ends.
        /// </summary>
        public bool Looping {get; set;}
        
        /// <summary>
        /// Creates a new animation.
        /// </summary>
        /// <param name="sprite">The sprite the animation is gonna play on.</param>
        /// <param name="waitTime">The time each animation frame is shown. If certain frames should be shown longer, an item of the <c>WaitTimes</c> array can be changed.</param>
        /// <param name="isLooping">Whether the animation should loop after it finishes playing.</param>
        /// <param name="frames">The frames of the animation.</param>
        public Animation(Sprite sprite, int waitTime, bool isLooping, params STexture[] frames)
        {
            this.frames = frames;
            this.sprite = sprite;
            Looping = isLooping;
            List<int> waitTimes = new List<int>();
            foreach(STexture frame in frames)
            {
                waitTimes.Add(waitTime);
            }
            WaitTimes = waitTimes.ToArray();
        }

        /// <summary>
        /// Starts the animation.
        /// </summary>
        public void StartAnimation()
        {
            Thread animThread = new Thread(PlayAnimation);
            animThread.Start();
        }

        void PlayAnimation()
        {
            IsRunning = true;
            foreach(STexture frame in this.frames)
            {
                if(IsRunning)
                {
                    sprite.Texture = frames[Array.IndexOf(frames, frame)];
                    Thread.Sleep(WaitTimes[Array.IndexOf(frames, frame)]);
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

        /// <summary>
        /// Stops the animation.
        /// </summary>
        public void StopAnimation()
        {
            this.IsRunning = false;
        }
    }
}
