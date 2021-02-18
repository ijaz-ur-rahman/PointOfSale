using PointOfSale.DataService.Helpers;
using PointOfSale.DataService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointOfSale.DataService.IServices
{
    public interface IReceivableService
    {
        Task<ServiceResponse<object>> Create(ReceivableForCreateVM model);
        Task<ServiceResponse<IEnumerable<ReceivableForListVM>>> GetAll();
        Task<ServiceResponse<ReceivableForDetailsVM>> GetById(int id);
        Task<ServiceResponse<object>> Delete(int id);
        Task<ServiceResponse<object>> Update(int id, ReceivableForUpdateVM model);
    }
}
