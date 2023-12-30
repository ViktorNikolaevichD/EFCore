using EFCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCore
{
    public class AppDbContext : DbContext
    {
        // Класс Teacher будет выступать в роли таблицы под название Teachers
        public DbSet<Teacher> Techers { get; set; }
        // Класс Department будет выступать в роли таблицы под название Departments
        public DbSet<Department> Departments { get; set; }

        public AppDbContext()
        {
            // Проверка базы данных на существование
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Строка подключения к базе данных
            optionsBuilder.UseSqlServer("Server=localhost;Database=University;Trusted_Connection=True;Encrypt=False;");
        }
    }
}
