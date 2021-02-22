using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointOfSale.DataService.ViewModels
{
    public class PurchaseOrderDetailVM
    {
    }
    public class PurchaseOrderDetailForCreateVM
    {
        public int PurchaseOrderId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public double UnitRate { get; set; }
        public double Amount { get; set; }
        public int Discount { get; set; }
        public int UomId { get; set; }
        public string Description { get; set; }
    }
    public class PurchaseOrderDetailForUpdateVM
    {
        public int Id { get; set; }
        public int PurchaseOrderId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public double UnitRate { get; set; }
        public double Amount { get; set; }
        public int Discount { get; set; }
        public int UomId { get; set; }
        public string Description { get; set; }
    }
    public class PurchaseOrderDetailForListVM
    {
        public int Id { get; set; }
        public int PurchaseOrderId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public double UnitRate { get; set; }
        public double Amount { get; set; }
        public int Discount { get; set; }
        public int UomId { get; set; }
        public string Description { get; set; }
    }
    public class PurchaseOrderDetailForDetailVM
    {
        public int Id { get; set; }
        public int PurchaseOrderId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public double UnitRate { get; set; }
        public double Amount { get; set; }
        public int Discount { get; set; }
        public int UomId { get; set; }
        public string Description { get; set; }
    }

}
