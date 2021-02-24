using PointOfSale.DataService.Helpers;
using PointOfSale.DataService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointOfSale.DataService.IServices
{
    public interface ISaleOrderService
    {
        Task<ServiceResponse<object>> Create(SaleOrderForCreateVM model);
        Task<ServiceResponse<IEnumerable<SaleOrderForListVM>>> GetAll();
        Task<ServiceResponse<SaleOrderForDetailsVM>> GetById(int id);
        Task<ServiceResponse<object>> Delete(int id);
        Task<ServiceResponse<object>> Update(int id, SaleOrderForUpdateVM model);
    }
}
