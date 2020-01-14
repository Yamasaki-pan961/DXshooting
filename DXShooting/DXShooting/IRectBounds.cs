
namespace DXShooting
{
    /// <summary>
    /// 四角形の領域を表すインタフェース。
    /// </summary>
    public interface IRectBounds
    {
        /// <summary>
        /// 四角形領域の右上の頂点のX座標を返す。
        /// </summary>
        /// <returns>右上頂点のX座標値。</returns>
        int GetNorthEastX();
        /// <summary>
        /// 四角形領域の右上の頂点のY座標を返す。
        /// </summary>
        /// <returns>右上頂点のY座標値。</returns>
        int GetNorthEastY();
        /// <summary>
        /// 四角形領域の左下の頂点のX座標を返す。
        /// </summary>
        /// <returns>右上頂点のX座標値。</returns>
        int GetSouthWestX();
        /// <summary>
        /// 四角形領域の左下の頂点のY座標を返す。
        /// <returns>左下頂点のY座標値。</returns>
        int GetSouthWestY();
    }
}
