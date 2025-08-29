
namespace Seed;

/// <summary>
/// Class that represents a texture;
/// </summary>
public class STexture
{
    /// <summary>
    /// The source image of the texture;
    /// </summary>
    public Image Image { get; protected set; }

    /// <summary>
    /// Creates an instance of the STexture class.
    /// </summary>
    /// <param name="texturePath">The file path to the image or the name of the embedded resource.</param>
    /// <param name="origin">The origin of the image.</param>
    public STexture(string texturePath, STextureOrigin origin)
    {
        switch (origin)
        {
            case STextureOrigin.FilePath:
                Image = Image.FromFile(texturePath);
                break;
            case STextureOrigin.EmbeddedImage:
                Image = EmbdeddedResourceLoader.LoadImg(texturePath);
                break;
            default:
                throw new ArgumentException("Invalid image origin");
        }
    }

    /// <summary>
    /// Creates an instance of the STexture class with an empty image.
    /// </summary>
    /// <param name="width">The width of the image.</param>
    /// <param name="height">The height of the image.</param>
    public STexture(int width, int height)
    {
        Image = new Bitmap(width, height);
    }

    /// <summary>
    /// Creates an instance of the STexture class with an image from another STexture.
    /// </summary>
    /// <param name="originTexture">The STexture whose image to use.</param>
    public STexture(STexture originTexture)
    {
        Image = originTexture.Image;
    }
}

/// <summary>
/// Represents the origin of an STexture.
/// </summary>
public enum STextureOrigin
{
    /// <summary>
    /// Represents an image loaded from a file.
    /// </summary>
    FilePath,
    /// <summary>
    /// Represents an image loaded as an embedded resource.
    /// </summary>
    EmbeddedImage,
}