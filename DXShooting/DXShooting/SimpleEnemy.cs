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
            /// 未実装
            throw new NotImplementedException();
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
            /// 未実装
            throw new NotImplementedException();
        }

        public bool IsHitted(IRectBounds c)
        {
            /// 未実装
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
