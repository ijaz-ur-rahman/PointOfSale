using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointOfSale.DataService.Helpers
{
    public class ResponseMessage
    {
        public const string Added = "Record added successfully";
        public const string Updated = "Record updated successfully";
        public const string Deleted = "Record Deleted successfully";
        public const string NotFound = "Record not found";
        public const string ErrorOccured = "Some Error Occured";
        public const string NotAuthorized = "You are not authorized to view";
        public const string NotExist = "Record does not exists";
    }
}
