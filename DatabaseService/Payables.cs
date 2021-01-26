using System;
using System.Collections.Generic;

namespace PointOfSale.DatabaseService
{
    public partial class Payables
    {
        public int Id { get; set; }
        public int PurchaseOrderId { get; set; }
        public int SupplierId { get; set; }
        public double Amount { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
    }
}
