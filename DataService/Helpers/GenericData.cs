using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointOfSale.DataService.Helpers
{
    public class GenericData
    {
    }
    public static class HeadingModel
    {
        public static string Heading { get; set; }
        public static string SetHeading(string heading)
        {
            return Heading = heading;
        }
    }
   
}
