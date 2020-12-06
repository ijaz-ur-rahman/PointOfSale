using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointOfSale.DataService.ViewModels
{
    public class CategoryVM
    {

    }
    public class CategoryForCreateVM
    {
        public string Label { get; set; }
        public string Code { get; set; }
        public int? ParentCategoryId { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
    public class CategoryForUpdateVM
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public string Code { get; set; }
        public int? ParentCategoryId { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
    public class CategoryForListVM
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public string Code { get; set; }
        public int? ParentCategoryId { get; set; }
        public string ParentCategory { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
