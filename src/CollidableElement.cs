namespace Seed
{
    /// <summary>
    /// This class represents elements which can be directly collision checked.
    /// </summary>
    /// 
    public class CollidableElement : Element
    {
        /// <summary>
        /// The width of the element in game units.
        /// </summary>
        
        public double Width;
        /// <summary>
        /// The height of the element in game units.
        /// </summary>
        
        public double Height;

        /// <summary>
        /// The X position of the center of rotation of the element in game units. Relative to the PosX of the element. 0 by default.
        /// </summary>
        public double RotationCenterX = 0;
        /// <summary>
        /// The T position of the center of rotation of the element in game units. Relative to the PosY of the element. 0 by default.
        /// </summary>
        public double RotationCenterY = 0;
        /// <summary>
        /// The angle of rotation of the element. 0 by default.
        /// </summary>
        public double Angle = 0f;
    }
}
