
namespace DXShooting
{
    /// <summary>
    ///  当たり判定を表すインタフェース。
    /// </summary>
    public interface IHittable
    {
        /// <summary>
        /// 引数でわたされた矩形領域オブジェクトが、接触したかどうか判定する。
        /// </summary>
        /// <param name="c">判定する四角形領域。</param>
        /// <returns>渡された矩形領域が自身の領域と重なっていればtrue、そうでなければfalse。</returns>
        bool IsHitted(IRectBounds c);

    }
}
