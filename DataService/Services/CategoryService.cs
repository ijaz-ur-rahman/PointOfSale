using AutoMapper;
using DatabaseService;
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
    public class CategoryService : ICategoryService
    {
        private readonly POS_DBContext _context;
        private readonly IMapper _mapper;
        private ServiceResponse _serviceResponse;
        public CategoryService(IMapper mapper)
        {
            _context = new POS_DBContext();
            _mapper = mapper;
            _serviceResponse = new ServiceResponse();
        }
        public async Task<ServiceResponse> Create(CategoryForCreateVM model)
        {
            var objToCreate = _mapper.Map<Categories>(model);
            await _context.Categories.AddAsync(objToCreate);
            await _context.SaveChangesAsync();
            _serviceResponse.Success = true;
            _serviceResponse.Message = ResponseMessage.Added;
            return _serviceResponse;
        }

        public async Task<ServiceResponse> Delete(int id)
        {
            var objToDelete = await _context.Categories.Where(m => m.Id == id).FirstOrDefaultAsync();
            _context.Categories.Remove(objToDelete);
            await _context.SaveChangesAsync();
            _serviceResponse.Success = true;
            _serviceResponse.Message = ResponseMessage.Deleted;
            return _serviceResponse;
        }

        public async Task<ServiceResponse> GetAll()
        {
            var listToReurn = await _context.Categories.Select(o => new CategoryForListVM
            {
                Id = o.Id,
                Code = o.Code,
                Label = o.Label,
                Description = o.Description,
                ParentCategoryId = o.ParentCategoryId,
                ParentCategory = _context.Categories.FirstOrDefault(m => m.Id == o.Id).Label
            }).ToListAsync();
            _serviceResponse.Success = true;
            _serviceResponse.Data = listToReurn;
            return _serviceResponse;
        }

        public async Task<ServiceResponse> GetById(int id)
        {
            var toReturn = await _context.Categories.Where(m => m.Id == id).Select(o => new CategoryForListVM
            {
                Id = o.Id,
                Code = o.Code,
                Label = o.Label,
                Description = o.Description,
                ParentCategoryId = o.ParentCategoryId,
                ParentCategory = _context.Categories.FirstOrDefault(m => m.Id == o.Id).Label
            }).FirstOrDefaultAsync();
            _serviceResponse.Success = true;
            _serviceResponse.Data = toReturn;
            return _serviceResponse;
        }

        public async Task<ServiceResponse> Update(int id, CategoryForUpdateVM model)
        {
            var objToUpdate = _mapper.Map<Categories>(model);
            _context.Categories.Update(objToUpdate);
            await _context.SaveChangesAsync();
            _serviceResponse.Success = true;
            _serviceResponse.Message = ResponseMessage.Added;
            return _serviceResponse;
        }
    }
}
