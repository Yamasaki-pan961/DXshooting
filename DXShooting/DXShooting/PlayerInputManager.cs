using Windows.System;
using Windows.UI.Core;

namespace DXShooting
{
    public class PlayerInputManager
    {
        private CoreWindow cWindow;
        private IShooter shooter;

        public PlayerInputManager(CoreWindow cWindow, IShooter shooter)
        {
            this.cWindow = cWindow;
            this.shooter = shooter;

        }
        /// <summary>
        /// 指定したキーが押されているかどうか判定する。
        /// </summary>
        /// <param name="key">指定するキー。</param>
        /// <returns>キーが押されていればtrue、押されていなければfalse。</returns>

        private bool CheckPressKey(VirtualKey key)
        {
            return (this.cWindow.GetAsyncKeyState(key) == CoreVirtualKeyStates.Down);
        }

        public void CheckInputs()
        {
            var dx = 0;
            var dy = 0;

            if (CheckPressKey(VirtualKey.Right))
            {
                dx = dx + 10;
            }
            if (CheckPressKey(VirtualKey.Left))
            {
                dx = dx - 10;
            }
            if (CheckPressKey(VirtualKey.Down))
            {
                dy = dy + 10;
            }
            if (CheckPressKey(VirtualKey.Up))
            {
                dy = dy - 10;
            }

            this.shooter.Move(dy, dx);

            if (CheckPressKey(VirtualKey.Space))
            {
                this.shooter.Fire();
            }
        }
    }
}
