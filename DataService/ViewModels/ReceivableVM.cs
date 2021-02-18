using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointOfSale.DataService.ViewModels
{
    public class ReceivableVM
    {
    }
    public class ReceivableForCreateVM
    {
        public int SaleOrderId { get; set; }
        public int CustomerId { get; set; }
        public double Amount { get; set; }
    }
    public class ReceivableForUpdateVM
    {
        public int Id { get; set; }
        public int SaleOrderId { get; set; }
        public int CustomerId { get; set; }
        public double Amount { get; set; }
    }
    public class ReceivableForListVM
    {
        public int Id { get; set; }
        public int SaleOrderId { get; set; }
        public int CustomerId { get; set; }
        public double Amount { get; set; }
    }
    public class ReceivableForDetailsVM
    {
        public int Id { get; set; }
        public int SaleOrderId { get; set; }
        public int CustomerId { get; set; }
        public double Amount { get; set; }
    }
}
