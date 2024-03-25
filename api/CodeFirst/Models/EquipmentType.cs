using System;
using System.Collections.Generic;

namespace CodeFirst.Models
{
    public partial class EquipmentType
    {
        public EquipmentType()
        {
            Equipment = new HashSet<Equipment>();
            InverseParentType = new HashSet<EquipmentType>();
        }

        public int TypeId { get; set; }
        public string Name { get; set; } = null!;
        public int? ParentTypeId { get; set; }

        public virtual EquipmentType? ParentType { get; set; }
        public virtual ICollection<Equipment> Equipment { get; set; }
        public virtual ICollection<EquipmentType> InverseParentType { get; set; }
    }
}
