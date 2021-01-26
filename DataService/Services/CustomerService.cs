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
    public class CustomerService : ICustomerService
    {
        private readonly POS_DBContext _context;
        private readonly IMapper _mapper;
        private ServiceResponse<object> _serviceResponse;
        public CustomerService(IMapper mapper)
        {
            _context = new POS_DBContext();
            _mapper = mapper;
            _serviceResponse = new ServiceResponse<object>();
        }
        public async Task<ServiceResponse<object>> Create(CustomerForCreateVM model)
        {
            var createobj = _mapper.Map<Customers>(model);
            createobj.CreatedAt = DateTime.Now;
            createobj.CreatedBy = 1;

            await _context.Customers.AddAsync(createobj);
            await _context.SaveChangesAsync();
            _serviceResponse.Success = true;
            _serviceResponse.Message = ResponseMessage.Added;
            return _serviceResponse;

        }

        public async Task<ServiceResponse<object>> Delete(int id)
        {
            var deleteobj = await _context.Customers.FindAsync(id);
            _context.Customers.Update(deleteobj);
            await _context.SaveChangesAsync();
            _serviceResponse.Success = true;
            _serviceResponse.Message = ResponseMessage.Deleted;
            return _serviceResponse;
        }

        public async Task<ServiceResponse<IEnumerable<CustomerForListVM>>> GetAll()
        {
            ServiceResponse<IEnumerable<CustomerForListVM>> serviceResponse = new ServiceResponse<IEnumerable<CustomerForListVM>>();
            var returnlist = await _context.Customers.Select(c => new CustomerForListVM
            {
                Id = c.Id,
                Name = c.Name,
                Phone = c.Phone,
                Address = c.Address,
            }).ToListAsync();
            serviceResponse.Success = true;
            serviceResponse.Data = returnlist;
            return serviceResponse;
        }

        public async Task<ServiceResponse<CustomerForDetailsVM>> GetById(int id)
        {
            ServiceResponse<CustomerForDetailsVM> serviceResponse = new ServiceResponse<CustomerForDetailsVM>();
            var updateobj = await _context.Customers.Select(c => new CustomerForDetailsVM
            {
                Id = c.Id,
                Name = c.Name,
                Phone = c.Phone,
                Address = c.Address,
            }).FirstOrDefaultAsync();
            serviceResponse.Success = true;
            serviceResponse.Data = updateobj;
            return serviceResponse;
        }

        public async Task<ServiceResponse<object>> Update(int id, CustomerForUpdateVM model)
        {
            var updateobj = _mapper.Map<Customers>(model);
            _context.Customers.Update(updateobj);
            await _context.SaveChangesAsync();
            _serviceResponse.Success = true;
            _serviceResponse.Message = ResponseMessage.Added;
            return _serviceResponse;
        }
    }
}
