using PointOfSale.DataService.Helpers;
using PointOfSale.DataService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointOfSale.DataService.IServices
{
    public interface ICustomerService
    {
        Task<ServiceResponse<object>> Create(CustomerForCreateVM model);
        Task<ServiceResponse<IEnumerable<CustomerForListVM>>> GetAll();
        Task<ServiceResponse<CustomerForDetailsVM>> GetById(int id);
        Task<ServiceResponse<object>> Delete(int id);
        Task<ServiceResponse<object>> Update(int id, CustomerForUpdateVM model);
    }
}
