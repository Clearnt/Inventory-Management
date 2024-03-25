using System;
using System.Collections.Generic;

namespace CodeFirst.Models
{
    public partial class Employee
    {
        public Employee()
        {
            EquipmentRecords = new HashSet<EquipmentRecord>();
        }

        public int EmployeeId { get; set; }
        public string Surname { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Position { get; set; } = null!;
        public int DepartamentId { get; set; }

        public virtual Departament Departament { get; set; } = null!;
        public virtual ICollection<EquipmentRecord> EquipmentRecords { get; set; }
    }
}
