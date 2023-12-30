using EFCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCore
{
    public class AppDbContext : DbContext
    {
        // Класс Teacher будет выступать в роли таблицы под название Teachers
        public DbSet<Teacher> Teachers { get; set; }
        // Класс Department будет выступать в роли таблицы под название Departments
        public DbSet<Department> Departments { get; set; }

        public AppDbContext()
        {
            // Проверка базы данных на существование
            Database.EnsureCreated();
        }
        // Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Отключение автоматического заполнения Id у таблицы Department
            modelBuilder.Entity<Department>().Property(e => e.Id).ValueGeneratedNever();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Строка подключения к базе данных
            optionsBuilder.UseSqlServer("Server=localhost;Database=University;Trusted_Connection=True;Encrypt=False;");
        }
    }
}
