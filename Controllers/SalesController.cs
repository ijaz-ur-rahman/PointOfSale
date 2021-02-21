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
    public class SalesController : Controller
    {
        private readonly ISaleService _categoryService;
        private readonly ILookupService _lookupService;
        private ServiceResponse<object> _response;
        public SalesController(ISaleService categoryService, ILookupService lookupService)
        {
            _categoryService = categoryService;
            _lookupService = lookupService;
            _response = new ServiceResponse<object>();
        }
        [HttpGet] //, Route("Index")
        public async Task<ActionResult> Index()
        {
            var response = await _categoryService.GetAll();
            return View(response.Data);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Status = "Create";
            _response = await _lookupService.SaleOrderDrp("");
            ViewBag.CategoriesDrp = (SelectList)_response.Data;
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(SaleForCreateVM viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _response = await _categoryService.Create(viewModel);
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
            var response = await _categoryService.GetById(id);
            _response = await _lookupService.SaleOrderDrp(response.Data.OrderNumber);
            ViewBag.CategoriesDrp = (SelectList)_response.Data;
            return View("Create", response.Data);
        }
        [HttpPost]
        public async Task<ActionResult> Update(int id, SaleForUpdateVM viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _response = await _categoryService.Update(id, viewModel);
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
                _response = await _categoryService.Delete(id);
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
