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
        Task<ServiceResponse> Login(LoginVM loginVM);
        Task<ServiceResponse> Register(LoginVM registerVM);
        Task<ServiceResponse> Create(UserForCreateVM model);
        Task<ServiceResponse> GetAll();
        Task<ServiceResponse> GetById(int id);
        Task<ServiceResponse> Delete(int id);
        Task<ServiceResponse> Update(int id, UserForUpdateVM model);
    }
}
