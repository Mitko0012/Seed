namespace Seed;

/// <summary>
/// A STexure from which only a specified part will be drawn.
/// </summary>
public class SectionedSTexture : STexture
{
    /// <summary>
    /// The X position of the origin point in pixels.
    /// </summary>
    public int OriginX;
    /// <summary>
    /// The Y position of the origin point in pixels.
    /// </summary>
    public int OriginY;
    /// <summary>
    /// The width of the drawn area.
    /// </summary>
    public int Width;
    /// <summary>
    /// The height of the drawn area.
    /// </summary>
    public int Height;
    /// <summary>
    /// Creates a new sectioned texture.
    /// </summary>
    /// <param name="originTexture">The STexture whose texture to use.</param>
    /// <param name="posX">The X position of the origin point in pixels.</param>
    /// <param name="posY">The Y position of the origin point in pixels.</param>
    /// <param name="width">The width of the drawn area.</param>
    /// <param name="height">The height of the drawn area.</param>

    public SectionedSTexture(STexture originTexture, int posX, int posY, int width, int height) : base(originTexture)
    {
        OriginX = posX;
        OriginY = posY;
        Width = width;
        Height = height;
    }
}