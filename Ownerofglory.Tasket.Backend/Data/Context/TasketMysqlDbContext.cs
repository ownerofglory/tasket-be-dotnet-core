using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Ownerofglory.Tasket.Backend.Data.Model;

namespace Ownerofglory.Tasket.Backend.Data.Context
{
    public class TasketMysqlDbContext : DbContext
    {
        private readonly IConfiguration _config;

        public TasketMysqlDbContext(IConfiguration config)
        {
            _config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _config.GetSection("Data:Mysql:ConnectionString").Value;

            optionsBuilder.UseMySQL(connectionString);
            optionsBuilder.EnableSensitiveDataLogging(true);
        }

        protected internal virtual void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().ToTable("T_USER");
            modelBuilder.Entity<Space>().ToTable("T_SPACE");
            modelBuilder.Entity<Space>().Property(s => s.User).HasColumnName("userid");
            modelBuilder.Entity<TaskList>().ToTable("T_TASKLIST");
            modelBuilder.Entity<TaskList>().Property(tl => tl.Space).HasColumnName("spaceid");
            modelBuilder.Entity<Task>().ToTable("T_TASK");
            modelBuilder.Entity<Task>().Property(t => t.TaskList).HasColumnName("tasklistid");
            //map other properties too    
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Space> Spaces { get; set; }
        public DbSet<TaskList> TaskLists { get; set; }
        public DbSet<Task> Tasks { get; set; }
    }
}
