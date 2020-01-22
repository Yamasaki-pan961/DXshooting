using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpDX;
using SharpDX.Direct2D1;
using System.Threading.Tasks;

namespace DXShooting
{
    class PlayerShot : Shot,IRectBounds
    {
        private Brush shotBrush;
        private const float MAX_X = 10f;
        private const float MAX_Y = 10f;
        private const float INNER_DIFF = 2f;
        private bool isVisible;

        public PlayerShot(DeviceContext ctx): base(ctx)
        {
            this.shotBrush = new SolidColorBrush(this.d2dDeviceContext, Color.Red);
            this.isVisible = true;
        }

        public override void Draw()
        {
            if(this.isVisible)
            {
                this.d2dDeviceContext.FillEllipse(new Ellipse(this.center, MAX_X, MAX_Y), this.shotBrush);
            }
        }

        public override void SetPosition(int y, int x)
        {
            this.center.Y = y + 25f;
            this.center.X = x + 25f;

            this.isVisible = true;
        }

        public int GetNorthEastX()
        {
            return (int)(this.center.X + MAX_X - INNER_DIFF);
        }
        public int GetNorthEastY()
        {
            return (int)(this.center.Y - (MAX_Y - INNER_DIFF));
        }
        public int GetSouthWestX()
        {
            return (int)(this.center.X - (MAX_X - INNER_DIFF));
        }
        public int GetSouthWestY()
        {
            return (int)(this.center.Y + MAX_Y - INNER_DIFF);
        }
        public override bool IsHitted(IRectBounds c)
        {
            return ShootingUtils.IsIntersected(this, c);
        }
        public override void Crash()
        {
            this.isVisible = false;
        }
        public override bool IsFinished()
        {
            return !this.isVisible;
        }
        public override bool IsCrashing()
        {
            return ! this.isVisible;
        }
    }
}
