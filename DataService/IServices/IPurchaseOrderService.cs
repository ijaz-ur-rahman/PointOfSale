using PointOfSale.DataService.Helpers;
using PointOfSale.DataService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointOfSale.DataService.IServices
{
    public interface IPurchaseOrderService
    {
        Task<ServiceResponse<object>> Create(PurchaseOrderForCreateVM model);
        Task<ServiceResponse<IEnumerable<PurchaseOrderForListVM>>> GetAll();
        Task<ServiceResponse<PurchaseOrderForDetailVM>> GetById(int id);
        Task<ServiceResponse<object>> Delete(int id);
        Task<ServiceResponse<object>> Update(int id, PurchaseOrderForUpdateVM model);
    }
}
