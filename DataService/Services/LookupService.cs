using PointOfSale.DatabaseService;
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
            SelectList items = new SelectList(list, nameof(UnitOfMeasurement.Id), nameof(UnitOfMeasurement.Name), SelectedValue);
            _serviceResponse.Success = true;
            _serviceResponse.Data = items;
            return _serviceResponse;
        }
        public async Task<ServiceResponse<object>> PurchaseOrderDrp(object SelectedValue)
        {
            var list = await _context.PurchaseOrders.ToListAsync();
            SelectList items = new SelectList(list, nameof(PurchaseOrders.Id), nameof(PurchaseOrders.OrderNumber), SelectedValue);
            _serviceResponse.Success = true;
            _serviceResponse.Data = items;
            return _serviceResponse;
        }
        public async Task<ServiceResponse<object>> SupplierDrp(object SelectedValue)
        {
            var list = await _context.Suppliers.ToListAsync();
            SelectList items = new SelectList(list, nameof(Suppliers.Id), nameof(Suppliers.Name), SelectedValue);
            _serviceResponse.Success = true;
            _serviceResponse.Data = items;
            return _serviceResponse;
        }
        public async Task<ServiceResponse<object>> SaleOrderDrp(object SelectedValue)
        {
            var list = await _context.SaleOrders.ToListAsync();
            SelectList items = new SelectList(list, nameof(SaleOrders.Id), nameof(SaleOrders.OrderNumber), SelectedValue);
            _serviceResponse.Success = true;
            _serviceResponse.Data = items;
            return _serviceResponse;
        }
        public async Task<ServiceResponse<object>> ItemsDrp(object SelectedValue)
        {
            var list = await _context.Items.ToListAsync();
            SelectList items = new SelectList(list, nameof(Items.Id), nameof(Items.Label), SelectedValue);
            _serviceResponse.Success = true;
            _serviceResponse.Data = items;
            return _serviceResponse;
        }
        public async Task<ServiceResponse<object>> CustomerDrp(object SelectedValue)
        {
            var list = await _context.Customers.ToListAsync();
            SelectList items = new SelectList(list, nameof(Customers.Id), nameof(Customers.Name), SelectedValue);
            _serviceResponse.Success = true;
            _serviceResponse.Data = items;
            return _serviceResponse;
        }
    }
}
