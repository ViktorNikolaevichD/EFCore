using EFCore.Entities;

namespace EFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            string? commands = null;
            while (commands != "quit")
            {
                Console.Write(
                    "AddD," +
                    "\nAddT," +
                    "\nDel," +
                    "\nCount," +
                    "\nList," +
                    "\nAny," +
                    "\nSTI: ");
                commands = Console.ReadLine();
                switch (commands)
                {
                    case "AddD":
                        Console.WriteLine("Добавить строки в Dep");
                        Commands.AddDepartment();
                        break;
                    case "AddT":
                        Console.WriteLine("Добавить строки в Teach");
                        Commands.AddTeacher();
                        break;
                    case "Del":
                        Console.WriteLine("Удалить строки из Dep");
                        Commands.DelString();
                        break;
                    case "Count":
                        Console.WriteLine("Строк в таблице преподавателей");
                        Commands.WriteCount();
                        break;
                    case "List":
                        Console.WriteLine("Сравнение полученных типов");
                        Commands.WriteList();
                        break;
                    case "Any":
                        Commands.WriteAny();
                        break;
                    case "STI":
                        Commands.JustFunc();
                        break;
                    default:
                        Console.WriteLine("Неизвестная команда");
                        break;
                }
            }
        }
    }
}
