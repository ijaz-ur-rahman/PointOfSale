using PointOfSale.DataService.Helpers;
using PointOfSale.DataService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointOfSale.DataService.IServices
{
    public interface IPayableService
    {
        Task<ServiceResponse<object>> Create(PayableForCreateVM model);
        Task<ServiceResponse<IEnumerable<PayableForListVM>>> GetAll();
        Task<ServiceResponse<PayableForDetailsVM>> GetById(int id);
        Task<ServiceResponse<object>> Delete(int id);
        Task<ServiceResponse<object>> Update(int id, PayableForUpdateVM model);
    }
}
