using Microsoft.EntityFrameworkCore;
using PointOfSale.DatabaseService.DBContext;
using PointOfSale.DataService.Helpers;
using PointOfSale.DataService.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointOfSale.DataService.Services
{
    public class LookupService : ILookupService
    {
        private readonly POS_DBContext _context;
        private ServiceResponse _serviceResponse;
        public LookupService()
        {
            _context = new POS_DBContext();
            _serviceResponse = new ServiceResponse();
        }
        public async Task<ServiceResponse> RolesDrp()
        {
            _serviceResponse.Data = await _context.Roles.ToListAsync();
            return _serviceResponse;
        }
    }
}
