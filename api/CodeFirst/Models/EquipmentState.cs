using System;
using System.Collections.Generic;

namespace CodeFirst.Models
{
    public partial class EquipmentState
    {
        public EquipmentState()
        {
            EquipmentRecords = new HashSet<EquipmentRecord>();
        }

        public int StateId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<EquipmentRecord> EquipmentRecords { get; set; }
    }
}
