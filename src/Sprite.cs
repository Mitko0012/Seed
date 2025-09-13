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
        public STexture Texture { get; set; }
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
        /// Draws the sprite onto the screen.
        /// </summary>
        public override void Draw()
        {
            if (Collider.IsColliding(this, GameLogic.IsInScreenRect))
            {
                float neutralX = (float)ScaleConverter.GameToNeutral(PosX, true, true, IsSticky, false);
                float neutralY = (float)ScaleConverter.GameToNeutral(PosY, true, false, IsSticky, false);
                float neutralRotationX = (float)ScaleConverter.GameToNeutral(RotationCenterX, false, true, IsSticky, false);
                float neutralRotationY = (float)ScaleConverter.GameToNeutral(RotationCenterY, false, true, IsSticky, false);
                float neutralWidth = (float)ScaleConverter.GameToNeutral(Width, false, true, IsSticky, false);
                float neutralHeight = (float)ScaleConverter.GameToNeutral(Height, false, true, IsSticky, false);
                GraphicsState state = GameLogic.G.Save();
                GameLogic.G.TranslateTransform(neutralX + neutralRotationX, neutralY + neutralRotationY);
                GameLogic.G.RotateTransform((float)Angle);
                GameLogic.G.TranslateTransform(-(neutralX + neutralRotationX), -(neutralY + neutralRotationY));
                if (Texture.GetType() == typeof(SectionedSTexture))
                {
                    SectionedSTexture sectionedSTexture = (SectionedSTexture)Texture;
                    Rectangle destinationRect = new Rectangle((int)neutralX, (int)neutralY, (int)neutralWidth, (int)neutralHeight);
                    Rectangle sourceRect = new Rectangle(sectionedSTexture.OriginX, sectionedSTexture.OriginY, sectionedSTexture.Width, sectionedSTexture.Height);
                    GameLogic.G.DrawImage(sectionedSTexture.Image, destinationRect, sourceRect, GraphicsUnit.Pixel);
                }
                else
                    GameLogic.G.DrawImage(Texture.Image, neutralX, neutralY, neutralWidth, neutralHeight);
                GameLogic.G.Restore(state);
            }
        }

        /// <summary>
        /// Draws the sprite on a DrawingSection.
        /// </summary>
        /// <param name="section">The section for the sprite to be drawn on.</param>
        public override void DrawOnSection(DrawingSection section)
        {
            if (Collider.IsColliding(this, section) && Collider.IsColliding(this, GameLogic.IsInScreenRect))
            {
                float neutralX = (float)ScaleConverter.GameToNeutral(PosX, true, true, IsSticky, false) - (float)ScaleConverter.GameToNeutral(section.PosX, true, true, section.IsSticky, false);
                float neutralY = (float)ScaleConverter.GameToNeutral(PosY, true, false, IsSticky, false) - (float)ScaleConverter.GameToNeutral(section.PosY, true, false, section.IsSticky, false);
                float neutralRotationX = (float)ScaleConverter.GameToNeutral(RotationCenterX, false, true, IsSticky, false);
                float neutralRotationY = (float)ScaleConverter.GameToNeutral(RotationCenterY, false, true, IsSticky, false);
                float neutralWidth = (float)ScaleConverter.GameToNeutral(Width, false, true, IsSticky, false);
                float neutralHeight = (float)ScaleConverter.GameToNeutral(Height, false, true, IsSticky, false);
                GraphicsState state = section.G.Save();
                section.G.TranslateTransform(neutralX + neutralRotationX, neutralY + neutralRotationY);
                section.G.RotateTransform((float)Angle);
                section.G.TranslateTransform(-(neutralX + neutralRotationX), -(neutralY + neutralRotationY));
                if (Texture.GetType() == typeof(SectionedSTexture))
                {
                    SectionedSTexture sectionedSTexture = (SectionedSTexture)Texture;
                    Rectangle destinationRect = new Rectangle((int)neutralX, (int)neutralY, (int)neutralWidth, (int)neutralHeight);
                    Rectangle sourceRect = new Rectangle(sectionedSTexture.OriginX, sectionedSTexture.OriginY, sectionedSTexture.Width, sectionedSTexture.Height);
                    section.G.DrawImage(sectionedSTexture.Image, destinationRect, sourceRect, GraphicsUnit.Pixel);
                }
                else
                    section.G.DrawImage(Texture.Image, neutralX, neutralY, neutralWidth, neutralHeight);
                section.G.Restore(state);
            }
        }

        /// <summary>
        /// Disposes the resources used by this sprite.
        /// </summary>
        public override void Dispose()
        {
            Texture.Dispose();
        }
    }
}