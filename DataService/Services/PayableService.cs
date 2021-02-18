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
    public class PayableService : IPayableService
    {
        private readonly POS_DBContext _context;
        private readonly IMapper _mapper;
        private ServiceResponse<object> _serviceResponse;
        public  PayableService(IMapper mapper)
        {
            _context = new POS_DBContext();
            _mapper = mapper;
            _serviceResponse = new ServiceResponse<object>();
        }

        public async Task<ServiceResponse<object>> Create(PayableForCreateVM model)
        {
            var objToCreate = _mapper.Map<Payables>(model);
            objToCreate.CreatedAt = DateTime.Now;
            objToCreate.CreatedBy = 1;

            await _context.Payables.AddAsync(objToCreate);
            await _context.SaveChangesAsync();
            _serviceResponse.Success = true;
            _serviceResponse.Message = ResponseMessage.Added;
            return _serviceResponse;
        }

        public async Task<ServiceResponse<object>> Delete(int id)
        {
            var objToDelete = await _context.Payables.FindAsync(id);
            _context.Payables.Update(objToDelete);
            await _context.SaveChangesAsync();
            _serviceResponse.Success = true;
            _serviceResponse.Message = ResponseMessage.Deleted;
            return _serviceResponse;
        }

        public async Task<ServiceResponse<IEnumerable<PayableForListVM>>> GetAll()
        {
            ServiceResponse<IEnumerable<PayableForListVM>> serviceResponse = new ServiceResponse<IEnumerable<PayableForListVM>>();
            var returnlist = await _context.Payables.Select(p => new PayableForListVM
            {
                Id=p.Id,
                PurchaseOrderId=p.PurchaseOrderId,
                SupplierId=p.SupplierId,
                Amount =p.Amount,
            }).ToListAsync();
            serviceResponse.Success = true;
            serviceResponse.Data = returnlist;
            return serviceResponse;
        }

        public async Task<ServiceResponse<PayableForDetailsVM>> GetById(int id)
        {
            ServiceResponse<PayableForDetailsVM> serviceResponse = new ServiceResponse<PayableForDetailsVM>();
            var detailobj = await _context.Payables.Select(p => new PayableForDetailsVM
            {
                Id = p.Id,
                PurchaseOrderId = p.PurchaseOrderId,
                SupplierId = p.SupplierId,
                Amount = p.Amount,
            }).FirstOrDefaultAsync();
            serviceResponse.Success = true;
            serviceResponse.Data = detailobj;
            return serviceResponse;
        }

        public async Task<ServiceResponse<object>> Update(int id, PayableForUpdateVM model)
        {
            var updateobj = _mapper.Map<Payables>(model);
            _context.Payables.Update(updateobj);
            await _context.SaveChangesAsync();
            _serviceResponse.Success = true;
            _serviceResponse.Message = ResponseMessage.Updated;
            return _serviceResponse;
        }
    }
}
