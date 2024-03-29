using System;
using System.Windows.Forms;

namespace Seed
{
    /// <summary>
    /// Box colliders that can be attached to elements. This class also has static methods to check if colliders are colliding.
    /// </summary>
    public class Collider
    {
        /// <summary>
        /// The start of the collider's X position in pixels relative to the parent element's X position.
        /// </summary>
        public int RelativeXStart{get; set;}
        
        /// <summary>
        /// The end of the collider's X position in pixels relative to the parent element's X position.
        /// </summary>
        public int RelativeXEnd{get; set;}
        /// <summary>
        /// The start of the collider's Y position in pixels relative to the parent element's Y position.
        /// </summary>
        public int RelativeYStart{get; private set;}

        /// <summary>
        /// The end of the collider's Y position in pixels relative to the parent element's Y position.
        /// </summary>
        public int RelativeYEnd{get; set;}

        /// <summary>
        /// The parent element of the collider.
        /// </summary>
        public Element ParentElement{get; set;}

        /// <summary>
        /// Creates a new collider.
        /// </summary>
        /// <param name="relativeXStart">Value to be set as <c>RelativeXStart</c></param>
        /// <param name="relativeXEnd">Value to be set as <c>RelativeXEnd</c></param>
        /// <param name="relativeYStart">Value to be set as <c>RelativeYStart</c></param>
        /// <param name="relativeYEnd">Value to be set as <c>RelativeYEnd</c></param>
        /// <param name="element">Value to be set as <c>ParentElement</c></param>
        public Collider(int relativeXStart, int relativeXEnd, int relativeYStart, int relativeYEnd, Element element)
        {
            RelativeXStart = relativeXStart;
            RelativeXEnd = relativeXEnd;
            RelativeYStart = relativeYStart;
            RelativeYEnd = relativeYEnd;
            ParentElement = element;
        }
        
        /// <summary>
        /// Checks if two collidable elements are colliding.
        /// </summary>
        /// <param name="element">The first element.</param>
        /// <param name="element2">The second element.</param>
        /// <returns>True if the elements are colliding, false if not.</returns>
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

        /// <summary>
        /// Checks if a collidable element is colliding with a collider.
        /// </summary>
        /// <param name="element">The collidable element.</param>
        /// <param name="collider">The collider.</param>
        /// <returns>True if the element and the collider are colliding, false if not.</returns>
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

        /// <summary>
        /// Checks if two colliders are colliding.
        /// </summary>
        /// <param name="collider">The first collider.</param>
        /// <param name="collider2">The second collider.</param>
        /// <returns>True if the colliders are colliding, false if not.</returns>
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

        /// <summary>
        /// Checks if a point is inside a collidable element.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="pointX">The X position of the point in pixels.</param>
        /// <param name="pointY">The Y position of the point.</param>
        /// <returns>True if the point is inside the element, false if not.</returns>
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
        /// <summary>
        /// Checks if a point is inside a collider.
        /// </summary>
        /// <param name="element">The collider.</param>
        /// <param name="pointX">The X position of the point in pixels.</param>
        /// <param name="pointY">The Y position of the point in pixels.</param>
        /// <returns>True if the point is inside the collider, false if not.</returns>
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
