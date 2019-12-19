using SharpDX;
using SharpDX.Direct2D1;
using SharpDX.Direct3D;
using SharpDX.Direct3D11;
using SharpDX.DXGI;
using System;
using System.Diagnostics;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.Core;
using Windows.Graphics.Display;
using Windows.UI.Core;

namespace DXShooting
{
    class App
    {
        [MTAThread]
        private static void Main()
        {
            var viewFactory = new FrameworkViewSource();
            CoreApplication.Run(viewFactory);
        }

        class FrameworkViewSource : IFrameworkViewSource
        {
            public IFrameworkView CreateView()
            {
                return new FrameworkView();
            }
        }


        class FrameworkView : IFrameworkView
        {
            private SharpDX.Direct2D1.DeviceContext d2dDeviceContext;
            private Bitmap1 d2dTarget;
            private SwapChain1 swapChain;
            private CoreWindow mWindow;

            public void Initialize(CoreApplicationView applicationView)
            {
                Debug.WriteLine("Initialize");

                applicationView.Activated += OnActivated;
            }

            void OnActivated(CoreApplicationView applicationView, IActivatedEventArgs args)
            {

                CoreWindow.GetForCurrentThread().Activate();

            }

            void CreateDeviceResources()
            {
                /// デフォルトDirect3Dデバイスの作成（取得）
                var defaultDevice = new SharpDX.Direct3D11.Device(DriverType.Hardware, DeviceCreationFlags.Debug | DeviceCreationFlags.BgraSupport);
                /// サポートされているデバイスの取得
                var device = defaultDevice.QueryInterface<SharpDX.Direct3D11.Device1>();

                /// COMを使って、D3Dデバイスオブジェクトに内在するのDXGIデバイスオブジェクトを取得する
                var dxgiDevice2 = device.QueryInterface<SharpDX.DXGI.Device2>();
                /// アダプターの取得
                var dxgiAdapter = dxgiDevice2.Adapter;
                /// COMを使って、DXGIデバイスのファクトリーオブジェクトを取得
                SharpDX.DXGI.Factory2 dxgiFactory2 = dxgiAdapter.GetParent<SharpDX.DXGI.Factory2>();


                var desc = new SwapChainDescription1();

                desc.Width = 480;
                desc.Height = 640;
                desc.Format = Format.B8G8R8A8_UNorm;
                desc.Stereo = false;
                desc.SampleDescription = new SampleDescription(1, 0);
                desc.Usage = Usage.RenderTargetOutput;
                desc.BufferCount = 2;
                desc.Scaling = Scaling.AspectRatioStretch;
                desc.SwapEffect = SwapEffect.FlipSequential;
                desc.Flags = SwapChainFlags.AllowModeSwitch;


                /// スワップチェインの作成
                this.swapChain = new SwapChain1(dxgiFactory2, device, new ComObject(mWindow), ref desc);


                /// Direct2Dデバイスの取得。
                var d2dDevice = new SharpDX.Direct2D1.Device(dxgiDevice2);

                /// Direct2Dデバイスのコンテキストを取得。
                this.d2dDeviceContext = new SharpDX.Direct2D1.DeviceContext(d2dDevice, DeviceContextOptions.None);

                /// スワップチェインからBuffer0のサーフェイスを取得。
                var backBuffer = this.swapChain.GetBackBuffer<Surface>(0);

                var displayInfo = DisplayInformation.GetForCurrentView();

                this.d2dTarget = new Bitmap1(this.d2dDeviceContext, backBuffer, new BitmapProperties1(new PixelFormat(Format.B8G8R8A8_UNorm, SharpDX.Direct2D1.AlphaMode.Premultiplied), displayInfo.LogicalDpi
                    , displayInfo.LogicalDpi, BitmapOptions.Target | BitmapOptions.CannotDraw));


                /* 様々な初期化処理を以下に書く */

            }

            public void SetWindow(CoreWindow window)
            {
                Debug.WriteLine("SetWindow: " + window);

                this.mWindow = window;
            }

            public void Load(string entryPoint)
            {
                Debug.WriteLine("Load: " + entryPoint);

                this.CreateDeviceResources();
            }

            public void Run()
            {
                Debug.WriteLine("Run");


                while (true)
                {

                    this.mWindow.Dispatcher.ProcessEvents(CoreProcessEventsOption.ProcessAllIfPresent);

                    /* 入力受付処理を以下に記述する */

                    /* 入力受付処理はここまで */

                    /* 状態更新処理を以下に記述する */

                    /* 状態更新処理はここまで */

                    this.d2dDeviceContext.Target = d2dTarget;

                    this.d2dDeviceContext.BeginDraw();
                    this.d2dDeviceContext.Clear(Color.CornflowerBlue);

                    /* 描画処理を以下に記述する */

                    /* 描画処理はここまで */

                    this.d2dDeviceContext.EndDraw();

                    //現在のバッファをスクリーンに表示させる。
                    //syncInterval: フレームの同期方法、0(ブランク挟まず同期なしで表示)、1~4(nの垂直ブランクを挟んで同期させて表示)
                    this.swapChain.Present(0, PresentFlags.None);

                    /* 以下にプログラムの待機処理を記述する */
                }
            }

            public void Uninitialize()
            {
                Debug.WriteLine("Uninitialize");
                this.swapChain.Dispose();
                this.d2dDeviceContext.Dispose();
                this.d2dTarget.Dispose();

            }
        }
    }
}
