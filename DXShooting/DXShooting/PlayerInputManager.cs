using Windows.System;
using Windows.UI.Core;

namespace DXShooting
{
    public class PlayerInputManager
    {
        private CoreWindow cWindow;
        private IMovable shooter;

        /// <summary>
        /// 指定したキーが押されているかどうか判定する。
        /// </summary>
        /// <param name="key">指定するキー。</param>
        /// <returns>キーが押されていればtrue、押されていなければfalse。</returns>
        private bool CheckPressKey(VirtualKey key)
        {
            return (this.cWindow.GetAsyncKeyState(key) == CoreVirtualKeyStates.Down);
        }
    }
}
