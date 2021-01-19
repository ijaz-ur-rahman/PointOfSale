using System;
using System.Collections.Generic;

namespace PointOfSale
{
    public partial class Items
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public string Code { get; set; }
        public int? CategoryId { get; set; }
        public int? UomId { get; set; }
        public bool? Active { get; set; }
        public double? SalePrice { get; set; }
        public double? PurchasePrice { get; set; }
        public double? PricePerUnit { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
