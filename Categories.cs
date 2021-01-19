using System;
using System.Collections.Generic;

namespace PointOfSale
{
    public partial class Categories
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public string Code { get; set; }
        public int? ParentCategoryId { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public bool? Active { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
