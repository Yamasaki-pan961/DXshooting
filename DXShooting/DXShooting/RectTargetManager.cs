using SharpDX.Direct2D1;
using System;
using System.Collections.Generic;


namespace DXShooting
{
    public class RectTargetManager : IUpdatable, IDrawable
    {
        private DeviceContext context;
        private List<IMovableRectTarget> targetList;
        private PlayerShotManager playerShotManager;

        public const int ENEMY_MAX_NUM = 10;
        public Random rng;

        public RectTargetManager(DeviceContext ctx, PlayerShotManager playerShotManager)
        {
            this.context = ctx;

            this.playerShotManager = playerShotManager;

            this.Initialize();
        }

        private void Initialize()
        {
            this.targetList = new List<IMovableRectTarget>();

            this.rng = new Random();

            for(int i = 0; i < ENEMY_MAX_NUM; i = i + 1)
            {
                var enemy = new SimpleEnemy(this.context, this.rng);
                this.targetList.Add(enemy);
            }
        }

        private const int MAX_WIDTH = 480;

        /// <summary>
        /// 敵リストから敵オブジェクトを取得する。
        /// </summary>
        /// <param name="index">インデックス番号。</param>
        /// <returns>敵オブジェクト。</returns>
        public IMovableRectTarget GetEnemy(int index)
        {
            return this.targetList[index];
        }

        /// <summary>
        /// 敵リスト内の敵オブジェクトの総数を取得する。
        /// </summary>
        /// <returns>敵オブジェクトの総数。</returns>
        public int GetEnemyCount()
        {
            return this.targetList.Count;
        }

        private void InitializePosition(IMovable e)
        {
            e.SetPosition(0, 10 + this.rng.Next(0, MAX_WIDTH));
        }


        public void Draw()
        {
            foreach (var d in this.targetList)
            {
                d.Draw();
            }
        }

        public void Update()
        {
            for(int i = 0; i < this.targetList.Count; i = i + 1)
            {
                var t = this.targetList[i];
                if(!t.IsCrashing() && this.playerShotManager.IsHitted(t))
                {
                    t.Crash();
                }
                t.MoveNext();
                if(t.IsFinished())
                {
                    InitializePosition(t);
                }
            }
        }
    }
}
