using System;
using System.Net.Http.Json;
using System.Reflection.Metadata;
using System.Windows.Forms;
using Microsoft.VisualBasic.Devices;

namespace Seed
{
    public static class KeyHandler
    {
        public static Dictionary<string, bool> KeysDown {get; private set;} = new Dictionary<string, bool>();
        
        static KeyHandler()
        {
            foreach(var key in Keys.GetValues(typeof(Keys)))
            {
                if(!KeysDown.ContainsKey(Convert.ToString(key)))
                {
                    KeysDown.Add(Convert.ToString(key), false);
                    Console.WriteLine(key);
                }
            }
        }
        public static void KeyDown(object sender, KeyEventArgs e)
        {
            KeysDown[Convert.ToString(e.KeyCode)] = true;            
        }    

        public static void KeyUp(object sender, KeyEventArgs e)
        {
            KeysDown[Convert.ToString(e.KeyCode)] = false;
        }
    }
}
