namespace Seed;

public class Tilemap : Element
{
    public double PosX = 0;

    public double PosY = 0;

    public List<List<int>> Map = new List<List<int>>();
    
    public Tilemap()
    {

    }

    public override void Draw()
    {
        double currX = PosX;
        double currY = PosY;
        foreach(List<int> row in Map)
        {
            foreach(int tile in row)
            {
                GameLogic.G.DrawImage(GameLogic.TileTextures[tile].Image, Convert(currX, true, true), Convert(currY, true, false), Convert(1, false, true), Convert(1, false, false));
                currX++;
            }
            currX = 0;
            currY++;
        }
    }
}