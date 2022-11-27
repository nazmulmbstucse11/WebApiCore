using System.Collections.Generic;
using WebApiFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApiFirst.Repositories
{
    public class MainDBContext : DbContext
    {
        public DbSet<Task> TaskTable => Set<Task>();
        public DbSet<Person> PersonTable => Set<Person>();
        public DbSet<RequestLog> RequestTable => Set<RequestLog>();
        public DbSet<ExceptionLog> ExceptionTable => Set<ExceptionLog>();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Database=TestDB;Username=postgres;Password=1234");
    }
}
