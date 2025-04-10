using System.Drawing.Drawing2D;

namespace Seed
{
    /// <summary>
    /// A sprite element.
    /// </summary>
    public class Sprite : CollidableElement
    {
        /// <summary>
        /// The image texture of the sprite.
        /// </summary>
        public STexture Texture {get; set;}    
        /// <summary>
        /// Creates a new instance of the Sprite class.
        /// </summary>
        /// <param name="posX">Value to be set as the X position.</param>
        /// <param name="posY">Value to be set as the Y position.</param>
        /// <param name="sizeX">Value to be set as the width.</param>
        /// <param name="sizeY">Value to be set as the height.</param>
        /// <param name="texture">Value to be set as the image texture.</param>
        public Sprite(double posX, double posY, double sizeX, double sizeY, STexture texture)
        {
            PosX = posX;
            PosY = posY;
            Width = sizeX;
            Height = sizeY;
            Texture = texture;
        }

        /// <summary>
        /// Draws a sprite onto the screen.
        /// </summary>
        public override void Draw()
        {
            if(Collider.IsColliding(this, GameLogic.IsInScreenRect))
            {
                double neutralX = ScaleConverter.GameToNeutral(PosX, true, true, IsSticky);
                double neutralY = ScaleConverter.GameToNeutral(PosY, true, false, IsSticky);
                double neutralRotationX = ScaleConverter.GameToNeutral(RotationCenterX, false, true, IsSticky);
                double neutralRotationY = ScaleConverter.GameToNeutral(RotationCenterY, false, true, IsSticky);
                double neutralWidth = ScaleConverter.GameToNeutral(Width, false, true, IsSticky);
                double neutralHeight = ScaleConverter.GameToNeutral(Height, false, true, IsSticky);
                GraphicsState state = GameLogic.G.Save();
                GameLogic.G.TranslateTransform(neutralX + neutralRotationX, neutralY + neutralRotationY);
                GameLogic.G.RotateTransform((float)Angle);
                GameLogic.G.TranslateTransform(-(neutralX + neutralRotationX), -(neutralY + neutralRotationY));
                GameLogic.G.DrawImage(Texture.Image, neutralX, neutralY, neutralWidth, neutralHeight);
                GameLogic.G.Restore(state);
            }
        }
    }
}