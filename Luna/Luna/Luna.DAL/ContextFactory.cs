using System.Data.Entity;
using System.Runtime.Remoting.Messaging;

namespace Luna.DAL
{
    /// <summary>
    /// 上下文简单工厂
    /// </summary>
    public class ContextFactory
    {
        /// <summary>
        /// 获取当前数据库上下文
        /// </summary>
        /// <returns></returns>
        public static LunaDbContext GetCurrentContext()
        {
            LunaDbContext _nContext = CallContext.GetData("LunaContext") as LunaDbContext;
            if (_nContext == null)
            {
                _nContext = new LunaDbContext();
                CallContext.SetData("LunaContext", _nContext);
            }
            return _nContext;
        }
    }
}
