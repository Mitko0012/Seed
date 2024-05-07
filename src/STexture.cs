using System.Collections;
using System.Drawing;

namespace Seed;

public class STexture
{
    public Image Image {get; private set;}

    public STexture(string texturePath, STextureOrigin origin)
    {
        switch(origin)
        {
            case STextureOrigin.FilePath:
                Image = Image.FromFile(texturePath);
                break;
            case STextureOrigin.EmbeddedImage:
                Image = EmbdeddedResourceLoader.LoadImg(texturePath);
                break;
        }
    }

    public STexture(int width, int height)
    {
        Image = new Bitmap(width, height);
    }
}

public enum STextureOrigin
{
    FilePath,
    EmbeddedImage,
}