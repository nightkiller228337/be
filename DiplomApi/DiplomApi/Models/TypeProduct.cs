using System;
using System.Collections.Generic;

namespace DiplomApi.Models
{
    public partial class TypeProduct
    {
        public TypeProduct()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string TypeName { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; }
    }
}
