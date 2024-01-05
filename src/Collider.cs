using System;
using System.Windows.Forms;

namespace Seed
{
    public class Collider
    {
        public int RelativeXStart{get; private set;}
        public int RelativeXEnd{get; private set;}
        public int RelativeYStart{get; private set;}

        public int RelativeYEnd{get; private set;}

        public Sprite ParentSprite{get; private set;}

        public Collider(int relativeXStart, int relativeXEnd, int relativeYStart, int relativeYEnd, Sprite sprite)
        {
            RelativeXStart = relativeXStart;
            RelativeXEnd = relativeXEnd;
            RelativeYStart = relativeYStart;
            RelativeYEnd = relativeYEnd;
            ParentSprite = sprite;
        }
    }
}
