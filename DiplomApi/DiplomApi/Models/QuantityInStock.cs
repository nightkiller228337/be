using System;
using System.Collections.Generic;

namespace DiplomApi.Models
{
    public partial class QuantityInStock
    {
        public int IdProduct { get; set; }
        public int IdStorage { get; set; }
        public int Quantity { get; set; }

        public virtual Product IdProductNavigation { get; set; } = null!;
        public virtual Storage IdStorageNavigation { get; set; } = null!;
    }
}
