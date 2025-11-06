namespace Seed
{
    /// <summary>
    /// A class that represents mouse input.
    /// </summary>
    public static class Mouse
    {
        static double _posX;
        /// <summary>
        /// Gets the X position of the mouse in game units.
        /// </summary>
        public static double PosX
        {
            get
            {
                double unit = Math.Min(GameLogic.WindowWidth, GameLogic.WindowHeight) / GameLogic.UnitsOnCanvas;
                return _posX / unit - GameLogic.WindowWidth / unit / 2 + Camera.PosX;
            }
        }
        static double _posY;
        /// <summary>
        /// Gets the Y position of the mouse in game units.
        /// </summary>
        public static double PosY
        {
            get
            {
                double unit = Math.Min(GameLogic.WindowWidth, GameLogic.WindowHeight) / GameLogic.UnitsOnCanvas;
                return _posY / unit - GameLogic.WindowHeight / unit / 2 + Camera.PosY;
            }
        }

        /// <summary>
        /// True if the left mouse button is down, otherwise false.
        /// </summary>
        public static bool LeftDown {get; private set;}
        /// <summary>
        /// True if the right mouse button is down, otherwise false.
        /// </summary>
        public static bool RightDown {get; private set;}
        /// <summary>
        /// True if the middle mouse button is down, otherwise false.
        /// </summary>
        public static bool MiddleDown {get; private set;}

        /// <summary>
        /// The event handler for when the mouse is moved.
        /// </summary>
        /// <param name="sender">The object that raises the event.</param>
        /// <param name="e">The event arguments.</param>
        public static void GetMousePos(object? sender, MouseEventArgs e)
        {
            double unit = Math.Min(GameLogic.WindowWidth, GameLogic.WindowHeight) / GameLogic.UnitsOnCanvas;
            _posX = e.X;
            _posY = e.Y;
        }

        /// <summary>
        /// The event handler for when a mouse button is clicked.
        /// </summary>
        /// <param name="sender">The object that raises the event.</param>
        /// <param name="e">The event arguments.</param>
        public static void OnMouseDown(object? sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                LeftDown = true;
            }
            if(e.Button == MouseButtons.Right)
            {
                RightDown = true;
            }
            if(e.Button == MouseButtons.Middle)
            {
                MiddleDown = true;
            }
        }

        /// <summary>
        /// The event handler for when a mouse button is released.
        /// </summary>
        /// <param name="sender">The object that raises the event.</param>
        /// <param name="e">The event arguments.</param>
        public static void OnMouseUp(object? sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                LeftDown = false;
            }
            if(e.Button == MouseButtons.Right)
            {
                RightDown = false;
            }
            if(e.Button == MouseButtons.Middle)
            {
                MiddleDown = false;
            }
        }
    }
}
