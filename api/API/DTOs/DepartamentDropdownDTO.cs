using CodeFirst.Models;

namespace API.DTOs
{
    public class DepartamentDropdownDTO
    {
        public DepartamentDropdownDTO() { }

        public DepartamentDropdownDTO(Departament departament)
        {
            Id = departament.DepartamentId;
            Name = departament.Name;
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
