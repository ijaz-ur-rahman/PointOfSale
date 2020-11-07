using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PointOfSale.DataService.Helpers;
using PointOfSale.DataService.IServices;

namespace PointOfSale.Controllers
{
    public class LookupsController : Controller
    {
        private readonly ILookupService _lookupService;
        private ServiceResponse _response;
        public LookupsController(ILookupService lookupService)
        {
            _lookupService = lookupService;
            _response = new ServiceResponse();
        }
        public async Task<IActionResult> RolesDrpAsync()
        {
            _response = await _lookupService.RolesDrp();
            return Ok(_response);
        }
    }
}
