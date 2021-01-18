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
        private ServiceResponse<object> _serviceResponse;
        public UserService(IMapper mapper)
        {
            _context = new POS_DBContext();
            _mapper = mapper;
            _serviceResponse = new ServiceResponse<object>();
        }

        public async Task<ServiceResponse<object>> GetAll()
        {
            var res = await _context.Users.ToListAsync();
            _serviceResponse.Data = res;
            return _serviceResponse;
        }

        public async Task<ServiceResponse<object>> GetById(int id)
        {
            var res = await _context.Users.Where(m => m.Id == id).FirstOrDefaultAsync();
            _serviceResponse.Data = res;
            return _serviceResponse;
        }

        public async Task<ServiceResponse<object>> Login(LoginVM loginVM)
        {
            try
            {
                var password = Encryption.Encrypt(loginVM.Password);
                var dbObj = await _context.Users.Where(m => m.Name == loginVM.UserName.ToLower() && m.Password == password).FirstOrDefaultAsync();
                if (dbObj == null)
                {
                    _serviceResponse.Success = false;
                    _serviceResponse.Message = ResponseMessage.NotFound;
                }
                else
                {
                    _serviceResponse.Success = true;
                    _serviceResponse.Data = dbObj;
                }
            }
            catch (Exception ex)
            {
                ExceptionLog.Log(ex);
                throw ex;
            }
            return _serviceResponse;
        }
        public async Task<ServiceResponse<object>> Register(LoginVM registerVM)
        {
            try
            {
                var user = _mapper.Map<Users>(registerVM);
                user.Name = registerVM.UserName.ToLower();
                user.Password = Encryption.Encrypt(registerVM.Password);
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                _serviceResponse.Success = true;

            }
            catch (Exception ex)
            {
                ExceptionLog.Log(ex);
                throw ex;
            }
            return _serviceResponse;
        }
        public async Task<ServiceResponse<object>> Create(UserForCreateVM model)
        {
            try
            {
                var user = _mapper.Map<Users>(model);
                user.Name = model.Name.ToLower();
                user.Password = Encryption.Encrypt(model.Password);
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                _serviceResponse.Success = true;
                _serviceResponse.Message = ResponseMessage.Added;
            }
            catch (Exception ex)
            {
                ExceptionLog.Log(ex);
                throw ex;
            }
            return _serviceResponse;
        }

        public async Task<ServiceResponse<object>> Update(int id, UserForUpdateVM model)
        {
            try
            {
                var user = _mapper.Map<Users>(model);
                _context.Users.Attach(user);
                _context.Entry(user).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                _serviceResponse.Success = true;
                _serviceResponse.Message = ResponseMessage.Updated;
            }
            catch (Exception ex)
            {
                ExceptionLog.Log(ex);
                throw ex;
            }
            return _serviceResponse;
        }
        public async Task<ServiceResponse<object>> Delete(int id)
        {
            var student = _context.Users.Find(id);
            _context.Users.Remove(student);
            await _context.SaveChangesAsync();
            _serviceResponse.Success = true;
            _serviceResponse.Message = ResponseMessage.Deleted;
            return _serviceResponse;
        }
    }
}
