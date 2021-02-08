using System;
using System.Collections.Generic;

namespace PointOfSale.DatabaseService
{
    public partial class Receivables
    {
        public int Id { get; set; }
        public int SaleOrderId { get; set; }
        public int CustomerId { get; set; }
        public double Amount { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
