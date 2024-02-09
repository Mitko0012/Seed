using System;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;

namespace Seed
{
    public class Element
    {
        public int PosX;
        public int PosY;
        public int RotationCenterX = 0;
        public int RotationCenterY = 0;
        public float Angle = 0f;
        protected int lastDrawnFrame = 1;
        Size lastDrawnWinSize;
        public void Draw()
        {  
            SpecificDraw();
            lastDrawnFrame = GameLogic.FrameNumber;
            lastDrawnWinSize = GameLogic.Window.Size;
        }
        protected virtual void SpecificDraw(){}
    }
}
