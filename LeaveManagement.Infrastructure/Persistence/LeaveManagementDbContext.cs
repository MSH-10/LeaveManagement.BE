using LeaveManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagement.Infrastructure.Persistence
{
    public class LeaveManagementDbContext : DbContext
    {
        public LeaveManagementDbContext(DbContextOptions<LeaveManagementDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<LeaveApplication> LeaveApplications { get; set; }

        // Reference: https://medium.com/oppr/net-core-using-entity-framework-core-in-a-separate-project-e8636f9dc9e5
        public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<LeaveManagementDbContext>
        {
            public LeaveManagementDbContext CreateDbContext(string[] args)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile(@Directory.GetCurrentDirectory() + "/../LeaveManagement.API/appsettings.json")
                    .Build();
                var builder = new DbContextOptionsBuilder<LeaveManagementDbContext>();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                builder.UseSqlServer(connectionString);
                return new LeaveManagementDbContext(builder.Options);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationship between Users and LeaveApplications
            modelBuilder.Entity<LeaveApplication>()
                .HasOne(l => l.User)
                .WithMany(u => u.LeaveApplications)
                .HasForeignKey(l => l.ApplicantUserId)
                .OnDelete(DeleteBehavior.Restrict); // Or use other DeleteBehavior as needed

            // Configure other entity mappings and relationships
        }
        public Task<int> SaveChangesAsync()
        {
            var trackables = ChangeTracker.Entries<ITrackableEntities>();
            if (trackables != null)
            {
                // Added
                foreach (var item in trackables.Where(t => t.State == EntityState.Added))
                {
                    item.Entity.CreatedDateTime = DateTime.UtcNow;
                    //item.Entity.CreatedUserId = UserID
                    //item.Entity.ModifiedDateTime = DateTime.UtcNow;
                    //item.Entity.ModifiedUserId = UserId;
                }

                // Modified
                foreach (var item in trackables.Where(t => t.State == EntityState.Modified))
                {
                    item.Property(x => x.CreatedDateTime).IsModified = false;
                    item.Property(x => x.CreatedUserId).IsModified = false;
                    item.Entity.ModifiedDateTime = DateTime.UtcNow;
                    //item.Entity.ModifiedUserId = UserId;
                }
            }

            return SaveChangesAsync(default);
        }


    }
}   
