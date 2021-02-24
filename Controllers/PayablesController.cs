using Microsoft.AspNetCore.Mvc;
using PointOfSale.DataService.Helpers;
using PointOfSale.DataService.IServices;
using PointOfSale.DataService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointOfSale.Controllers
{
    public class PayablesController : Controller
    {
        private readonly IPayableService _payable;
        private readonly ILookupService _lookupService;
        private ServiceResponse<object> _response;
        public PayablesController(IPayableService payableService, ILookupService lookupService)
        {
            _payable = payableService;
            _lookupService = lookupService;
            _response = new ServiceResponse<object>();
        }
        public async Task<IActionResult> Index()
        {
            var response = await _payable.GetAll();
            return View(response.Data);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Status = "Create";
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(PayableForCreateVM Vmodel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _response = await _payable.Create(Vmodel);
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
            var response = await _payable.GetById(id);
            return View("Create", response.Data);
        }
        [HttpPost]
        public async Task<ActionResult> Update(int id, PayableForUpdateVM viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _response = await _payable.Update(id, viewModel);
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
                _response = await _payable.Delete(id);
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
