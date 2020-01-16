using SharpDX;
using SharpDX.Direct2D1;
using System;

namespace DXShooting
{
    public class Fighter : IDrawable, IShooter
    {
        private DeviceContext d2dDeviceContext;
        private Device d2dDevice;
        private TransformedGeometry fighterPath;
        private SolidColorBrush fighterBrush;
        private PlayerShotManager shotManager;

        //10.1
        private int x, y;
        private Vector2 firstPoint , secondPoint , thirdPoint;

        public Fighter(DeviceContext ctx,PlayerShotManager manager)
        {
            this.d2dDeviceContext = ctx;
            this.d2dDevice = ctx.Device;
            
            this.shotManager = manager;
            this.Initialize();
        }

        private void Initialize()
        {
            this.x = 0;
            this.y = 0;

            var path = new PathGeometry(this.d2dDevice.Factory);

            this.firstPoint = new Vector2(25f, 0f);
            this.secondPoint = new Vector2(50f, 50f);
            this.thirdPoint = new Vector2(0f, 50f);

            var sink = path.Open();

            sink.BeginFigure(this.firstPoint, FigureBegin.Filled);

            sink.AddLines(new SharpDX.Mathematics.Interop.RawVector2[] { this.secondPoint, this.thirdPoint });

            sink.EndFigure(FigureEnd.Closed);
            sink.Close();

            this.fighterPath = new TransformedGeometry(this.d2dDevice.Factory, path, Matrix3x2.Identity);

            this.fighterBrush = new SolidColorBrush(this.d2dDeviceContext, Color.OrangeRed);
        }

        public void Draw()
        {
            var fTransform = this.fighterPath.Transform;
            fTransform.M31 = this.x;
            fTransform.M32 = this.y;

            this.d2dDeviceContext.Transform = fTransform;

            this.d2dDeviceContext.DrawGeometry(this.fighterPath, this.fighterBrush);

            this.d2dDeviceContext.Transform = this.fighterPath.Transform;
        }

        public bool IsMovable()
        {
            if (this.y >= 0&&this.x >= 0)
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
            this.x = this.x + dx;
            this.y = this.y + dy;
            this.shotManager.Move(dy, dx);
        }

        public void SetPosition(int y, int x)
        {
            this.y = y - 25;
            this.x = x - 25;
            this.shotManager.SetPosition(this.y, this.x);
        }

        public void Fire()
        {
            this.shotManager.Fire();
        }
    }
}
