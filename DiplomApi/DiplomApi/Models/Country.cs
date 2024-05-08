using System;
using System.Collections.Generic;

namespace DiplomApi.Models
{
    public partial class Country
    {
        public Country()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string CountryName { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; }
    }
}
