using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirst.Models
{
    public partial class EquipmentRecord
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EquipmentRecordId { get; set; }
        public int EquipmentId { get; set; }
        public string? AccountingCode { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal Cost { get; set; }
        public int? OwnerEmployeeId { get; set; }
        public int? OwnerDepartamentId { get; set; }
        public int StateId { get; set; }

        public virtual Equipment Equipment { get; set; } = null!;
        public virtual Departament? OwnerDepartament { get; set; }
        public virtual Employee? OwnerEmployee { get; set; }
        public virtual EquipmentState State { get; set; } = null!;
    }
}
