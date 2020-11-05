using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace DataService
{
    public class Portfolio2ImdbContext : DbContext
    {
       
        public static readonly ILoggerFactory MyLoggerFactory
            = LoggerFactory.Create(builder => { builder.AddConsole(); });

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(MyLoggerFactory);

            //DATABASE CONNECT - LAD OS KØRE MED JSON.
            //optionsBuilder.UseNpgsql("host=;db=;uid=;pwd=");
            //optionsBuilder.UseNpgsql(_connectionString);
        }

        /*
        //Objects
        public DbSet<> Categories { get; set; }
        public DbSet<> Products { get; set; }
        public DbSet<> Orders { get; set; }
        public DbSet<> OrderDetail { get; set; }
        */

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}