using PointOfSale.DataService.Helpers;
using PointOfSale.DataService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointOfSale.DataService.IServices
{
    public interface ISaleService
    {
        Task<ServiceResponse<object>> Create(SaleForCreateVM model);
        Task<ServiceResponse<IEnumerable<SaleForListVM>>> GetAll();
        Task<ServiceResponse<SaleForDetailsVM>> GetById(int id);
        Task<ServiceResponse<object>> Delete(int id);
        Task<ServiceResponse<object>> Update(int id, SaleForUpdateVM model);
    }
}
