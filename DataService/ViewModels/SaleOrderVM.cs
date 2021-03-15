using PointOfSale.DatabaseService;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PointOfSale.DataService.ViewModels
{
    public class SaleOrderVM
    {

    }
    public class SaleOrderForCreateVM
    {
        //[Required]
        //public string OrderNumber { get; set; }
        //public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public string TotalAmount { get; set; }
        //public string Description { get; set; }
        public List<SaleOrderDetailForCreateVM> OrderDetails { get; set; } = new List<SaleOrderDetailForCreateVM>();
    }
    public class SaleOrderForUpdateVM
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public double? TotalAmount { get; set; }
        public string Description { get; set; }
    }
    public class SaleOrderForListVM
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public double? TotalAmount { get; set; }
        public string Description { get; set; }
        public List<SaleOrderDetails> OrderDetails { get; set; } = new List<SaleOrderDetails>();

    }
    public class SaleOrderForDetailsVM
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public double? TotalAmount { get; set; }
        public string Description { get; set; }
        public List<SaleOrderDetails> OrderDetails { get; set; } = new List<SaleOrderDetails>();

    }
    public class SaleOrderDetailForCreateVM
    {
        //[Required]
        public int SaleOrdersId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public double UnitRate { get; set; }
        public double Amount { get; set; }
        public int UomId { get; set; }
    }
    public class SaleOrderDetailForUpdateVM
    {
        public int Id { get; set; }
        public int SaleOrdersId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public double UnitRate { get; set; }
        public double Amount { get; set; }
        public int UomId { get; set; }
    }
    public class SaleOrderDetailForListVM
    {
        public int Id { get; set; }
        public int SaleOrdersId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public double UnitRate { get; set; }
        public double Amount { get; set; }
        public int UomId { get; set; }

    }
    public class SaleOrderDetailForDetailsVM
    {
        public int Id { get; set; }
        public int SaleOrdersId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public double UnitRate { get; set; }
        public double Amount { get; set; }
        public int UomId { get; set; }
    }
}
