using System;
using System.Collections.Generic;

namespace CodeFirst.Models
{
    public partial class Equipment
    {
        public Equipment()
        {
            EquipmentRecords = new HashSet<EquipmentRecord>();
        }

        public int EquipmentId { get; set; }
        public string Name { get; set; } = null!;
        public int TypeId { get; set; }

        public virtual EquipmentType Type { get; set; } = null!;
        public virtual ICollection<EquipmentRecord> EquipmentRecords { get; set; }
    }
}
