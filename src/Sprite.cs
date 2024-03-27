using System;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Dynamic;
using System.Windows.Forms;

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
        public Image Texture {get; set;}    
        /// <summary>
        /// Creates a new instance of the Sprite class.
        /// </summary>
        /// <param name="posX">Value to be set as the X position.</param>
        /// <param name="posY">Value to be set as the Y position.</param>
        /// <param name="sizeX">Value to be set as the width.</param>
        /// <param name="sizeY">Value to be set as the height.</param>
        /// <param name="texture">Value to be set as the image texture.</param>
        public Sprite(int posX, int posY, int sizeX, int sizeY, Image texture)
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
            GraphicsState state = GameLogic.G.Save();
            GameLogic.G.TranslateTransform(this.PosX + RotationCenterX, this.PosY + RotationCenterY);
            GameLogic.G.RotateTransform(Angle);
            GameLogic.G.TranslateTransform(-(this.PosX + RotationCenterX), -(this.PosY + RotationCenterY));
            GameLogic.G.DrawImage(Texture, PosX, PosY, Width, Height);
            GameLogic.G.Restore(state);
        }
    }
}