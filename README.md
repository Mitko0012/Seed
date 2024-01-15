# Seed

A 2D graphics library built in C#. It utilizes WinForms for the 2D graphics and NAudio for the audio.

### Code example
An example of Seed code
```
using System;
using System.Media;
using System.Security.Cryptography;
using System.Windows.Forms;
using Seed;

namespace TestGame
{
    class TestGame : GameLogic
    {
        static string texture1 = @"path_to_your_file";
        static string texture2 = @"path_to_your_file";
        static string texture3 = @"path_to_your_file";
        static string texture4 = @"path_to_your_file";
        Sprite sprite1 = new Sprite(1, 56, 250, 250, @"path_to_your_file");
        Sprite ground = new Sprite(1, 560, 800, 25, 0, 0, 0);
        static bool isWalkingLeft = false;
        static int gravSpeed = 500;
        static int velocity = 0;
        static int xVelocity = 0;
        Animation walking = new Animation(sprite1, 200, true, texture1, texture2);
        Animation walkingLeft = new Animation(sprite1, 200, true, texture3, texture4);

        public override void Start()
        {
        }
        public override void Update()
        {
            if(!Collider.IsColliding(sprite1, ground))
            {
                velocity -= Convert.ToInt32(gravSpeed * DeltaTime);
            }
            else if(KeyHandler.KeysDown["Space"])
            {
                velocity = 400;
            }
            else
            {
                velocity = 0;
            }
            if(KeyHandler.KeysDown["D"])
            {
                if(!walking.IsRunning)
                {
                    walkingLeft.StopAnimation();
                    walking.StartAnimation();
                }
                isWalkingLeft = false;
                xVelocity = 400;
            }
            else if(KeyHandler.KeysDown["A"])
            {
                if(!walkingLeft.IsRunning)
                {
                    walking.StopAnimation();
                    walkingLeft.StartAnimation();
                    Console.WriteLine("Starting left anim!");
                }
                isWalkingLeft = true;
                xVelocity = -400;
            }
            else
            {
                walking.StopAnimation();
                walkingLeft.StopAnimation();
                sprite1.SetSprite(isWalkingLeft? texture3 : texture1);
                xVelocity = 0;
            }
            sprite1.SetPosition(sprite1.PosX + Convert.ToInt32(xVelocity * DeltaTime), sprite1.PosY - Convert.ToInt32(velocity * DeltaTime));
        }

        static void Main(string[] args)
        {
            TestGame myGame = new TestGame();
        }
    }
}
```
