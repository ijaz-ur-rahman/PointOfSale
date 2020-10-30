using AutoMapper;
using DatabaseService;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration;
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
        private ServiceResponse _serviceResponse;
        public UserService(POS_DBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _serviceResponse = new ServiceResponse();
        }

        public async Task<ServiceResponse> GetAll()
        {
            var res = await _context.Users.ToListAsync();
            _serviceResponse.Success = true;
            _serviceResponse.Data = res;
            return _serviceResponse;
        }

        public async Task<ServiceResponse> GetById(int id)
        {
            var res = await _context.Users.Where(m => m.Id == id).FirstOrDefaultAsync();
            _serviceResponse.Data = res;
            return _serviceResponse;
        }

        public async Task<ServiceResponse> Login(LoginVM loginVM)
        {
            try
            {
                var password = Encryption.Encrypt(loginVM.Password);
                var dbObj = await _context.Users.Where(m => m.Name == loginVM.UserName.ToLower() && m.Password == password).FirstOrDefaultAsync();
                if (dbObj == null)
                    throw new Exception("User not found");
                _serviceResponse.Success = true;
                _serviceResponse.Data = dbObj;
                return _serviceResponse;
            }
            catch (Exception ex)
            {
                ExceptionLog.Log(ex);
                throw ex;
            }
        }
        public async Task<ServiceResponse> Register(LoginVM registerVM)
        {
            try
            {
                var user = _mapper.Map<Users>(registerVM);
                user.Name = registerVM.UserName.ToLower();
                user.Password = Encryption.Encrypt(registerVM.Password);
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                _serviceResponse.Success = true;
                return _serviceResponse;
            }
            catch (Exception ex)
            {
                ExceptionLog.Log(ex);
                throw ex;
            }
        }
        public async Task<ServiceResponse> Create(UserForCreateVM model)
        {
            try
            {
                var user = _mapper.Map<Users>(model);
                user.Name = model.Name.ToLower();
                user.Password = Encryption.Encrypt(model.Password);
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                _serviceResponse.Success = true;
                return _serviceResponse;
            }
            catch (Exception ex)
            {
                ExceptionLog.Log(ex);
                throw ex;
            }
        }

        public async Task<ServiceResponse> Update(int id, UserForUpdateVM model)
        {
            try
            {
                var user = _mapper.Map<Users>(model);
                _context.Users.Attach(user);
                _context.Entry(user).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                _serviceResponse.Success = true;
                return _serviceResponse;
            }
            catch (Exception ex)
            {
                ExceptionLog.Log(ex);
                throw ex;
            }
        }
        public async Task<ServiceResponse> Delete(int id)
        {
            var student = _context.Users.Find(id);
            _context.Users.Remove(student);
            await _context.SaveChangesAsync();
            _serviceResponse.Success = true;
            return _serviceResponse;
        }
    }
}
