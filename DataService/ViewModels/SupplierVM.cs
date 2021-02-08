using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointOfSale.DataService.ViewModels
{
    public class SupplierVM
    {
    }
    public class SupplierForCreateVM
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
    public class SupplierForUpdateVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public bool Active { get; set; } = true;
    }
    public class SupplierForListVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
    public class SupplierForDetailsVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
