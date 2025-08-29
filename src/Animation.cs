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
        public int[] WaitTimes { get; private set; }
        internal STexture[] Frames;
        /// <summary>
        /// True if the animation is currently running, false if not.
        /// </summary>
        public bool IsRunning { get; private set; }
        /// <summary>
        /// Whether the animation should loop after it ends.
        /// </summary>
        public bool Looping { get; set; }
        private static List<AnimationRunner> AnimsToRun = new List<AnimationRunner>();

        /// <summary>
        /// Creates a new animation.
        /// </summary>
        /// <param name="sprite">The sprite the animation is gonna play on.</param>
        /// <param name="waitTime">The time each animation frame is shown. If certain frames should be shown longer, an item of the <c>WaitTimes</c> array can be changed.</param>
        /// <param name="isLooping">Whether the animation should loop after it finishes playing.</param>
        /// <param name="frames">The frames of the animation.</param>
        public Animation(Sprite sprite, int waitTime, bool isLooping, params STexture[] frames)
        {
            this.Frames = frames;
            this.sprite = sprite;
            Looping = isLooping;
            List<int> waitTimes = new List<int>();
            foreach (STexture frame in frames)
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
            if (!IsRunning)
            {
                IsRunning = true;
                AnimsToRun.Add(new AnimationRunner(sprite, this));
            }
        }
        

        /// <summary>
        /// Stops the animation.
        /// </summary>
        public void StopAnimation()
        {
            this.IsRunning = false;
        }

        class AnimationRunner
        {
            public double Time = 0;
            public int FrameAt = 0;
            public Animation Anim;
            public Sprite Sprite;
            public AnimationRunner(Sprite sprite, Animation anim)
            {
                Sprite = sprite;
                Anim = anim;
            }
        }

        internal static void CheckAnimations()
        {
            List<AnimationRunner> finishedAnims = new List<AnimationRunner>();
            foreach (AnimationRunner runner in AnimsToRun)
            {
                if (runner.Anim.IsRunning == false)
                {
                    finishedAnims.Add(runner);
                    continue;
                }
                if (runner.Time == 0 && runner.FrameAt == 0)
                        runner.Sprite.Texture = runner.Anim.Frames[runner.FrameAt];
                double time = GameLogic.DeltaTime * 1000;
                double waitTime = runner.Anim.WaitTimes[runner.FrameAt];
                runner.Time += time;
                while (runner.Time > waitTime)
                {
                    runner.FrameAt++;
                    if (runner.FrameAt < runner.Anim.WaitTimes.Length)
                    {
                        runner.Sprite.Texture = runner.Anim.Frames[runner.FrameAt];
                        runner.Time = 0;
                    }
                    else
                    {
                        if (runner.Anim.Looping)
                        {
                            runner.FrameAt = 0;
                            runner.Sprite.Texture = runner.Anim.Frames[runner.FrameAt];
                            runner.Time = 0;
                        }
                        else
                        {
                            runner.Anim.IsRunning = false;
                            finishedAnims.Add(runner);
                        }
                        break;
                    }
                    time -= waitTime;
                    runner.Time += time;
                    waitTime = runner.Anim.WaitTimes[runner.FrameAt];
                }
            }

            foreach (AnimationRunner runner in finishedAnims)
            {
                AnimsToRun.Remove(runner);
            }
        }
    }
}
