using SharpDX;
using SharpDX.Direct2D1;
using System;


namespace DXShooting
{
    public abstract class Shot : IDrawable, IMovable
    {

        protected DeviceContext d2dDeviceContext;
        protected Vector2 center;

        public Shot(DeviceContext ctx)
        {
            this.d2dDeviceContext = ctx;

            this.center = new Vector2();
        }

        public abstract void Draw();

        public bool IsMovable()
        {
           if(this.center.X >= 0 && this.center.Y >= 0)
            {
                return true;
            }
           else
            {
                return false;
            }
        }

        public void Move(int dy, int dx)
        {
            this.center.X = this.center.X + dx;
            this.center.Y = this.center.Y + dy;
        }

        public abstract void SetPosition(int y, int x);
    }
}
