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
        public string Code { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
    }
    public class UOMForListVM
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
    }
    public class UOMForUpdateVM
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
    }
    public class UOMForDetailVM
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
    }
}
