using System;
using System.Collections.Generic;

namespace CodeFirst.Models
{
    public partial class Address
    {
        public Address()
        {
            Departaments = new HashSet<Departament>();
        }

        public int AddressId { get; set; }
        public string Address1 { get; set; } = null!;

        public virtual ICollection<Departament> Departaments { get; set; }
    }
}
