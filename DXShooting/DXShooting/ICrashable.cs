
namespace DXShooting
{
    /// <summary>
    /// 壊れる機能を実現するインタフェース。
    /// </summary>
    public interface ICrashable
    {
        /// <summary>
        /// 自身を壊す。
        /// </summary>
        void Crash();
        /// <summary>
        /// 壊れる過程が終了したかどうか判定する。
        /// </summary>
        /// <returns>終了しているならばtrue、そうでなければfalse。</returns>
        bool IsFinished();
        /// <summary>
        /// 壊れる過程が進行中かどうか判定する。
        /// </summary>
        /// <returns>進行中ならばtrue、そうでなければfalse。</returns>
        bool IsCrashing();
    }
}
