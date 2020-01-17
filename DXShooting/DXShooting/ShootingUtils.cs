using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXShooting
{
    /// <summary>
    /// 共通化できるメソッドをまとめたクラス
    /// </summary>
    public class ShootingUtils
    {
        /// <summary>
        /// 2つの四角形領域に交わっている箇所があるかどうか判定する。
        /// </summary>
        /// <param name="a">比較する四角領域a。</param>
        /// <param name="b">比較する四角領域b。</param>
        /// <returns>交わっている箇所があるならばtrue、そうでなければfalse。</returns>
        public static bool IsIntersected(IRectBounds a, IRectBounds b)
        {
            var uy = b.GetNorthEastY();
            var ux = b.GetNorthEastX();

            var dy = b.GetSouthWestY();
            var dx = b.GetSouthWestX();

            var northY = a.GetNorthEastY();
            var southY = a.GetSouthWestY();
            var westX = a.GetSouthWestX();
            var eastX = a.GetNorthEastX();

            if (ux >= westX && ux <= eastX && uy >= northY && uy <= southY
                || dx >= westX && dx <= eastX && uy >= northY && uy <= southY
                || ux >= westX && ux <= eastX && dy >= northY && dy <= southY
                || dx >= westX && dx <= eastX && dy >= northY && dy <= southY)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
