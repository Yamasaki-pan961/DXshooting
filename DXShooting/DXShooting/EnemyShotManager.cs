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
            if (this.drawList.Count < SHOT_NUM_MAX)
            {
                //0以上のenemiseのSimpleEnemyオブジェクトの個数未満の整数を取得する。
                var eIndex = this.rng.Next(0, this.enemies.GetEnemyCount());

                var enemy = this.enemies.GetEnemy(eIndex);

                var shot = this.shotList[0];
                shot.SetPosition(enemy.GetCenterY(), enemy.GetCenterX() - 15);

                this.drawList.Add(shot);

                this.shotList.RemoveAt(0);
            }
        }

        public void Update()
        {
            //０以上２未満の整数値をランダムに取得し、０だったらSetFireを呼び出す
            if (this.rng.Next(0, 2) == 0)
            {
                this.SetFire();
            }

            for (int i = 0; i < this.drawList.Count; i++)
            {
                var shot = this.drawList[i];
                if (!this.player.IsCrashing() && this.player.IsHitted(shot))
                {
                    this.player.Crash();
                }
                if (shot.IsMovable())
                {
                    shot.MoveNext();
                }
                else
                {
                    this.shotList.Add(shot);
                    this.drawList.RemoveAt(i);
                }
            }
        }

        public bool IsHitted(IRectBounds c)
        {
            for(int i = 0; i < this.drawList.Count; i++)
            {
                var d = this.drawList[i];
                if (d.IsHitted(c))
                {
                    d.Crash();
                    this.shotList.Add(d);
                    this.drawList.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public void Draw()
        {
            for (int i = 0; i < this.drawList.Count; i++)
            {
                this.drawList[i].Draw();
            }
        }
    }
}