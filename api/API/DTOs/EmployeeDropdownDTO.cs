using CodeFirst.Models;

namespace API.DTOs
{
    public class EmployeeDropdownDTO
    {
        public EmployeeDropdownDTO() { }

        public EmployeeDropdownDTO(Employee employee)
        {
            Id = employee.EmployeeId;
            Name = employee.Surname + " " + employee.Name;
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
