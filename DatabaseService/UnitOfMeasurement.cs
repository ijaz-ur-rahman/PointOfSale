using System;
using System.Collections.Generic;

namespace PointOfSale.DatabaseService
{
    public partial class UnitOfMeasurement
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
    }
}
