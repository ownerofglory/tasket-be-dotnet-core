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
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Space> Spaces { get; set; }
        public DbSet<TaskList> TaskLists { get; set; }
        public DbSet<Task> Tasks { get; set; }
    }
}
