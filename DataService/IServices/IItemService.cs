using PointOfSale.DataService.Helpers;
using PointOfSale.DataService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointOfSale.DataService.IServices
{
    public interface IItemService
    {
        Task<ServiceResponse<object>> Create(ItemForCreateVM model);
        Task<ServiceResponse<IEnumerable<ItemForListVM>>> GetAll();
        Task<ServiceResponse<ItemForDetailsVM>> GetById(int id);
        Task<ServiceResponse<object>> Delete(int id);
        Task<ServiceResponse<object>> Update(int id, ItemForUpdateVM model);
    }
}
