using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXShooting
{
    /// <summary>
    /// 射撃することができる対象であることを表すインタフェース。
    /// </summary>
    public interface IFirable
    {
        /// <summary>
        /// 射撃する。
        /// </summary>
        void Fire();
    }
}
