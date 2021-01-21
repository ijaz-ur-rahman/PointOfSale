using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointOfSale.DataService.ViewModels
{
    public class ItemVM
    {
    }
    public class ItemForCreateVM
    {
        //[Required]
        public string Label { get; set; }
        public string Code { get; set; }
        public string CategoryId { get; set; }
        public string UomId { get; set; }
        public string SalePrice { get; set; }
        public string PurchasePrice { get; set; }
        public string PricePerUnit { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
    public class ItemForUpdateVM
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public string Code { get; set; }
        public string CategoryId { get; set; }
        public string UomId { get; set; }
        public string SalePrice { get; set; }
        public string PurchasePrice { get; set; }
        public string PricePerUnit { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
    public class ItemForListVM
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public string Code { get; set; }
        public string CategoryId { get; set; }
        public string UomId { get; set; }
        public string SalePrice { get; set; }
        public string PurchasePrice { get; set; }
        public string PricePerUnit { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
    public class ItemForDetailsVM
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public string Code { get; set; }
        public string CategoryId { get; set; }
        public string UomId { get; set; }
        public string SalePrice { get; set; }
        public string PurchasePrice { get; set; }
        public string PricePerUnit { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
