using System;
using System.Collections.Generic;

namespace PointOfSale
{
    public partial class PurchaseOrders
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public DateTime? OrderDate { get; set; }
        public int? SupplierId { get; set; }
        public double? TotalAmount { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
