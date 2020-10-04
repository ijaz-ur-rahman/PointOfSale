using DatabaseService;
using PointOfSale.DataService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointOfSale.DataService.IServices
{
    public interface IUserService
    {
        Task<Users> Login(LoginVM loginVM);
        Task Register(LoginVM registerVM);
        Task<IEnumerable<Users>> GetAll();
        Task<Users> GetById(int id);
        Task<bool> Delete(int id);
        Task<bool> Update(int id);
    }
}
