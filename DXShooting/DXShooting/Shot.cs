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
            throw new NotImplementedException();
        }

        public void Move(int dy, int dx)
        {
            throw new NotImplementedException();
        }

        public void SetPosition(int y, int x)
        {
            throw new NotImplementedException();
        }
    }
}
