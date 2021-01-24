using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PointOfSale.DataService.Helpers;
using PointOfSale.DataService.IServices;
using PointOfSale.DataService.ViewModels;

namespace PointOfSale.Controllers
{
    public class ItemsController : Controller
    {
        private readonly IItemService _itemService;
        private readonly ILookupService _lookupService;
        private ServiceResponse<object> _response;
        public ItemsController(IItemService itemService, ILookupService lookupService)
        {
            _itemService = itemService;
            _lookupService = lookupService;
            _response = new ServiceResponse<object>();
        }
        public async Task<ActionResult> Index()
        {
            var response = await _itemService.GetAll();
            return View(response.Data);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Status = "Create";
            _response = await _lookupService.CategoriesDrp("");
            ViewBag.CategoriesDrp = (SelectList)_response.Data;
            _response = await _lookupService.UOMDrp("");
            ViewBag.UOMDrp = (SelectList)_response.Data;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ItemForCreateVM Vmodel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _response = await _itemService.Create(Vmodel);
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Message = ex.Message ?? ex.InnerException.ToString();
                return BadRequest(_response);
            }
        }
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            ViewBag.Status = "Update";
            var response = await _itemService.GetById(id);
            _response = await _lookupService.CategoriesDrp(response.Data.Id);
            ViewBag.CategoriesDrp = (SelectList)_response.Data;
            return View("Create", response.Data);
        }
        [HttpPost]
        public async Task<ActionResult> Update(int id, ItemForUpdateVM viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _response = await _itemService.Update(id, viewModel);
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Message = ex.Message ?? ex.InnerException.ToString();
                return BadRequest(_response);
            }
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                _response = await _itemService.Delete(id);
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Message = ex.Message ?? ex.InnerException.ToString();
                return BadRequest(_response);
            }
        }
    }
}
