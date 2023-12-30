namespace EFCore.Entities
{
    public class Department
    {
        // Айди кафедры, на него ссылается поле Department из класса Teacher
        public int Id { get; set; }
        // Название кафедры
        public string Name { get; set; }
    }
}
