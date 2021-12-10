using System;
using Microsoft.EntityFrameworkCore;

namespace SCReport 
{
    public class HistoryContext : DbContext
    {
        public DbSet<History> History { get; set; }
        private string ConnectionString { get; set; }
        private string CONNECTION_STRING = "CONNECTION_STRING";

        public HistoryContext()
        { 
            string connectionString = Environment.GetEnvironmentVariable(CONNECTION_STRING, EnvironmentVariableTarget.User);
            ConnectionString = connectionString != null 
                ? connectionString 
                : throw new Exception("Переменная среды не оперделена.");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }

    [Keyless]
    public class History
    {
        public int PtId { get; set; } 
        public DateTime MDate { get; set; }
        public Single MValue { get; set; }
    }
}