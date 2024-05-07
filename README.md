# Seed

A 2D graphics library built in C#. It utilizes WinForms for the game window, GDI+ for the 2D graphics and NAudio for the audio.

## Dependencies

Seed has the following dependencies:

- [NAudio](https://www.nuget.org/packages/NAudio/2.2.1): Used for audio.
  - Version: 2.2.1
  - License: [MIT License](https://licenses.nuget.org/MIT)


### Code example
An example of Seed code
```C#
using Seed;
using System.Reflection;

namespace MyProject;

public class Logic : GameLogic
{
    public Sprite MySprite = new Sprite(-2, -1, 3, 3, new STexture("MyProject.Textures.MyTexture.png", STextureOrigin.EmbeddedImage));
    public override void OnStart()
    {
        
    }

    public override void OnFrame()
    {
        if(KeyHandler.KeysDown["W"])
        {
            MySprite.PosY -= 2 * DeltaTime;
        }
        if(KeyHandler.KeysDown["A"])
        {
            MySprite.PosX -= 2 * DeltaTime;
        }
        if(KeyHandler.KeysDown["S"])
        {
            MySprite.PosY += 2 * DeltaTime;
        }
        if(KeyHandler.KeysDown["D"])
        {
            MySprite.PosX += 2 * DeltaTime;
        }
        

        MySprite.Draw();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        EmbdeddedResourceLoader.CurrAssembly = Assembly.GetExecutingAssembly();
        Logic myLogic = new Logic();
        GameLogic.StartGameLoop();
    }
}
```
