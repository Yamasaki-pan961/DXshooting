using SharpDX;
using SharpDX.Direct2D1;
using SharpDX.DirectWrite;

namespace DXShooting
{
    public class Scorer:IDrawable
    {
        public int Score=0;
        private DeviceContext d2dDeviceContext;
        private SharpDX.DirectWrite.Factory fontFactory;
        private TextFormat textFormat;
        private SolidColorBrush textBrush;

        public Scorer(DeviceContext d2dDeviceContext)
        {
            this.d2dDeviceContext = d2dDeviceContext;
        }

        public void AddScore(int n)
        {
            this.Score = this.Score + n;
        }

        public void Draw()
        {
            this.fontFactory = new SharpDX.DirectWrite.Factory();
            this.textFormat = new TextFormat(this.fontFactory, "Meiryo UI", 24.0f);

            this.textBrush = new SolidColorBrush(d2dDeviceContext, Color.Black);

            this.d2dDeviceContext.DrawText($"SCOER : {GetScore():f}", this.textFormat, new RectangleF(0, 0, 300, 300), this.textBrush, DrawTextOptions.None);
        }

        public int GetScore()
        {
            return this.Score;
        }
    }
}
