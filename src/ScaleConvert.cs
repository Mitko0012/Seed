namespace Seed;

/// <summary>
/// A class that contains methods that turn values from position in pixels to position in game units.
/// </summary>
public static class ScaleConverter
{
    /// <summary>
    /// Converts a value from pixels to game units.
    /// </summary>
    /// <param name="value">The value to be converted.</param>
    /// <param name="IsPos">True if the value represents a position, false if it represents a scale.</param>
    /// <param name="IsX">True if the value represents a position on the X axis, false if it represents one on the Y axis.</param>
    /// <param name="IsSticky">True if the value represents a property of a sticky element, false if not</param>
    /// <returns>The value in pixels.</returns>
    public static double NeutralToGame(double value, bool IsPos, bool IsX, bool IsSticky)
    {
        double unit = Math.Min(GameLogic.Width, GameLogic.Height) / GameLogic.UnitsOnCanvas;
        double camOffsetX = Camera.PosX * unit * -1 + (GameLogic.Width / 2);
        double camOffsetY = Camera.PosY * unit * -1 + (GameLogic.Height / 2);

        if(IsX)
        {
            return (value - (IsPos? IsSticky? GameLogic.Width / 2: camOffsetX : 0)) / unit;
        }
        else
        {
            return (value - (IsPos? IsSticky? GameLogic.Height / 2: camOffsetY : 0)) / unit;
        }
    }
    
    /// <summary>
    /// Converts a value from game units to pixels.
    /// </summary>
    /// <param name="value">The value to be converted.</param>
    /// <param name="IsPos">True if the value represents a position, false if it represents a scale.</param>
    /// <param name="IsX">True if the value represents a position on the X axis, false if it represents one on the Y axis.</param>
    /// <param name="IsSticky">True if the value represents a property of a sticky element, false if not</param>
    /// <returns>The value in pixels.</returns>
    public static double GameToNeutral(double value, bool IsPos, bool IsX, bool IsSticky)
    {
        double unit = Math.Min(GameLogic.Width, GameLogic.Height) / GameLogic.UnitsOnCanvas;
        double camOffsetX = Camera.PosX * unit * -1 + (GameLogic.Width / 2);
        double camOffsetY = Camera.PosY * unit * -1 + (GameLogic.Height / 2);

        if(IsX)
        {
            return (int)(value * unit + (IsPos? IsSticky? GameLogic.Width / 2: camOffsetX : 0));
        }
        else
        {
            return (int)(value * unit + (IsPos? IsSticky? GameLogic.Height / 2: camOffsetY : 0));
        }
    }
}
