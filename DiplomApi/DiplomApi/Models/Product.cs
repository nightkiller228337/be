using System;
using System.Collections.Generic;

namespace DiplomApi.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int QuantityInTotal { get; set; }
        public string Article { get; set; } = null!;
        public byte[]? Image { get; set; }
        public int ManufacturerId { get; set; }
        public int СountryId { get; set; }
        public int TypeId { get; set; }
        public decimal Price { get; set; }
        public string Code { get; set; } = null!;
        public string? Section { get; set; }

        public virtual Manufacturer Manufacturer { get; set; } = null!;
        public virtual TypeProduct Type { get; set; } = null!;
        public virtual Country Сountry { get; set; } = null!;
    }
}
