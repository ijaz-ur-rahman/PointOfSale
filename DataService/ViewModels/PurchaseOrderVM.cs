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
    }
    public class PurchaseOrderFoerListVM
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public int SupplierId { get; set; }
        public double TotalAmount { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
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
}
