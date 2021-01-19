using System;
using System.Collections.Generic;

namespace PointOfSale
{
    public partial class PurchaseOrderDetails
    {
        public int Id { get; set; }
        public int? PurchaseOrdersId { get; set; }
        public int? ItemId { get; set; }
        public int? Quantity { get; set; }
        public double? UnitRate { get; set; }
        public double? Amount { get; set; }
        public int? Discount { get; set; }
        public int? UomId { get; set; }
        public string Description { get; set; }
    }
}
