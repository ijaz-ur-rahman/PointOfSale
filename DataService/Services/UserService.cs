using AutoMapper;
using PointOfSale.DatabaseService;
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
            ServiceResponse<IEnumerable<UserForListVM>> serviceResponse = new ServiceResponse<IEnumerable<UserForListVM>>();

            var listToReurn = await _context.Users.Where(m => m.Active == true).Select(o => new UserForListVM
            {
                Id = o.Id,
                Name = o.Name,
                RoleId = o.RoleId.ToString(),
                Role = _context.Roles.FirstOrDefault(m => m.Id == o.Id).Name
            }).ToListAsync();
            _serviceResponse.Data = listToReurn;
            return _serviceResponse;
        }

        public async Task<ServiceResponse<UserForDetailsVM>> GetById(int id)
        {
            ServiceResponse<UserForDetailsVM> serviceResponse = new ServiceResponse<UserForDetailsVM>();

            var ToReurn = await _context.Users.Where(m => m.Id == id).Select(o => new UserForDetailsVM
            {
                Id = o.Id,
                Name = o.Name,
                RoleId = o.RoleId.ToString(),
                Role = _context.Roles.FirstOrDefault(m => m.Id == o.Id).Name
            }).FirstOrDefaultAsync();
            serviceResponse.Data = ToReurn;
            serviceResponse.Success = true;
            return serviceResponse;
        }

        public async Task<ServiceResponse<Users>> Login(LoginVM loginVM)
        {
            ServiceResponse<Users> serviceResponse = new ServiceResponse<Users>();
            try
            {
                var password = Encryption.Encrypt(loginVM.Password);
                var dbObj = await _context.Users.Where(m => m.Name == loginVM.UserName.ToLower() && m.Password == password).FirstOrDefaultAsync();
                if (dbObj == null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = ResponseMessage.NotFound;
                }
                else
                {
                    serviceResponse.Success = true;
                    serviceResponse.Data = dbObj;
                }
            }
            catch (Exception ex)
            {
                ExceptionLog.Log(ex);
                throw ex;
            }
            return serviceResponse;
        }
        public async Task<ServiceResponse<object>> Register(LoginVM registerVM)
        {
            try
            {
                var user = _mapper.Map<Users>(registerVM);
                user.Name = registerVM.UserName.ToLower();
                user.Password = Encryption.Encrypt(registerVM.Password);
                user.CreatedAt = DateTime.Now;
                user.CreatedBy = 1;
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
                user.CreatedAt = DateTime.Now;
                user.CreatedBy = 1;
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
                var objToUpdate = _mapper.Map<Users>(model);
                objToUpdate.Active = model.Active;
                _context.Users.Update(objToUpdate);
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
            student.Active = false;
            _context.Users.Update(student);
            await _context.SaveChangesAsync();
            _serviceResponse.Success = true;
            _serviceResponse.Message = ResponseMessage.Deleted;
            return _serviceResponse;
        }
    }
}
