using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpDX;
using SharpDX.Direct2D1;
using System.Threading.Tasks;

namespace DXShooting
{
    class PlayerShot : Shot
    {
        private Brush shotBrush;
        private const float MAX_X = 10f;
        private const float MAX_Y = 10f;

        public PlayerShot(DeviceContext ctx): base(ctx)
        {
            this.shotBrush = new SolidColorBrush(this.d2dDeviceContext, Color.Red);
        }

        public override void Draw()
        {
            this.d2dDeviceContext.FillEllipse(new Ellipse(this.center, MAX_X, MAX_Y), this.shotBrush);
        }

        public override void SetPosition(int y, int x)
        {
            this.center.Y = y + 25f;
            this.center.X = x + 25f;
        }

    }
}
