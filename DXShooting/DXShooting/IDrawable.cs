using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXShooting
{
    /// <summary>
    /// 画面に描画される対象であることを表すインタフェース。
    /// </summary>
    public interface IDrawable
    {
        /// <summary>
        /// 自身を描画する。
        /// </summary>
        void Draw();
    }
}
