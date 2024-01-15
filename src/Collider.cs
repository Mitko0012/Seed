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
        
        static public bool IsColliding(Sprite sprite, Sprite sprite2)
        {
            if(sprite.IsActive && sprite2.IsActive)
            {
                if(sprite2.PosX < sprite.PosX + sprite.SizeX && sprite2.PosX + sprite2.SizeX > sprite.PosX &&
                sprite2.PosY < sprite.PosY + sprite.SizeY && sprite2.PosY + sprite2.SizeY > sprite.PosY)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        static public bool IsColliding(Sprite sprite, Collider collider)
        {
            if(sprite.IsActive && collider.ParentSprite.IsActive)
            {
                if(sprite.PosX < collider.ParentSprite.PosX + collider.RelativeXEnd && 
                sprite.PosX + sprite.SizeX > collider.ParentSprite.PosX + collider.RelativeXStart &&
                sprite.PosY < collider.ParentSprite.PosY + collider.RelativeYEnd && 
                sprite.PosY + sprite.SizeY > collider.ParentSprite.PosY)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        static public bool IsColliding(Collider collider, Collider collider2)
        {
            if(collider.ParentSprite.IsActive && collider2.ParentSprite.IsActive)
            {
                if(collider2.ParentSprite.PosX + collider2.RelativeXStart < collider.ParentSprite.PosX + collider.RelativeXEnd && 
                collider2.ParentSprite.PosX + collider2.RelativeXEnd > collider.ParentSprite.PosX + collider.RelativeXStart &&
                collider2.ParentSprite.PosY + collider2.RelativeYStart < collider.ParentSprite.PosY + collider.RelativeYEnd && 
                collider2.ParentSprite.PosX + collider2.RelativeYEnd > collider.ParentSprite.PosY + collider.RelativeYStart)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        static public bool IsPointInside(Sprite sprite, int pointX, int pointY)
        {
            if(sprite.IsActive)
            {
                if(sprite.PosX < pointX && sprite.PosX + sprite.SizeX > pointX &&
                sprite.PosY < pointY && sprite.PosY + sprite.SizeY > pointY)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
