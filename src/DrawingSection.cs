namespace Seed;

public class DrawingSection : CollidableElement
{
    Bitmap _bitmap;
    internal Graphics G;
    double _widthAtLastReset = -1;
    double _heightAtLastReset = -1;
    double _unitsAtLastReset = GameLogic.UnitsOnCanvas; 
    public DrawingSection(double posX, double posY, double width, double height)
    {
        PosX = posX;
        PosY = posY;
        Width = width;
        Height = height;
    }

    public void Reset()
    {
        if (_widthAtLastReset != Width || _heightAtLastReset != Height || _unitsAtLastReset != GameLogic.UnitsOnCanvas)
        {
            _bitmap?.Dispose();
            _bitmap = new Bitmap((int)ScaleConverter.GameToNeutral(Width, false, false, false), (int)ScaleConverter.GameToNeutral(Height, false, false, false));
            G = Graphics.FromImage(_bitmap);
        }
        else
        {
            G.Clear(Color.Transparent);
        }
        _widthAtLastReset = GameLogic.Width;
        _heightAtLastReset = GameLogic.Height;
        _unitsAtLastReset = GameLogic.UnitsOnCanvas;
    }

    public void Draw()
    {
        GameLogic.G.DrawImage(_bitmap, (int)ScaleConverter.GameToNeutral(PosX, true, true, IsSticky), (int)ScaleConverter.GameToNeutral(PosY, true, false, IsSticky));
    }
}