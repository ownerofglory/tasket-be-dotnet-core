using System;
using Microsoft.EntityFrameworkCore;
using Ownerofglory.Tasket.Backend.Data.Model;

namespace Ownerofglory.Tasket.Backend.Data.Context
{
    public class TasketMysqlDbContext : DbContext
    {
        public TasketMysqlDbContext(DbContextOptions<TasketMysqlDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
