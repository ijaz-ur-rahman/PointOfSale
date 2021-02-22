using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointOfSale.DataService.ViewModels
{
    public class PurchaseOrderVM
    {
    }
    public class PurchaseOrderForCreateVM
    {
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public int SupplierId { get; set; }
        public double TotalAmount { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        List<PurchaseOrderDetailForCreateVM> OrderDetails = new List<PurchaseOrderDetailForCreateVM>();
    }
    public class PurchaseOrderForListVM
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public int SupplierId { get; set; }
        public double TotalAmount { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        List<PurchaseOrderDetailForCreateVM> OrderDetails = new List<PurchaseOrderDetailForCreateVM>();
    }
    public class PurchaseOrderForDetailVM
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public int SupplierId { get; set; }
        public double TotalAmount { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        List<PurchaseOrderDetailForCreateVM> OrderDetails = new List<PurchaseOrderDetailForCreateVM>();
    }
    public class PurchaseOrderForUpdateVM
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public int SupplierId { get; set; }
        public double TotalAmount { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
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
