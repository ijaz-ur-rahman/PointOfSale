using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PointOfSale.DatabaseService;
using PointOfSale.DatabaseService.DBContext;
using PointOfSale.DataService.Helpers;
using PointOfSale.DataService.IServices;
using PointOfSale.DataService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointOfSale.DataService.Services
{
    public class PurchaseOrderService : IPurchaseOrderService
    {
        private readonly POS_DBContext _context;
        private readonly IMapper _mapper;
        private ServiceResponse<object> _serviceResponse;
        public PurchaseOrderService(IMapper mapper)
        {
            _context = new POS_DBContext();
            _mapper = mapper;
            _serviceResponse = new ServiceResponse<object>();
        }
        public async Task<ServiceResponse<object>> Create(PurchaseOrderForCreateVM model)
        {
            var objforcreate = _mapper.Map<PurchaseOrders>(model);
            objforcreate.CreatedAt = DateTime.Now;
            objforcreate.CreatedBy = 1;

            await _context.PurchaseOrders.AddAsync(objforcreate);
            await _context.SaveChangesAsync();
            _serviceResponse.Success = true;
            _serviceResponse.Message = ResponseMessage.Added;
            return _serviceResponse;
        }

        public async Task<ServiceResponse<object>> Delete(int id)
        {
            var objfordel = await _context.PurchaseOrders.FindAsync(id);
            _context.PurchaseOrders.Update(objfordel);
            await _context.SaveChangesAsync();
            _serviceResponse.Success = true;
            _serviceResponse.Message = ResponseMessage.Deleted;
            return _serviceResponse;

        }

        public async Task<ServiceResponse<IEnumerable<PurchaseOrderForListVM>>> GetAll()
        {
            ServiceResponse<IEnumerable<PurchaseOrderForListVM>> serviceResponse = new ServiceResponse<IEnumerable<PurchaseOrderForListVM>>();
            var objforlist = await _context.PurchaseOrders.Select(p => new PurchaseOrderForListVM
            {
                Id = p.Id,
                OrderNumber = p.OrderNumber,
                OrderDate = Convert.ToDateTime(p.OrderDate),
                SupplierId = Convert.ToInt32(p.SupplierId),
                TotalAmount = Convert.ToDouble(p.TotalAmount),
                Status = p.Status,
                Description = p.Description,

            }).ToListAsync();
            serviceResponse.Success = true;
            serviceResponse.Data = objforlist;
            return serviceResponse;
        }

        public async Task<ServiceResponse<PurchaseOrderForDetailVM>> GetById(int id)
        {
            ServiceResponse<PurchaseOrderForDetailVM> serviceResponse = new ServiceResponse<PurchaseOrderForDetailVM>();
            var objfordetail = await _context.PurchaseOrders.Select(p => new PurchaseOrderForDetailVM
            {
                Id = p.Id,
                OrderNumber = p.OrderNumber,
                OrderDate = Convert.ToDateTime(p.OrderDate),
                SupplierId = Convert.ToInt32(p.SupplierId),
                TotalAmount = Convert.ToDouble(p.TotalAmount),
                Status = p.Status,
                Description = p.Description,

            }).FirstOrDefaultAsync();
            serviceResponse.Success = true;
            serviceResponse.Data = objfordetail;
            return serviceResponse;
        }

        public async Task<ServiceResponse<object>> Update(int id, PurchaseOrderForUpdateVM model)
        {
            var objforupdate = _mapper.Map<PurchaseOrders>(model);
            _context.PurchaseOrders.Remove(objforupdate);
            await _context.SaveChangesAsync();
            _serviceResponse.Success = true;
            _serviceResponse.Message = ResponseMessage.Updated;
            return _serviceResponse;
        }
    }
}
