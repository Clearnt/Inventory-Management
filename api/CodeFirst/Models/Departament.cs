using System;
using System.Collections.Generic;

namespace CodeFirst.Models
{
    public partial class Departament
    {
        public Departament()
        {
            Employees = new HashSet<Employee>();
            EquipmentRecords = new HashSet<EquipmentRecord>();
        }

        public int DepartamentId { get; set; }
        public string Name { get; set; } = null!;
        public int AddressId { get; set; }

        public virtual Address Address { get; set; } = null!;
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<EquipmentRecord> EquipmentRecords { get; set; }
    }
}
