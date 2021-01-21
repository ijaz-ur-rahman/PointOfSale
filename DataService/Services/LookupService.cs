using DatabaseService;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        private ServiceResponse<object> _serviceResponse;
        public LookupService()
        {
            _context = new POS_DBContext();
            _serviceResponse = new ServiceResponse<object>();
        }
        public async Task<ServiceResponse<object>> RolesDrp(object SelectedValue)
        {
            var list = await _context.Roles.ToListAsync();
            SelectList items = new SelectList(list, nameof(Categories.Id), nameof(Categories.Label), SelectedValue);
            _serviceResponse.Success = true;
            _serviceResponse.Data = items;
            return _serviceResponse;
        }
        public async Task<ServiceResponse<object>> CategoriesDrp(object SelectedValue)
        {
            var list = await _context.Categories.ToListAsync();
            SelectList items = new SelectList(list, nameof(Categories.Id), nameof(Categories.Label), SelectedValue);
            _serviceResponse.Success = true;
            _serviceResponse.Data = items;
            return _serviceResponse;
        }
        public async Task<ServiceResponse<object>> UOMDrp(object SelectedValue)
        {
            var list = await _context.UnitOfMeasurement.ToListAsync();
            SelectList items = new SelectList(list, nameof(UnitOfMeasurement.Id), nameof(UnitOfMeasurement.Unit), SelectedValue);
            _serviceResponse.Success = true;
            _serviceResponse.Data = items;
            return _serviceResponse;
        }
    }
}
