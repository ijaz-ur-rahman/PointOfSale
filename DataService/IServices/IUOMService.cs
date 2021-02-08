using PointOfSale.DataService.Helpers;
using PointOfSale.DataService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointOfSale.DataService.IServices
{
   public interface IUOMService
    {
        Task<ServiceResponse<object>> Create(UOMForCreateVM model);
        Task<ServiceResponse<IEnumerable<UOMForListVM>>> GetAll();
        Task<ServiceResponse<UOMForDetailVM>> GetById(int id);
        Task<ServiceResponse<object>> Delete(int id);
        Task<ServiceResponse<object>> Update(int id, UOMForUpdateVM model);
    }
}
