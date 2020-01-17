
namespace DXShooting
{
    /// <summary>
    /// 移動可能な矩形物体であることを表すインタフェース。
    /// </summary>
    public interface IMovableRectTarget : ITarget, IRectBounds, IMovable
    {
        /// <summary>
        /// 1ステップ後の座標へ移動させる。
        /// </summary>
        void MoveNext();
        /// <summary>
        /// 中心座標(Y,X)のXを返却する。
        /// </summary>
        /// <returns>中心座標におけるX。</returns>
        int GetCenterX();
        /// <summary>
        /// 中心座標(Y,X)のYを返却する。
        /// </summary>
        /// <returns>中心座標におけるY。</returns>
        int GetCenterY();
    }
}
