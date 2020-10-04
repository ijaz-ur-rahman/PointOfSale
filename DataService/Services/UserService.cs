using AutoMapper;
using DatabaseService;
using Microsoft.EntityFrameworkCore;
using PointOfSale.DatabaseService.DBContext;
using PointOfSale.DataService.Helpers;
using PointOfSale.DataService.IServices;
using PointOfSale.DataService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointOfSale.DataService.Services
{
    public class UserService : IUserService
    {
        private readonly POS_DBContext _context;
        private readonly IMapper _mapper;
        public UserService(POS_DBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }       

        public Task<IEnumerable<Users>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Users> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Users> Login(LoginVM loginVM)
        {
            var password = Encryption.Encrypt(loginVM.Password);
            var dbObj = await _context.Users.Where(m => m.Name == loginVM.UserName.ToLower() && m.Password == password).FirstOrDefaultAsync();
            if (dbObj == null)
                throw new Exception("User not found");            
            return dbObj;
        }
        public async Task Register(LoginVM registerVM)
        {
            var user = _mapper.Map<Users>(registerVM);
            user.Name = registerVM.UserName.ToLower();
            user.Password = Encryption.Encrypt(registerVM.Password);
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public Task<bool> Update(int id)
        {
            throw new NotImplementedException();
        }
        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
