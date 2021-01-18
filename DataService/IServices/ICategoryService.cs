using PointOfSale.DataService.Helpers;
using PointOfSale.DataService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointOfSale.DataService.IServices
{
    public interface ICategoryService
    {
        Task<ServiceResponse<object>> Create(CategoryForCreateVM model);
        Task<ServiceResponse<IEnumerable<CategoryForListVM>>> GetAll();
        Task<ServiceResponse<CategoryForDetailsVM>> GetById(int id);
        Task<ServiceResponse<object>> Delete(int id);
        Task<ServiceResponse<object>> Update(int id, CategoryForUpdateVM model);
    }
}
