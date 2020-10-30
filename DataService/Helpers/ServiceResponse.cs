using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointOfSale.DataService.Helpers
{
    public class ServiceResponse
    {
        public bool Success { get; set; }
        public object Data { get; set; }
        public string Message { get; set; }
    }
}
