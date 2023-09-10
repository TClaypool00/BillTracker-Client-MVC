using Microsoft.EntityFrameworkCore;
using System;

namespace BillTrackerClient.App.DataModels
{
    public partial class BillTrackerContext : DbContext
    {
        public BillTrackerContext()
        {
        }

        public BillTrackerContext(DbContextOptions<BillTrackerContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(SecretConfig.ConnectionString, new MySqlServerVersion(new Version(8, 0, 29)));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
