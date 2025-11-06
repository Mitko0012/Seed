namespace Seed
{
    /// <summary>
    /// A class that represents keyboard input.
    /// </summary>
    public static class KeyHandler
    {
        /// <summary>
        /// Contains all the keys and whether each one of them is pressed or not.
        /// </summary>
        public static Dictionary<string, bool> KeysDown {get; private set;} = new Dictionary<string, bool>();
        
        static KeyHandler()
        {
            foreach(var keys in Keys.GetValues(typeof(Keys)))
            {
                Keys key = (Keys)keys;
                if(!KeysDown.ContainsKey(key.ToString()))
                {
                    KeysDown.Add(key.ToString(), false);
                }   
                
            }
        }
        /// <summary>
        /// The event handler for when a key is pressed.
        /// </summary>
        /// <param name="sender">The object that raises the event.</param>
        /// <param name="e">The event arguments.</param>
        public static void KeyDown(object? sender, KeyEventArgs e)
        {   
            KeysDown[e.KeyCode.ToString()] = true;            
        }    

        /// <summary>
        /// The event handler for when a key is released.
        /// </summary>
        /// <param name="sender">The object that raises the event.</param>
        /// <param name="e">The event arguments.</param>
        public static void KeyUp(object? sender, KeyEventArgs e)
        {
            KeysDown[e.KeyCode.ToString()] = false;
        }
    }
}
