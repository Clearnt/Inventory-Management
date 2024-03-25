using CodeFirst.Models;

namespace API.DTOs
{
    public class EquipmentTypeDropdownDTO
    {
        public EquipmentTypeDropdownDTO() { }

        public EquipmentTypeDropdownDTO(EquipmentType equipmentType)
        {
            Id = equipmentType.TypeId;
            Name = equipmentType.Name;
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
