using DatabaseService;
using PointOfSale.DataService.Helpers;
using PointOfSale.DataService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointOfSale.DataService.IServices
{
    public interface IUserService
    {
        Task<ServiceResponse<object>> Login(LoginVM loginVM);
        Task<ServiceResponse<object>> Register(LoginVM registerVM);
        Task<ServiceResponse<object>> Create(UserForCreateVM model);
        Task<ServiceResponse<object>> GetAll();
        Task<ServiceResponse<object>> GetById(int id);
        Task<ServiceResponse<object>> Delete(int id);
        Task<ServiceResponse<object>> Update(int id, UserForUpdateVM model);
    }
}
