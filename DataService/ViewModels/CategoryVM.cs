using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointOfSale.DataService.ViewModels
{
    public class CategoryVM
    {
        public string Label { get; set; }
        public string Code { get; set; }
        public int? ParentCategoryId { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public bool? Active { get; set; }
    }
}
