using PointOfSale.DatabaseService;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PointOfSale.DataService.ViewModels
{
    public class SaleVM
    {

    }
    public class SaleForCreateVM
    {
        //[Required]
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public double? TotalAmount { get; set; }
        public string Description { get; set; }
        public List<SaleOrderDetails> OrderDetails { get; set; } = new List<SaleOrderDetails>();
    }
    public class SaleForUpdateVM
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public double? TotalAmount { get; set; }
        public string Description { get; set; }
    }
    public class SaleForListVM
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public double? TotalAmount { get; set; }
        public string Description { get; set; }
        public List<SaleOrderDetails> OrderDetails { get; set; } = new List<SaleOrderDetails>();

    }
    public class SaleForDetailsVM
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public double? TotalAmount { get; set; }
        public string Description { get; set; }
        public List<SaleOrderDetails> OrderDetails { get; set; } = new List<SaleOrderDetails>();

    }
}
