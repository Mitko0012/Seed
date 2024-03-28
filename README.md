# Seed

A 2D graphics library built in C#. It utilizes WinForms for the 2D graphics and NAudio for the audio.

## Dependencies

Seed has the following dependencies:

- [NAudio](https://www.nuget.org/packages/NAudio/2.2.1): Used for audio.
  - Version: 2.2.1
  - License: [MIT License](https://licenses.nuget.org/MIT)


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
        Ellipse ellipse = new Ellipse(0, 100, 200, 200, Color.Blue);
        static Animation anim = new Animation(sprite, 10, true, Image.FromFile(@"example_path"), 
        Image.FromFile(@"example_path2"));
        public override void OnStart()
        {
            sprite.RotationCenterX = sprite.Width / 2;
            sprite.RotationCenterY = sprite.Height / 2;
            Window.Invoke(() => Window.FullScreen = true);
            ellipse.RotationCenterX = ellipse.Width / 2;
            ellipse.RotationCenterY = ellipse.Height / 2;
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
            sprite.Draw();
            ellipse.Draw();
        }
        static void Main(string[] args)
        {
            Program prog = new Program();
            GameLogic.StartGameLoop();
        }
    }
}
```
