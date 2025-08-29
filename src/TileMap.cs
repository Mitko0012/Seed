namespace Seed;

/// <summary>
/// Represents a tile map element.
/// </summary>
public class Tilemap : Element
{
    const double Scale = 1.05;

    /// <summary>
    /// The tile map where each value corresponds to an index of an item in <c>GameLogic.TileTextures</c>
    /// </summary>
    public List<List<int>> Map = new List<List<int>>();

    /// <summary>
    /// Creates an instance of the tilemap class.
    /// </summary>
    public Tilemap()
    {
        PosX = 0;
        PosY = 0;
    }

    /// <summary>
    /// Draws the tile map on the screen.
    /// </summary>
    public override void Draw()
    {
        double currX = PosX;
        double currY = PosY;
        foreach (List<int> row in Map)
        {
            foreach (int tile in row)
            {
                FullRectangle rect = new FullRectangle(currX, currY, Scale, Scale, Color.FromArgb(0, 0, 0));
                if (Collider.IsColliding(rect, GameLogic.IsInScreenRect))
                {
                    GameLogic.G.DrawImage(GameLogic.TileTextures[tile].Image, (float)ScaleConverter.GameToNeutral(currX, true, true, IsSticky), (float)ScaleConverter.GameToNeutral(currY, true, false, IsSticky), (float)ScaleConverter.GameToNeutral(Scale, false, true, IsSticky), (float)ScaleConverter.GameToNeutral(Scale, false, false, IsSticky));
                }
                currX++;
            }
            currX = PosX;
            currY++;
        }
    }

    public override void DrawOnSection(DrawingSection section)
    {
        double currX = PosX;
        double currY = PosY;
        foreach (List<int> row in Map)
        {
            foreach (int tile in row)
            {
                FullRectangle rect = new FullRectangle(currX, currY, Scale, Scale, Color.FromArgb(0, 0, 0));
                if (Collider.IsColliding(rect, GameLogic.IsInScreenRect) && Collider.IsColliding(rect, section))
                {
                    float neutralX = (float)ScaleConverter.GameToNeutral(currX, true, true, IsSticky) - (float)ScaleConverter.GameToNeutral(section.PosX, true, true, section.IsSticky);
                    float neutralY = (float)ScaleConverter.GameToNeutral(currY, true, false, IsSticky) - (float)ScaleConverter.GameToNeutral(section.PosY, true, false, section.IsSticky);
                    section.G.DrawImage(GameLogic.TileTextures[tile].Image, neutralX, neutralY, (float)ScaleConverter.GameToNeutral(Scale, false, true, IsSticky), (float)ScaleConverter.GameToNeutral(Scale, false, false, IsSticky));
                }
                currX++;
            }
            currX = PosX;
            currY++;
        }
    }           
}