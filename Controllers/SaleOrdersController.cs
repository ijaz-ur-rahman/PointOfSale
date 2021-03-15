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
    public class SaleOrdersController : Controller
    {
        private readonly ISaleOrderService _baseService;
        private readonly ILookupService _lookupService;
        private ServiceResponse<object> _response;
        public SaleOrdersController(ISaleOrderService baseService, ILookupService lookupService)
        {
            _baseService = baseService;
            _lookupService = lookupService;
            _response = new ServiceResponse<object>();
        }
        [HttpGet] //, Route("Index")
        public async Task<ActionResult> Index()
        {
            var response = await _baseService.GetAll();
            return View(response.Data);
        }
        [HttpGet]
        public async Task<ActionResult> GetById(int id)
        {
            var response = await _baseService.GetById(id);
            return View(response);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Status = "Create";
            //_response = await _lookupService.SaleOrderDrp("");
            var ItemResponse = await _lookupService.ItemsDrp("");
            ViewBag.ItemDrp = (SelectList)ItemResponse.Data;
            var CustomerResponse = await _lookupService.CustomerDrp("");
            ViewBag.CustomerDrp = (SelectList)CustomerResponse.Data;
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(SaleOrderForCreateVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _response = await _baseService.Create(model);
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
            var response = await _baseService.GetById(id);
            _response = await _lookupService.SaleOrderDrp(response.Data.OrderNumber);
            ViewBag.CategoriesDrp = (SelectList)_response.Data;
            return View("Create", response.Data);
        }
        [HttpPost]
        public async Task<ActionResult> Update(int id, SaleOrderForUpdateVM viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _response = await _baseService.Update(id, viewModel);
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
                _response = await _baseService.Delete(id);
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
        public async Task<ActionResult> GetItemDetails(int id)
        {
            _response = await _baseService.GetItemDetails(id);
            return Json(_response.Data);
        }
    }
}
