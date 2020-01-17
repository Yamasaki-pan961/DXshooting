using SharpDX;
using SharpDX.Direct2D1;
using System;

namespace DXShooting
{
    /// <summary>
    /// 単純な敵を表すクラス。
    /// </summary>
    public class SimpleEnemy : IMovableRectTarget
    {
        private DeviceContext d2dDeviceContext;
        private Device d2dDevice;
        private int y;
        private int x;
        private TransformedGeometry enemyPath;
        private SolidColorBrush enemyBrush;
        private SolidColorBrush debugBrush;
        private Vector2 firstPoint;
        private Vector2 secondPoint;
        private Vector2 thirdPoint;

        private const float MAX_X = 20f;
        private const float MAX_Y = 20f;
        private const int MOVE_SPEED = 2;

        private bool isVisible;

        public SimpleEnemy(DeviceContext ctx)
        {
            this.d2dDeviceContext = ctx;
            this.d2dDevice = ctx.Device;

            this.Initialize();
        }

        private void Initialize()
        {
            /// 実装
            this.isVisible = true;

            this.x = 0;
            this.y = 0;

            var path = new PathGeometry(this.d2dDevice.Factory);

            this.firstPoint = new Vector2(0f, 0f);
            this.secondPoint = new Vector2(MAX_X, 0f) ;
            this.thirdPoint = new Vector2(MAX_X/2, MAX_Y);

            var sink = path.Open();

            sink.BeginFigure(this.firstPoint, FigureBegin.Filled);
            sink.AddLines(new SharpDX.Mathematics.Interop.RawVector2[] { this.secondPoint, this.thirdPoint });

            sink.EndFigure(FigureEnd.Closed);
            sink.Close();

            this.enemyPath = new TransformedGeometry(this.d2dDevice.Factory, path, Matrix3x2.Identity);

            this.enemyBrush = new SolidColorBrush(this.d2dDeviceContext, Color.Black);
        }

        /// <summary>
        /// 破壊された。
        /// </summary>
        public void Crash()
        {
            this.isVisible = false;
        }

        public void Draw()
        {
            /// 実装
            if (this.isVisible)
            {
                var eTransform = this.enemyPath.Transform;
                eTransform.M31 = this.x;
                eTransform.M32 = this.y;

                this.d2dDeviceContext.Transform = eTransform;

                this.d2dDeviceContext.FillGeometry(this.enemyPath, this.enemyBrush);

                this.d2dDeviceContext.Transform = this.enemyPath.Transform;
            }
        }

        public bool IsHitted(IRectBounds c)
        {
        /// 未実装
            return ShootingUtils.IsIntersected(this , c);
        }

        /// <summary>
        /// 現在の座標から移動できるか判定する。
        /// </summary>
        /// <returns></returns>
        public bool IsMovable()
        {
            if (this.y >= -MAX_Y && this.y <= 640 && this.x >= 0)
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
            this.y = this.y + dy;
            this.x = this.x + dx;
        }

        public void SetPosition(int y, int x)
        {
            this.y = y - (int)MAX_Y / 2;
            this.x = x - (int)MAX_X / 2;

            this.isVisible = true;
        }

        public int GetNorthEastX()
        {
            return (int)(this.x + MAX_X * 3 / 4);
        }

        public int GetNorthEastY()
        {
            return (int)(this.y);
        }

        public int GetSouthWestX()
        {
            return (int)(this.x + MAX_X / 4);
        }

        public int GetSouthWestY()
        {
            return (int)(this.y + MAX_Y / 2);
        }

        /// <summary>
        /// 破壊処理が終わったかどうか。
        /// </summary>
        /// <returns></returns>
        public bool IsFinished()
        {
            return !this.isVisible;
        }

        public bool IsCrashing()
        {
            return !this.isVisible;
        }

        /// <summary>
        /// 次ステップに進む先へ移動。
        /// </summary>
        public void MoveNext()
        {
            ///未実装
            if(this.IsMovable())
            {
                this.Move(MOVE_SPEED, 0);
            }
            else
            {
                this.isVisible = false;
            }
        }


        public int GetCenterX()
        {
            ///未実装
            throw new NotImplementedException();
        }

        public int GetCenterY()
        {
            ///未実装
            throw new NotImplementedException();
        }
    }
}
