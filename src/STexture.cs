using System.Drawing;

namespace Seed;

public class STexture
{
    public Image Image {get; private set;}

    public STexture(string texturePath, STextureOrigin origin)
    {
        if(origin == STextureOrigin.FilePath)
        {
            Image = Image.FromFile(texturePath);
        }
        else
        {
            Image = EmbdeddedResourceLoader.LoadImg(texturePath);
        }
    }

    public STexture(int width, int height)
    {
        Image = new Bitmap(width, height);
    }
}