namespace EFCore.Entities
{
    public class Teacher
    {
        // Айди учителя, будет по умолчанию PrimaryKey
        public int Id { get; set; }
        // Имя учителя
        public string Name { get; set; }
        // Фамилия учителя
        public string Surname { get; set; } 
        // Кафедра, навигационное свойство, ссылающееся на Id кафедры
        public Department Department { get; set; }
    }
}
