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
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserConfig> UserConfig { get; set; }
        public DbSet<UserRoleRelation> UserRoleRelations { get; set; }
        public LunaDbContext()
            : base("LunaConnection")
        {
            Database.CreateIfNotExists();
        }
            
    }
}
