﻿using System;
using System.Collections.Generic;

namespace PointOfSale.DatabaseService
{
    public partial class SaleOrders
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public DateTime? OrderDate { get; set; }
        public string Status { get; set; }
        public double? TotalAmount { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
