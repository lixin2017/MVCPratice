using Luna.Models;
using System.Data.Entity;


namespace Luna.DAL
{
    /// <summary>
    /// 数据上下文
    /// </summary>
    public class LunaDbContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<UserConfig> UserConfig { get; set; }
        public LunaDbContext()
            : base("DefaultConnection")
        {

        }
            
    }
}
