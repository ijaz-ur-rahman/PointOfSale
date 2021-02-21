using AutoMapper;
using PointOfSale.DatabaseService;
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
    public class ItemService : IItemService
    {
        private readonly POS_DBContext _context;
        private readonly IMapper _mapper;
        private ServiceResponse<object> _serviceResponse;
        public ItemService(IMapper mapper)
        {
            _context = new POS_DBContext();
            _mapper = mapper;
            _serviceResponse = new ServiceResponse<object>();
        }
        public async Task<ServiceResponse<object>> Create(ItemForCreateVM model)
        {
            var objcreateitem = _mapper.Map<Items>(model);
            objcreateitem.Active = true;
            objcreateitem.CreatedAt = DateTime.Now;
            objcreateitem.CreatedBy = 1;

            await _context.Items.AddAsync(objcreateitem);
            await _context.SaveChangesAsync();
            _serviceResponse.Success = true;
            _serviceResponse.Message = ResponseMessage.Added;
            return _serviceResponse;
        }

        public async Task<ServiceResponse<object>> Delete(int id)
        {
            var objdelitem = await _context.Items.FindAsync(id);
            objdelitem.Active = false;
            _context.Items.Update(objdelitem);
            await _context.SaveChangesAsync();
            _serviceResponse.Success = true;
            _serviceResponse.Message = ResponseMessage.Deleted;
            return _serviceResponse;
        }

        public async Task<ServiceResponse<IEnumerable<ItemForListVM>>> GetAll()
        {
            ServiceResponse<IEnumerable<ItemForListVM>> serviceResponse = new ServiceResponse<IEnumerable<ItemForListVM>>();
            var listReturn = await _context.Items.Where(g => g.Active == true).Select(i => new ItemForListVM
            {

                Id = i.Id,
                Label = i.Label,
                Code = i.Code,
                CategoryId = i.CategoryId.ToString(),
                Category = _context.Categories.FirstOrDefault(m => m.Id == i.CategoryId).Label,
                UomId = i.UomId.ToString(),
                Uom = _context.UnitOfMeasurement.FirstOrDefault(m => m.Id == i.UomId).Name,
                SalePrice = i.SalePrice.ToString(),
                PurchasePrice = i.PurchasePrice.ToString(),
                PricePerUnit = i.PricePerUnit.ToString(),
                Description = i.Description,
                //Image = i.Image
            }).ToListAsync();
            serviceResponse.Success = true;
            serviceResponse.Data = listReturn;
            return serviceResponse;
        }

        public async Task<ServiceResponse<ItemForDetailsVM>> GetById(int id)
        {
            ServiceResponse<ItemForDetailsVM> serviceResponse = new ServiceResponse<ItemForDetailsVM>();

            var ToReturn = await _context.Items.Where(d => d.Id == id).Select(i => new ItemForDetailsVM
            {
                Id = i.Id,
                Code = i.Code,
                Label = i.Label,
                CategoryId = i.CategoryId.ToString(),
                Category = _context.Categories.FirstOrDefault(m => m.Id == i.CategoryId).Label,
                UomId = i.UomId.ToString(),
                Uom = _context.UnitOfMeasurement.FirstOrDefault(m => m.Id == i.UomId).Name,
                SalePrice = i.SalePrice.ToString(),
                PurchasePrice = i.PurchasePrice.ToString(),
                PricePerUnit = i.PricePerUnit.ToString(),
                Description = i.Description,
                //Image = i.Image
            }).FirstOrDefaultAsync();
            serviceResponse.Success = true;
            serviceResponse.Data = ToReturn;
            return serviceResponse;
        }

        public async Task<ServiceResponse<object>> Update(int id, ItemForUpdateVM model)
        {
            var objUpdateitem = _mapper.Map<Items>(model);
            objUpdateitem.UpdatedAt = DateTime.Now;
            objUpdateitem.UpdatedBy = 1;
            objUpdateitem.Active = model.Active;
            _context.Items.Update(objUpdateitem);
            await _context.SaveChangesAsync();
            _serviceResponse.Success = true;
            _serviceResponse.Message = ResponseMessage.Updated;
            return _serviceResponse;
        }
    }
}
