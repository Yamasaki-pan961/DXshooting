
namespace DXShooting
{
    /// <summary>
    /// 内部の状態を元に更新する役割を表すインタフェース
    /// </summary>
    public interface IUpdatable
    {
        /// <summary>
        /// 内部の状態を元に自身を更新する。
        /// </summary>
        void Update();
    }
}
