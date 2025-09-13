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
    /// <param name="isPos">True if the value represents a position, false if it represents a scale.</param>
    /// <param name="isX">True if the value represents a position on the X axis, false if it represents one on the Y axis.</param>
    /// <param name="isSticky">True if the value represents a property of a sticky element, false if not</param>
    /// <param name="useWindowScale">True if the method should use the window measurments, false if it should use the drawing buffer measurements.</param>
    /// <returns>The value in pixels.</returns>
    public static double NeutralToGame(double value, bool isPos, bool isX, bool isSticky, bool useWindowScale)
    {
        int Width = useWindowScale ? GameLogic.WindowWidth : GameLogic.Width;
        int Height = useWindowScale ? GameLogic.WindowHeight : GameLogic.Height;
        double unit = Math.Min(Width, Height) / GameLogic.UnitsOnCanvas;
        double camOffsetX = Camera.PosX * unit * -1 + (Width / 2);
        double camOffsetY = Camera.PosY * unit * -1 + (Height / 2);

        if(isX)
        {
            return (value - (isPos? isSticky? Width / 2: camOffsetX : 0)) / unit;
        }
        else
        {
            return (value - (isPos? isSticky? Height / 2: camOffsetY : 0)) / unit;
        }
    }
    
    /// <summary>
    /// Converts a value from game units to pixels.
    /// </summary>
    /// <param name="value">The value to be converted.</param>
    /// <param name="isPos">True if the value represents a position, false if it represents a scale.</param>
    /// <param name="isX">True if the value represents a position on the X axis, false if it represents one on the Y axis.</param>
    /// <param name="isSticky">True if the value represents a property of a sticky element, false if not</param>
    /// <param name="useWindowScale">True if the method should use the window measurments, false if it should use the drawing buffer measurements.</param>
    /// <returns>The value in pixels.</returns>
    public static double GameToNeutral(double value, bool isPos, bool isX, bool isSticky, bool useWindowScale)
    {
        int Width = useWindowScale ? GameLogic.WindowWidth : GameLogic.Width;
        int Height = useWindowScale ? GameLogic.WindowHeight : GameLogic.Height;
        double unit = Math.Min(Width, Height) / GameLogic.UnitsOnCanvas;
        double camOffsetX = Camera.PosX * unit * -1 + (Width / 2);
        double camOffsetY = Camera.PosY * unit * -1 + (Height / 2);

        if(isX)
        {
            return (int)(value * unit + (isPos? isSticky? Width / 2: camOffsetX : 0));
        }
        else
        {
            return (int)(value * unit + (isPos? isSticky? Height / 2: camOffsetY : 0));
        }
    }
}
