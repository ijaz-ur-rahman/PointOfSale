using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointOfSale.DataService.ViewModels
{
    public class PayableVM
    {
    }
    public class PayableForCreateVM
    {
        public int PurchaseOrderId { get; set; }
        public int SupplierId { get; set; }
        public double Amount { get; set; }
    }
    public class PayableForUpdateVM
    {
        public int Id { get; set; }
        public int PurchaseOrderId { get; set; }
        public int SupplierId { get; set; }
        public double Amount { get; set; }
    }
    public class PayableForListVM
    {
        public int Id { get; set; }
        public int PurchaseOrderId { get; set; }
        public int SupplierId { get; set; }
        public double Amount { get; set; }
    }
    public class PayableForDetailsVM
    {
        public int Id { get; set; }
        public int PurchaseOrderId { get; set; }
        public int SupplierId { get; set; }
        public double Amount { get; set; }
    }
}
