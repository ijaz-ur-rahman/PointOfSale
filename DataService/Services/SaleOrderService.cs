using AutoMapper;
using PointOfSale.DatabaseService;
using Microsoft.EntityFrameworkCore;
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
    public class SaleOrderService : ISaleOrderService
    {
        private readonly POS_DBContext _context;
        private readonly IMapper _mapper;
        private ServiceResponse<object> _serviceResponse;
        public SaleOrderService(IMapper mapper)
        {
            _context = new POS_DBContext();
            _mapper = mapper;
            _serviceResponse = new ServiceResponse<object>();
        }
        public async Task<ServiceResponse<object>> Create(SaleOrderForCreateVM model)
        {
            var objToCreate = _mapper.Map<SaleOrders>(model);
            objToCreate.OrderDate = DateTime.Now;
            var lastOrder = await _context.SaleOrders.LastOrDefaultAsync();
            objToCreate.OrderNumber = DateTime.Now.ToShortDateString() + (lastOrder.Id + 1);
            objToCreate.CreatedAt = DateTime.Now;
            objToCreate.CreatedBy = 1;

            await _context.SaleOrders.AddAsync(objToCreate);
            await _context.SaveChangesAsync();

            foreach (var orderDetail in model.OrderDetails)
            {
                orderDetail.SaleOrdersId = objToCreate.Id;
                await _context.SaleOrderDetails.AddAsync(orderDetail);
                await _context.SaveChangesAsync();
            }
            _serviceResponse.Success = true;
            _serviceResponse.Message = ResponseMessage.Added;
            return _serviceResponse;
        }

        public async Task<ServiceResponse<object>> Delete(int id)
        {
            var objToDelete = await _context.SaleOrders.FindAsync(id);
            _context.SaleOrders.Remove(objToDelete);
            await _context.SaveChangesAsync();
            _serviceResponse.Success = true;
            _serviceResponse.Message = ResponseMessage.Deleted;
            return _serviceResponse;
        }

        public async Task<ServiceResponse<IEnumerable<SaleOrderForListVM>>> GetAll()
        {
            ServiceResponse<IEnumerable<SaleOrderForListVM>> serviceResponse = new ServiceResponse<IEnumerable<SaleOrderForListVM>>();

            var listToReturn = await _context.SaleOrders.Select(o => new SaleOrderForListVM
            {
                Id = o.Id,
                TotalAmount = o.TotalAmount,
                Description = o.Description,
                Status = o.Status,
                OrderDate = Convert.ToDateTime(o.OrderDate),
                OrderNumber = o.OrderNumber
            }).ToListAsync();
            serviceResponse.Success = true;
            serviceResponse.Data = listToReturn;
            return serviceResponse;
        }

        public async Task<ServiceResponse<SaleOrderForDetailsVM>> GetById(int id)
        {
            ServiceResponse<SaleOrderForDetailsVM> serviceResponse = new ServiceResponse<SaleOrderForDetailsVM>();

            var ToReturn = await _context.SaleOrders.Where(m => m.Id == id).Select(o => new SaleOrderForDetailsVM
            {
                Id = o.Id,
                TotalAmount = o.TotalAmount,
                Description = o.Description,
                Status = o.Status,
                OrderDate = Convert.ToDateTime(o.OrderDate),
                OrderNumber = o.OrderNumber
            }).FirstOrDefaultAsync();
            serviceResponse.Success = true;
            serviceResponse.Data = ToReturn;
            return serviceResponse;
        }

        public async Task<ServiceResponse<object>> GetItemDetails(int id)
        {
            var detailsObj = await _context.Items.Where(m => m.Id == id).FirstOrDefaultAsync();
            var toReturn = _mapper.Map<ItemForDetailsVM>(detailsObj);
            _serviceResponse.Success = true;
            _serviceResponse.Data = toReturn;
            return _serviceResponse;
        }

        public async Task<ServiceResponse<object>> Update(int id, SaleOrderForUpdateVM model)
        {
            var objToUpdate = _mapper.Map<SaleOrders>(model);
            objToUpdate.UpdatedAt = DateTime.Now;
            objToUpdate.UpdatedBy = 1;
            _context.SaleOrders.Update(objToUpdate);
            await _context.SaveChangesAsync();
            _serviceResponse.Success = true;
            _serviceResponse.Message = ResponseMessage.Updated;
            return _serviceResponse;
        }

    }
}
