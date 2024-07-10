namespace Seed
{
    /// <summary>
    /// Box colliders that can be attached to elements. This class also has static methods to check if colliders are colliding.
    /// </summary>
    public class Collider
    {
        /// <summary>
        /// The start of the collider on the X axis in game units relative to the parent element's X position.
        /// </summary>
        public double RelativeXStart{get; set;}
        
        /// <summary>
        /// The end of the collider on the X axis in game units relative to the parent element's X position.
        /// </summary>
        public double RelativeXEnd{get; set;}
        /// <summary>
        /// The start of the collider on the Y axis in game units relative to the parent element's Y position.
        /// </summary>
        public double RelativeYStart{get; set;}

        /// <summary>
        /// The end of the collider on the Y axis in game units relative to the parent element's Y position.
        /// </summary>
        public double RelativeYEnd{get; set;}

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
        public Collider(double relativeXStart, double relativeXEnd, double relativeYStart, double relativeYEnd, Element element)
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
            if(element2.PosX + (element2.IsSticky? Camera.PosX : 0 ) < element.PosX + (element.IsSticky? Camera.PosX : 0) + element.Width && 
            element2.PosX + (element2.IsSticky? Camera.PosX : 0 ) + element2.Width > element.PosX + (element.IsSticky? Camera.PosX : 0) &&
            element2.PosY + (element2.IsSticky? Camera.PosY : 0) < element.PosY + (element.IsSticky? Camera.PosY : 0) + element.Height 
            && element2.PosY + (element2.IsSticky? Camera.PosY : 0) + element2.Height > element.PosY + (element.IsSticky? Camera.PosY : 0))
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
            if(element.PosX + (element.IsSticky? Camera.PosX : 0) < collider.ParentElement.PosX + (collider.ParentElement.IsSticky? Camera.PosX : 0) + collider.RelativeXEnd && 
            element.PosX + (element.IsSticky? Camera.PosX : 0) + element.Width > collider.ParentElement.PosX + (collider.ParentElement.IsSticky? Camera.PosX : 0) + collider.RelativeXStart &&
            element.PosY + (element.IsSticky? Camera.PosY : 0) < collider.ParentElement.PosY + (collider.ParentElement.IsSticky? Camera.PosY : 0) + collider.RelativeYEnd && 
            element.PosY + (element.IsSticky? Camera.PosY : 0) + element.Height > collider.ParentElement.PosY + (collider.ParentElement.IsSticky? Camera.PosY : 0))
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
            if(collider2.ParentElement.PosX + (collider2.ParentElement.IsSticky? Camera.PosX : 0) + collider2.RelativeXStart < collider.ParentElement.PosX + (collider.ParentElement.IsSticky? Camera.PosX : 0) + collider.RelativeXEnd && 
            collider2.ParentElement.PosX + (collider2.ParentElement.IsSticky? Camera.PosX : 0) + collider2.RelativeXEnd > collider.ParentElement.PosX + (collider.ParentElement.IsSticky? Camera.PosX : 0) + collider.RelativeXStart &&
            collider2.ParentElement.PosY + (collider2.ParentElement.IsSticky? Camera.PosY : 0) + collider2.RelativeYStart < collider.ParentElement.PosY + (collider.ParentElement.IsSticky? Camera.PosY : 0) + collider.RelativeYEnd && 
            collider2.ParentElement.PosY + (collider2.ParentElement.IsSticky? Camera.PosY : 0) + collider2.RelativeYEnd > collider.ParentElement.PosY + (collider.ParentElement.IsSticky? Camera.PosY : 0) + collider.RelativeYStart)
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
        /// <param name="pointX">The X position of the point in game units.</param>
        /// <param name="pointY">The Y position of the point in game units.</param>
        /// <returns>True if the point is inside the element, false if not.</returns>
        static public bool IsPointInside(CollidableElement element, double pointX, double pointY)
        {
            if(element.PosX + (element.IsSticky? Camera.PosX : 0) < pointX && element.PosX + (element.IsSticky? Camera.PosX : 0) + element.Width > pointX &&
            element.PosY + (element.IsSticky? Camera.PosY : 0) < pointY && element.PosY + (element.IsSticky? Camera.PosY : 0) + element.Height > pointY)
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
        /// <param name="collider">The collider.</param>
        /// <param name="pointX">The X position of the point in game units.</param>
        /// <param name="pointY">The Y position of the point in game units.</param>
        /// <returns>True if the point is inside the collider, false if not.</returns>
        static public bool IsPointInside(Collider collider, double pointX, double pointY)
        {
            if(collider.ParentElement.PosX + (collider.ParentElement.IsSticky? Camera.PosX : 0) + collider.RelativeXStart < pointX && collider.ParentElement.PosX + (collider.ParentElement.IsSticky? Camera.PosX : 0) + collider.RelativeXEnd > pointX &&
            collider.ParentElement.PosY + (collider.ParentElement.IsSticky? Camera.PosY : 0) + collider.RelativeYStart < pointY && collider.ParentElement.PosY + (collider.ParentElement.IsSticky? Camera.PosY : 0) + collider.RelativeYEnd > pointY)
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
