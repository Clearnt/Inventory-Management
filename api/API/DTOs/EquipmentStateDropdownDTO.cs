using CodeFirst.Models;

namespace API.DTOs
{
    public class EquipmentStateDropdownDTO
    {
        public EquipmentStateDropdownDTO() { }

        public EquipmentStateDropdownDTO(EquipmentState equipmentState)
        {
            Id = equipmentState.StateId;
            Name = equipmentState.Name;
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
