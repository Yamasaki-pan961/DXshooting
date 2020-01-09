using SharpDX;
using SharpDX.Direct2D1;
using System;

namespace DXShooting
{
    public class Fighter : IDrawable, IMovable
    {
        private DeviceContext d2dDeviceContext;
        private Device d2dDevice;
        private TransformedGeometry fighterPath;
        private SolidColorBrush fighterBrush;


        public void Draw()
        {
            throw new NotImplementedException();
        }

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
