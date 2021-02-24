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
    public class UOMService : IUOMService
    {
        private readonly POS_DBContext _context;
        private readonly IMapper _mapper;
        private ServiceResponse<object> _serviceResponse;
        public UOMService(IMapper mapper)
        {
            _context = new POS_DBContext();
            _mapper = mapper;
            _serviceResponse = new ServiceResponse<object>();
        }
        public async Task<ServiceResponse<object>> Create(UOMForCreateVM model)
        {
            try
            {
                var createobj = _mapper.Map<UnitOfMeasurement>(model);
                createobj.CreatedAt = DateTime.Now;
                createobj.CreatedBy = 1;
                createobj.UpdatedAt = DateTime.Now;
                createobj.UpdatedBy = 1;

                await _context.UnitOfMeasurement.AddAsync(createobj);
                await _context.SaveChangesAsync();
                _serviceResponse.Success = true;
                _serviceResponse.Message = ResponseMessage.Added;
                return _serviceResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ServiceResponse<object>> Delete(int id)
        {
            var deleteobj = await _context.UnitOfMeasurement.FindAsync(id);
            _context.UnitOfMeasurement.Remove(deleteobj);
            await _context.SaveChangesAsync();
            _serviceResponse.Success = true;
            _serviceResponse.Message = ResponseMessage.Deleted;
            return _serviceResponse;
        }

        public async Task<ServiceResponse<IEnumerable<UOMForListVM>>> GetAll()
        {
            ServiceResponse<IEnumerable<UOMForListVM>> serviceResponse = new ServiceResponse<IEnumerable<UOMForListVM>>();
            var returnlist = await _context.UnitOfMeasurement.Select(u => new UOMForListVM
            {
                Id = u.Id,
                Code = u.Code,
                Name = u.Name,
                Class = u.Class

            }).ToListAsync();
            serviceResponse.Success = true;
            serviceResponse.Data = returnlist;
            return serviceResponse;
        }

        public async Task<ServiceResponse<UOMForDetailVM>> GetById(int id)
        {

            ServiceResponse<UOMForDetailVM> serviceResponse = new ServiceResponse<UOMForDetailVM>();
            var updateobj = await _context.UnitOfMeasurement.Select(u => new UOMForDetailVM
            {
                Id = u.Id,
                Code = u.Code,
                Name = u.Name,
                Class = u.Class,
            }).FirstOrDefaultAsync();
            serviceResponse.Success = true;
            serviceResponse.Data = updateobj;
            return serviceResponse;
        }

        public async Task<ServiceResponse<object>> Update(int id, UOMForUpdateVM model)
        {
            var updateobj = _mapper.Map<UnitOfMeasurement>(model);
            _context.UnitOfMeasurement.Update(updateobj);
            await _context.SaveChangesAsync();
            _serviceResponse.Success = true;
            _serviceResponse.Message = ResponseMessage.Added;
            return _serviceResponse;
        }
    }
}
