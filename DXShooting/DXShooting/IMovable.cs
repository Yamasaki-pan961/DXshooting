using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXShooting
{
    /// <summary>
    /// 移動できる対象であることを表すインタフェース。
    /// </summary>
    public interface IMovable
    {
        /// <summary>
        /// 自身を指定した移動量動かす。
        /// </summary>
        /// <param name="dy">Y軸方向の移動量</param>
        /// <param name="dx">X軸方向の移動量</param>
        void Move(int dy, int dx);

        /// <summary>
        /// 自身を指定した座標に動かす。
        /// </summary>
        /// <param name="y">動かす座標のY座標</param>
        /// <param name="x">動かす座標のX座標</param>
        void SetPosition(int y, int x);

        /// <summary>
        /// 自身をこれ以上動かすことができるか判定する。
        /// </summary>
        /// <returns>動かすことができればtrue、動かすことができなければfalse</returns>
        bool IsMovable();
    }
}
