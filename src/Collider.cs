using System;
using System.Windows.Forms;

namespace Seed
{
    public class Collider
    {
        public int RelativeXStart{get; set;}
        public int RelativeXEnd{get; set;}
        public int RelativeYStart{get; private set;}

        public int RelativeYEnd{get; set;}

        public Element ParentElement{get; set;}

        public Collider(int relativeXStart, int relativeXEnd, int relativeYStart, int relativeYEnd, Element element)
        {
            RelativeXStart = relativeXStart;
            RelativeXEnd = relativeXEnd;
            RelativeYStart = relativeYStart;
            RelativeYEnd = relativeYEnd;
            ParentElement = element;
        }
        
        static public bool IsColliding(CollidableElement element, CollidableElement element2)
        {
                if(element2.PosX < element.PosX + element.Width && element2.PosX + element2.Width > element.PosX &&
                element2.PosY < element.PosY + element.Height && element2.PosY + element2.Height > element.PosY)
                {
                    return true;
                }
                else
                {
                    return false;
                }
        }

        static public bool IsColliding(CollidableElement element, Collider collider)
        {
                if(element.PosX < collider.ParentElement.PosX + collider.RelativeXEnd && 
                element.PosX + element.Width > collider.ParentElement.PosX + collider.RelativeXStart &&
                element.PosY < collider.ParentElement.PosY + collider.RelativeYEnd && 
                element.PosY + element.Height > collider.ParentElement.PosY)
                {
                    return true;
                }
                else
                {
                    return false;
                }
        }

        static public bool IsColliding(Collider collider, Collider collider2)
        {
                if(collider2.ParentElement.PosX + collider2.RelativeXStart < collider.ParentElement.PosX + collider.RelativeXEnd && 
                collider2.ParentElement.PosX + collider2.RelativeXEnd > collider.ParentElement.PosX + collider.RelativeXStart &&
                collider2.ParentElement.PosY + collider2.RelativeYStart < collider.ParentElement.PosY + collider.RelativeYEnd && 
                collider2.ParentElement.PosX + collider2.RelativeYEnd > collider.ParentElement.PosY + collider.RelativeYStart)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        static public bool IsPointInside(CollidableElement element, int pointX, int pointY)
        {
                if(element.PosX < pointX && element.PosX + element.Width > pointX &&
                element.PosY < pointY && element.PosY + element.Height > pointY)
                {
                    return true;
                }
                else
                {
                    return false;
                }
        }
        static public bool IsPointInside(Collider element, int pointX, int pointY)
        {
                if(element.ParentElement.PosX + element.RelativeXStart < pointX && element.ParentElement.PosX + element.RelativeXStart + element.RelativeXEnd > pointX &&
                element.ParentElement.PosY + element.RelativeYStart < pointY && element.ParentElement.PosY + element.RelativeYStart + element.RelativeYEnd > pointY)
                {
                    return true;
                }
                else
                {
                    return false;
                }
        }
    }
}
