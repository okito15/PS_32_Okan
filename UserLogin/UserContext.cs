using System.Data.Entity;
namespace UserLogin
{
    class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public UserContext()
: base(Properties.Settings.Default.DbConnect)
        { }
    }
}
