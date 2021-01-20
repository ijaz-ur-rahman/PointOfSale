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
        private ServiceResponse<object> _serviceResponse;
        public CategoryService(IMapper mapper)
        {
            _context = new POS_DBContext();
            _mapper = mapper;
            _serviceResponse = new ServiceResponse<object>();
        }
        public async Task<ServiceResponse<object>> Create(CategoryForCreateVM model)
        {
            var objToCreate = _mapper.Map<Categories>(model);
            objToCreate.Active = true;
            objToCreate.CreatedAt = DateTime.Now;
            objToCreate.CreatedBy = 1;

            await _context.Categories.AddAsync(objToCreate);
            await _context.SaveChangesAsync();
            _serviceResponse.Success = true;
            _serviceResponse.Message = ResponseMessage.Added;
            return _serviceResponse;
        }

        public async Task<ServiceResponse<object>> Delete(int id)
        {
            var objToDelete = await _context.Categories.FindAsync(id);
            objToDelete.Active = false;
            _context.Categories.Update(objToDelete);
            await _context.SaveChangesAsync();
            _serviceResponse.Success = true;
            _serviceResponse.Message = ResponseMessage.Deleted;
            return _serviceResponse;
        }

        public async Task<ServiceResponse<IEnumerable<CategoryForListVM>>> GetAll()
        {
            ServiceResponse<IEnumerable<CategoryForListVM>> serviceResponse = new ServiceResponse<IEnumerable<CategoryForListVM>>();
            
            var listToReurn = await _context.Categories.Where(m => m.Active == true).Select(o => new CategoryForListVM
            {
                Id = o.Id,
                Code = o.Code,
                Label = o.Label,
                Description = o.Description,
                ParentCategoryId = o.ParentCategoryId,
                ParentCategory = _context.Categories.FirstOrDefault(m => m.Id == o.Id).Label
            }).ToListAsync();
            serviceResponse.Success = true;
            serviceResponse.Data = listToReurn;
            return serviceResponse;
        }

        public async Task<ServiceResponse<CategoryForDetailsVM>> GetById(int id)
        {
            ServiceResponse<CategoryForDetailsVM> serviceResponse = new ServiceResponse<CategoryForDetailsVM>();

            var ToReturn = await _context.Categories.Where(m => m.Id == id).Select(o => new CategoryForDetailsVM
            {
                Id = o.Id,
                Code = o.Code,
                Label = o.Label,
                Description = o.Description,
                ParentCategoryId = o.ParentCategoryId,
                ParentCategory = _context.Categories.FirstOrDefault(m => m.Id == o.Id).Label
            }).FirstOrDefaultAsync();
            serviceResponse.Success = true;
            serviceResponse.Data = ToReturn;
            return serviceResponse;
        }

        public async Task<ServiceResponse<object>> Update(int id, CategoryForUpdateVM model)
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
