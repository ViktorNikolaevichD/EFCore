using EFCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCore
{
    public class Commands
    {
        // Добавление строчек в таблицу Departments
        public static void AddDepartment()
        {
            // Строчки для добавления в таблицу
            Department depString1 = new Department { Id = 1, Name = "Название кафедры 1" };
            Department depString2 = new Department { Id = 2, Name = "Название кафедры 2" };
            // Подключение к базе данных через класс AppDbContext
            using (AppDbContext db = new AppDbContext())
            {
                // Добавить в базу данных строчки depString{1, 2}
                db.Departments.AddRange(depString1, depString2);
                // Сохранить изменение в базе данных
                db.SaveChanges();
            }
        }
        // Добавление строчек в таблицу Teachers
        public static void AddTeacher()
        {
            // Строчки для добавления в таблицу
            Teacher teachString1 = new Teacher { Name = "Иван", Surname = "Иванов", DepartmentId = 1 };
            Teacher teachString2 = new Teacher { Name = "Петр", Surname = "Петров", DepartmentId = 1 };
            Teacher teachString3 = new Teacher { Name = "Василий", Surname = "Васильев", DepartmentId = 1 };
            Teacher teachString4 = new Teacher { Name = "Николай", Surname = "Николаев", DepartmentId = 2 };
            // Подключение к базе данных через класс AppDbContext
            using (AppDbContext db = new AppDbContext())
            {
                // Добавить в базу данных строчки teachString{1, 2, 3, 4}
                db.Teachers.AddRange(teachString1, teachString2, teachString3, teachString4);
                // Сохранить изменение в базе данных
                db.SaveChanges();
            }
        }
        // Удаление строк из базы данных
        public static void DelString()
        {
            using (AppDbContext db = new AppDbContext())
            {
                // Выбрать строчку для удаления
                Department depString = db.Departments.Where(p => p.Id == 1).First();
                // Удалить строчку из таблицы Departments
                db.Departments.Remove(depString);
                // Сохранить изменения в базе данных
                db.SaveChanges();
            }   
        }
        // Работа Count()
        public static void WriteCount()
        {
            using (AppDbContext db = new AppDbContext())
            {
                // Получить число строк в таблице Teachers
                int count = db.Teachers.Count();
                Console.WriteLine(count);
            }
        }
        // Работа ToList()
        public static void WriteList()
        {
            using (AppDbContext db = new AppDbContext())
            {
                var notList = db.Teachers;
                Console.WriteLine(notList);

                var List = db.Teachers.ToList();
                Console.WriteLine(List);
            }
        }
        // Работа Any()
        public static void WriteAny()
        {
            using (AppDbContext db = new AppDbContext())
            {
                if (db.Teachers.Any())
                    Console.WriteLine("В таблице преподавателей есть строки");
                else
                    Console.WriteLine("В таблице преподавателей нет ни одной строки");
            }
        }
        // Работы Include(), Skip(), Take()
        public static void JustFunc()
        {
            using (AppDbContext db = new AppDbContext())
            {
                List<Teacher> teachers = db.Teachers.Skip(1).Take(1).ToList();
                Console.WriteLine("Преподаватели без Include");
                foreach (var teacher in teachers)
                {
                    Console.WriteLine($"{teacher.Id} {teacher.Name} {teacher.Surname} {teacher.DepartmentId} " +
                        $"Кафедра {teacher.DepartmentId}");
                }

                List<Teacher> includeTeachers = db.Teachers.Skip(1).Take(1).Include(p => p.Department).ToList();
                Console.WriteLine("Преподаватели с Include");
                foreach (var teacher in includeTeachers)
                {
                    Console.WriteLine($"{teacher.Id} {teacher.Name} {teacher.Surname} {teacher.DepartmentId} " +
                        $"Кафедра {teacher.Department.Id} {teacher.Department.Name}");
                }
            }
        }
    }
}
