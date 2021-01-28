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
    public class SupplierService : ISupplierService
    {
        private readonly POS_DBContext _context;
        private readonly IMapper _mapper;
        private ServiceResponse<object> _serviceResponse;
        public SupplierService(IMapper mapper)
        {
            _context = new POS_DBContext();
            _mapper = mapper;
            _serviceResponse = new ServiceResponse<object>();
        }
        public async Task<ServiceResponse<object>> Create(SupplierForCreateVM model)
        {
            var objforcreate = _mapper.Map<Suppliers>(model);
            objforcreate.Active = true;
            objforcreate.CreatedAt = DateTime.Now;
            objforcreate.CreatedBy = 1;

            await _context.Suppliers.AddAsync(objforcreate);//chek this error
            await _context.SaveChangesAsync();
            _serviceResponse.Success = true;
            _serviceResponse.Message = ResponseMessage.Added;
            return _serviceResponse;
        }

        public async Task<ServiceResponse<object>> Delete(int id)
        {
            var objforDelete = await _context.Suppliers.FindAsync(id);
            objforDelete.Active = false;
            _context.Suppliers.Update(objforDelete);
            await _context.SaveChangesAsync();
            _serviceResponse.Success = true;
            _serviceResponse.Message = ResponseMessage.Deleted;
            return _serviceResponse;
        }

        public async Task<ServiceResponse<IEnumerable<SupplierForListVM>>> GetAll()
        {
            ServiceResponse<IEnumerable<SupplierForListVM>> serviceResponse = new ServiceResponse<IEnumerable<SupplierForListVM>>();

            var objforlist = await _context.Suppliers.Where(m => m.Active == true).Select(s => new SupplierForListVM
            {
                Id = s.Id,
                Name = s.Name,
                Phone = s.Phone,
                Address = s.Address,
            }).ToListAsync();
            serviceResponse.Success = true;
            serviceResponse.Data = objforlist;
            return serviceResponse;
        }

        public async Task<ServiceResponse<SupplierForDetailsVM>> GetById(int id)
        {
            ServiceResponse<SupplierForDetailsVM> serviceResponse = new ServiceResponse<SupplierForDetailsVM>();

            var objfordetail = await _context.Suppliers.Where(m => m.Id == id).Select(s => new SupplierForDetailsVM
            {
                Id = s.Id,
                Name = s.Name,
                Phone = s.Phone,
                Address = s.Address,
            }).FirstOrDefaultAsync();
            serviceResponse.Success = true;
            serviceResponse.Data = objfordetail;
            return serviceResponse;
        }

        public async Task<ServiceResponse<object>> Update(int id, SupplierForUpdateVM model)
        {
            var objforUpdate = _mapper.Map<Suppliers>(model);
            objforUpdate.UpdatedAt = DateTime.Now;
            objforUpdate.UpdatedBy = 1;
            objforUpdate.Active = model.Active;
            _context.Suppliers.Update(objforUpdate);
            await _context.SaveChangesAsync();
            _serviceResponse.Success = true;
            _serviceResponse.Message = ResponseMessage.Updated;
            return _serviceResponse;
        }
    }
}
