using System;
using System.Reflection.Metadata;
using System.Windows.Forms;
using Microsoft.VisualBasic.Devices;

namespace Seed
{
    static class KeyHandler
    {
        public static string CurrentKey {get; set;} = "";
        public static void KeyDown(object sender, KeyEventArgs e)
        {
            CurrentKey = Convert.ToString(e.KeyCode);
        }    

        public static void KeyUp(object sender, KeyEventArgs e)
        {
            CurrentKey = string.Empty;
        }
   
    }
}
