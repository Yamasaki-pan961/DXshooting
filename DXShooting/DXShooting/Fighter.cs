using SharpDX;
using SharpDX.Direct2D1;
using System;

namespace DXShooting
{
    public class Fighter : IShooter, IMovableRectTarget
    {
        private DeviceContext d2dDeviceContext;
        private Device d2dDevice;
        private TransformedGeometry fighterPath;
        private PlayerShotManager shotManager;
        private SolidColorBrush fighterBrush;
        private int x;
        private int y;
        private Vector2 firstPoint;
        private Vector2 secondPoint;
        private Vector2 thirdPoint;
        private bool isVisible;
        private const float MAX_X = 50f;
        private const float MAX_Y = 50f;
        public Fighter(DeviceContext ctx, PlayerShotManager manager)
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

            this.isVisible = true;
            this.firstPoint = new Vector2(MAX_X / 2, 0f);
            this.secondPoint = new Vector2(MAX_X, MAX_Y);
            this.thirdPoint = new Vector2(0f, MAX_Y);

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
            if (this.isVisible)
            {
                var fTransform = this.fighterPath.Transform;
                fTransform.M31 = this.x;
                fTransform.M32 = this.y;

                this.d2dDeviceContext.Transform = fTransform;

                this.d2dDeviceContext.DrawGeometry(this.fighterPath, this.fighterBrush);

                this.d2dDeviceContext.Transform = this.fighterPath.Transform;
            }
        }

        public bool IsMovable()
        {
            if (this.y >= 0 && this.y < 600 && this.x >= 0 && this.x < 440)
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
            var bx = this.x;
            var by = this.y;

            this.x = this.x + dx;
            this.y = this.y + dy;

            if (this.IsMovable())
            {
                this.shotManager.Move(dy, dx);
            }
            else
            {
                this.x = bx;
                this.y = by;
            }
        }

        public void SetPosition(int y, int x)
        {
            this.y = y - 25;
            this.x = x - 25;
            this.shotManager.SetPosition(this.y, this.x);
        }
        public void Fire()
        {
            if (this.isVisible)
            {
                this.shotManager.Fire();
            }
        }

        public void MoveNext()
        {
            throw new System.NotImplementedException();
        }

        public int GetCenterX()
        {
            return this.x;
        }

        public int GetCenterY()
        {
            return this.y;
        }

        public bool IsHitted(IRectBounds c)
        {
            return ShootingUtils.IsIntersected(this, c);
        }

        public void Crash()
        {
            this.isVisible = false;
        }
        public bool IsFinished()
        {
            return !this.isVisible;
        }
        public bool IsCrashing()
        {
            return !this.isVisible;
        }

        public int GetNorthEastX()
        {
            return (int)(this.x + MAX_X * 3 / 4);
        }

        public int GetNorthEastY()
        {
            return (int)(this.y + MAX_Y * 3 / 4);
        }

        public int GetSouthWestX()
        {
            return (int)(this.x + MAX_X / 4);
        }

        public int GetSouthWestY()
        {
            return (int)((this.y + MAX_Y));
        }
    }
}
