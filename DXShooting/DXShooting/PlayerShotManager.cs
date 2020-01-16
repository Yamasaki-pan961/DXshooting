using SharpDX.Direct2D1;
using System.Collections.Generic;

namespace DXShooting
{
    public class PlayerShotManager : IDrawable, IMovable , IFirable
    {
        private DeviceContext d2dDeviceContext;
        private List<Shot> shotList;
        private List<Shot> drawList;
        private int y, x;
        private const int SHOT_NUM_MAX = 10;
        private const int SHOT_SPEED = -20;

        public PlayerShotManager(DeviceContext ctx)
        {
            this.d2dDeviceContext = ctx;
            this.Initialize();
        }

        private void Initialize()
        {
            this.y = 0;
            this.x = 0;
            this.shotList = new List<Shot>();

            for(int i = 0;i < SHOT_NUM_MAX; i++)
            {
                this.shotList.Add(new PlayerShot(this.d2dDeviceContext));
            }
            this.drawList = new List<Shot>();
        }

        public void Fire()
        {
            if(this.drawList.Count < SHOT_NUM_MAX)
            {
                var shot = this.shotList[0];
                shot.SetPosition(this.y, this.x);
                this.drawList.Add(shot);

                this.shotList.RemoveAt(0);
            }
        }

        public void Draw()
        {
            for(int i = 0;i < this.drawList.Count; i++)
            {
                this.drawList[i].Draw();
            }
        }

        public void Update()
        {
            for(int i = 0;i < this.drawList.Count; i++)
            {
                var shot = this.drawList[i];

                if (shot.IsMovable())
                {
                    shot.Move(SHOT_SPEED, 0);
                }
                else
                {
                    this.shotList.Add(shot);
                    this.drawList.RemoveAt(i);
                }
            }
        }

        public void Move(int dy, int dx)
        {
            this.y = this.y + dy;
            this.x = this.x + dx;
        }

        public void SetPosition(int y , int x)
        {
            this.y = y;
            this.x = x;
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
    }
}