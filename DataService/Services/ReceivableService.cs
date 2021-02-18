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
    public class ReceivableService : IReceivableService
    {
        private readonly POS_DBContext _context;
        private readonly IMapper _mapper;
        private ServiceResponse<object> _serviceResponse;
        public ReceivableService(IMapper mapper)
        {
            _context = new POS_DBContext();
            _mapper = mapper;
            _serviceResponse = new ServiceResponse<object>();
        }
        public async Task<ServiceResponse<object>> Create(ReceivableForCreateVM model)
        {
            var createobj = _mapper.Map<Receivables>(model);
            createobj.CreatedAt = DateTime.Now;
            createobj.CreatedBy = 1;

            await _context.Receivables.AddAsync(createobj);
            await _context.SaveChangesAsync();
            _serviceResponse.Success = true;
            _serviceResponse.Message = ResponseMessage.Added;
            return _serviceResponse;

        }

        public async Task<ServiceResponse<object>> Delete(int id)
        {
            var objfordelete = await _context.Receivables.FindAsync(id);
            _context.Receivables.Update(objfordelete);
            await _context.SaveChangesAsync();
            _serviceResponse.Success = true;
            _serviceResponse.Message = ResponseMessage.Deleted;
            return _serviceResponse;
        }

        public async Task<ServiceResponse<IEnumerable<ReceivableForListVM>>> GetAll()
        {
            ServiceResponse<IEnumerable<ReceivableForListVM>> serviceResponse = new ServiceResponse<IEnumerable<ReceivableForListVM>>();
            var returnlist = await _context.Receivables.Select(R => new ReceivableForListVM
            {
                Id = R.Id,
                SaleOrderId = R.SaleOrderId,
                CustomerId = R.CustomerId,
                Amount = R.Amount,
            }).ToListAsync();
            serviceResponse.Success = true;
            serviceResponse.Data = returnlist;
            return serviceResponse;
        }

        public async Task<ServiceResponse<ReceivableForDetailsVM>> GetById(int id)
        {
            ServiceResponse<ReceivableForDetailsVM> serviceResponse = new ServiceResponse<ReceivableForDetailsVM>();
            var detailobj = await _context.Receivables.Select(R => new ReceivableForDetailsVM
            {
                Id = R.Id,
                SaleOrderId = R.SaleOrderId,
                CustomerId = R.CustomerId,
                Amount = R.Amount,
            }).FirstOrDefaultAsync();
            serviceResponse.Success = true;
            serviceResponse.Data = detailobj;
            return serviceResponse;
        }

        public async Task<ServiceResponse<object>> Update(int id, ReceivableForUpdateVM model)
        {
            var updateobj = _mapper.Map<Receivables>(model);
            _context.Receivables.Update(updateobj);
            await _context.SaveChangesAsync();
            _serviceResponse.Success = true;
            _serviceResponse.Message = ResponseMessage.Updated;
            return _serviceResponse;
        }
    }
}
