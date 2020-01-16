using SharpDX;
using SharpDX.Direct2D1;
using SharpDX.DirectWrite;
using System;

using System.Threading.Tasks;

namespace DXShooting
{
    /// <summary>
    /// 待機処理タイマー。
    /// </summary>
    public class FramePerSec
    {
        private DeviceContext d2dDeviceContext;
        private SharpDX.DirectWrite.Factory fontFactory;
        private TextFormat textFormat;
        private SolidColorBrush textBrush;
        private float fps;
        private long prevCalcTime;
        private long endTime;
        private long startTime;
        private int frameCnt;
        private long calcInterval;
        private long delayProcTime;
        private const long FIXED_FRAME_RATE = (long)((1.0f / 60f) * 1000);
        private const long MAX_FRAME_INTERVAL = 1000;

        public FramePerSec(DeviceContext ctx)
        {
            this.d2dDeviceContext = ctx;

            this.Initialize();
        }

        private void Initialize()
        {
            this.fontFactory = new SharpDX.DirectWrite.Factory();

            this.textFormat = new TextFormat(this.fontFactory, "Meiryo UI", 24.0f);

            this.textBrush = new SolidColorBrush(d2dDeviceContext, Color.Black);

            this.fps = 0f;
            this.endTime = 0;
        }

        /// <summary>
        /// FPSの記録を開始する。
        /// </summary>
        public void StartUp()
        {
            this.startTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();

            this.frameCnt = 0;
            this.calcInterval = 0;
        }

        private void CalculateFPS()
        {
            this.frameCnt = this.frameCnt + 1;
            this.calcInterval = this.calcInterval + FIXED_FRAME_RATE;

            if (this.calcInterval >= MAX_FRAME_INTERVAL)
            {
                var timeNow = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                var elapsedTime = timeNow - this.prevCalcTime;

                this.fps = ((float)this.frameCnt / elapsedTime) * 1000;

                this.calcInterval = 0;
                this.frameCnt = 0;
                this.prevCalcTime = timeNow;
            }
        }

        /// <summary>
        /// 現時点でのFPSを記録する。
        /// </summary>
        public void Record()
        {

            this.endTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();

            // FIXED_FRAME_RATEのときの待機時間の計算
            var sleepTime = FIXED_FRAME_RATE - (this.endTime - this.startTime) - delayProcTime;

            if (sleepTime > 0)
            {
                //同期的にスレッドを待つ。
                Task.Delay((int)(sleepTime)).Wait();

                //待機処理にかかった時間を記録
                this.delayProcTime = DateTimeOffset.Now.ToUnixTimeMilliseconds() - this.endTime - sleepTime;
            }
            else
            {
                this.delayProcTime = 0;
            }

            // 次回計測用に現在の時間を記録
            this.startTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();

            this.CalculateFPS();
        }
    }
}
