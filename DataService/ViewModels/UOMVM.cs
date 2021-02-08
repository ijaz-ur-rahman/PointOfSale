using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointOfSale.DataService.ViewModels
{
    public class UOMVM
    {
    }
    public class UOMForCreateVM
    {
        public string Unit { get; set; }
        public string Weight { get; set; }
        public string SiUnit { get; set; }
    }
    public class UOMForListVM
    {
        public int Id { get; set; }
        public string Unit { get; set; }
        public string Weight { get; set; }
        public string SiUnit { get; set; }
    }
    public class UOMForUpdateVM
    {
        public int Id { get; set; }
        public string Unit { get; set; }
        public string Weight { get; set; }
        public string SiUnit { get; set; }
    }
    public class UOMForDetailVM
    {
        public int Id { get; set; }
        public string Unit { get; set; }
        public string Weight { get; set; }
        public string SiUnit { get; set; }
    }
}
