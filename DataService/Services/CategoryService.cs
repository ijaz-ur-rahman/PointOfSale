using AutoMapper;
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
    public class CategoryService : ICategoryService
    {
        private readonly POS_DBContext _context;
        private readonly IMapper _mapper;
        private ServiceResponse _serviceResponse;
        public CategoryService(POS_DBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _serviceResponse = new ServiceResponse();
        }
        public Task<ServiceResponse> Create(CategoryVM viewModel)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse> Update(int id, CategoryVM model)
        {
            throw new NotImplementedException();
        }
    }
}
