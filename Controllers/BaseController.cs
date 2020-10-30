using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PointOfSale.Controllers
{
    public class BaseController : Controller
    {
        public string GetClaim(string name)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            return identity.FindFirst(name).Value;
        }
    }
}
