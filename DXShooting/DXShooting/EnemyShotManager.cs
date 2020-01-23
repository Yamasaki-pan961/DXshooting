using SharpDX.Direct2D1;
using System;
using System.Collections.Generic;

namespace DXShooting
{
    public class EnemyShotManager : IUpdatable, IHittable, IDrawable
    {
        private DeviceContext context;
        private IMovableRectTarget player;
        private RectTargetManager enemies;
        private List<IMovableRectTarget> shotList;
        /// <summary>
        /// 乱数生成器オブジェクト
        /// </summary>
        private Random rng;
        private List<IMovableRectTarget> drawList;
        private const int SHOT_NUM_MAX = 50;
        private const int SHOT_SPEED = -3;

        public EnemyShotManager(DeviceContext ctx, RectTargetManager enemyManager, IMovableRectTarget player)
        {
            this.context = ctx;
            this.player = player; ///追加
            this.enemies = enemyManager; ///追加
            this.Initialize();

        }

        private void Initialize()
        {
            this.shotList = new List<IMovableRectTarget>();

            this.rng = new Random();

            for (int i = 0; i < SHOT_NUM_MAX; i = i + 1)
            {
                this.shotList.Add(new EnemyShot(this.context, this.player, SHOT_SPEED));
            }

            this.drawList = new List<IMovableRectTarget>();
        }

        private void SetFire()
        {
            ///未実装
        }

        public void Update()
        {
            ///未実装
        }

        public bool IsHitted(IRectBounds c)
        {
            ///未実装
            throw new NotImplementedException();
        }

        public void Draw()
        {
            ///未実装
        }
    }
}