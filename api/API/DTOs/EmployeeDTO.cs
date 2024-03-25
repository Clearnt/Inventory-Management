using CodeFirst.Models;

namespace API.DTOs
{
    public class EmployeeDTO
    {
        public EmployeeDTO() { }

        public EmployeeDTO(Employee employee)
        {
            Id = employee.EmployeeId;
            Surname = employee.Surname;
            Name = employee.Name;
            Position = employee.Position;
            DepartamentId = employee.DepartamentId;
        }

        public int Id { get; set; }
        public string Surname { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Position { get; set; } = null!;
        public int DepartamentId { get; set; }

        public Employee GetEmployee()
        {
            return new Employee()
            {
                EmployeeId = Id,
                Surname = Surname,
                Name = Name,
                Position = Position,
                DepartamentId = DepartamentId
            };
        }

        public void UpdateEmployee(Employee employee)
        {
            employee.EmployeeId = Id;
            employee.Surname = Surname;
            employee.Name = Name;
            employee.Position = Position;
            employee.DepartamentId = DepartamentId;
        }
    }
}
