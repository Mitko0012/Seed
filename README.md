# Seed

A 2D graphics library built in C#. It utilizes WinForms for the 2D graphics and NAudio for the audio.

### Code example
An example of Seed code
```C#
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using Seed;

namespace Test
{
    class Program : GameLogic
    {
        static Sprite sprite = new Sprite(Window.Width / 2 - 200/2, Window.Height / 2 - 200/2, 200, 200, Image.FromFile(@"example_path"));
        Ellipse line = new Ellipse(0, 100, 200, 200, Color.Blue);
        static Animation anim = new Animation(sprite, 10, true, Image.FromFile(@"example_path"), 
        Image.FromFile(@"example_path"));
        public override void OnStart()
        {
            sprite.RotationCenterX = sprite.Width / 2;
            sprite.RotationCenterY = sprite.Height / 2;
            Window.Invoke(() => Window.FullScreen = true);
            line.RotationCenterX = line.Width / 2;
            line.RotationCenterY = line.Height / 2;
        }
        public override void OnUpdate()
        {
            if(KeyHandler.KeysDown["D"])
            {
                sprite.Angle += 10f;
                if(!anim.IsRunning)
                {
                    anim.StartAnimation();
                }
            }
            else if(KeyHandler.KeysDown["A"])
            {
                sprite.Angle -= 10f;
                if(!anim.IsRunning)
                {
                    anim.StartAnimation();
                }
            }
            else 
            {
                anim.StopAnimation();
            }
        }
        public override void OnDraw()
        {  
            sprite.Draw();
            line.Draw();
        }
        static void Main(string[] args)
        {
            Program prog = new Program();
            GameLogic.StartGameLoop();
        }
    }
}
```
