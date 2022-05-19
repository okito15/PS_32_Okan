using System.Data.Entity;
namespace UserLogin
{
    class LogsContext : DbContext
    {
        public DbSet<Log> Logs { get; set; }
        public LogsContext()
: base(Properties.Settings.Default.DbConnect)
        { }
    }
}
