using System.Drawing.Drawing2D;

namespace Seed;

/// <summary>
/// An element on which other elements can be drawn
/// </summary>
public class DrawingSection : CollidableElement
{
    Bitmap _bitmap;
    internal Graphics G;
    double _widthAtLastReset = -1;
    double _heightAtLastReset = -1;
    double _unitsAtLastReset = GameLogic.UnitsOnCanvas;
    /// <summary>
    /// Creates a new DrawingSection object
    /// </summary>
    /// <param name="posX">The X position of the section in game units.</param>
    /// <param name="posY">The Y position of the section in game units.</param>
    /// <param name="width">The width of the section in game units.</param>
    /// <param name="height">The height of the section in game units.</param>
    public DrawingSection(double posX, double posY, double width, double height)
    {
        PosX = posX;
        PosY = posY;
        Width = width;
        Height = height;
    }

    /// <summary>
    /// Resets the content of the drawing section
    /// </summary>
    public void Reset()
    {
        if (_widthAtLastReset != Width || _heightAtLastReset != Height || _unitsAtLastReset != GameLogic.UnitsOnCanvas)
        {
            _bitmap?.Dispose();
            _bitmap = new Bitmap((int)ScaleConverter.GameToNeutral(Width, false, false, false, false), (int)ScaleConverter.GameToNeutral(Height, false, false, false, false));
            G = Graphics.FromImage(_bitmap);
            G.InterpolationMode = InterpolationMode.NearestNeighbor;
            G.SmoothingMode = SmoothingMode.HighSpeed;
            G.CompositingQuality = CompositingQuality.HighSpeed;
        }
        else
        {
            G.Clear(Color.Transparent);
        }
        _widthAtLastReset = GameLogic.Width;
        _heightAtLastReset = GameLogic.Height;
        _unitsAtLastReset = GameLogic.UnitsOnCanvas;
    }

    /// <summary>
    /// Draws the section on the game window.
    /// </summary>
    public void Draw()
    {
        GameLogic.G.DrawImage(_bitmap, (int)ScaleConverter.GameToNeutral(PosX, true, true, IsSticky, false), (int)ScaleConverter.GameToNeutral(PosY, true, false, IsSticky, false));
    }

    /// <summary>
    /// Disposes the resources used by this drawing section.
    /// </summary>
    public override void Dispose()
    {
        _bitmap.Dispose();
    }
}