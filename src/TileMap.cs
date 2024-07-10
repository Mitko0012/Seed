namespace Seed;

/// <summary>
/// Represents a tile map element.
/// </summary>
public class Tilemap : Element
{
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
        foreach(List<int> row in Map)
        {
            foreach(int tile in row)
            {
                GameLogic.G.DrawImage(GameLogic.TileTextures[tile].Image, Convert(currX, true, true), Convert(currY, true, false), Convert(1.05, false, true), Convert(1.05, false, false));
                currX++;
            }
            currX = PosX;
            currY++;
        }
    }
}