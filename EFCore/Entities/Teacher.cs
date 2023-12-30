namespace EFCore.Entities
{
    public class Teacher
    {
        // Айди учителя, будет по умолчанию PrimaryKey
        public int Id { get; set; } // 1, 2, 3, 4, 5, 6
        // Имя учителя
        public string Name { get; set; }
        // Фамилия учителя
        public string Surname { get; set; } 
        // Айди департамента, нужно, чтобы вручную определить название столбца
        public int DepartmentId {  get; set; }
        // Кафедра, навигационное свойство, ссылающееся на Id кафедры
        public Department Department { get; set; }
    }
}
