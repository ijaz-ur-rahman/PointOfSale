using PointOfSale.DataService.Helpers;
using PointOfSale.DataService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointOfSale.DataService.IServices
{
   public interface ISupplierService
    {
        Task<ServiceResponse<object>> Create(SupplierForCreateVM model);
        Task<ServiceResponse<IEnumerable<SupplierForListVM>>> GetAll();
        Task<ServiceResponse<SupplierForDetailsVM>> GetById(int id);
        Task<ServiceResponse<object>> Delete(int id);
        Task<ServiceResponse<object>> Update(int id, SupplierForUpdateVM model);
    }
}
