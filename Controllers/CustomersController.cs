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
    public class CustomersController : Controller
    {
        private readonly ICustomerService _customers;
        private readonly ILookupService _lookupService;
        private ServiceResponse<object> _response;
        public CustomersController(ICustomerService customerService,ILookupService lookupService)
        {
            _customers = customerService;
            _lookupService = lookupService;
            _response = new ServiceResponse<object>();
        }
        public async Task<IActionResult> Index()
        {
            var response = await _customers.GetAll();
            return View(response.Data);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Status = "Create";
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CustomerForCreateVM Vmodel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _response = await _customers.Create(Vmodel);
                return Ok(_response);
            }
            catch (Exception ex)//yahan null ly rha ha
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
            var response = await _customers.GetById(id);
            return View("Create", response.Data);
        }
        [HttpPost]
        public async Task<ActionResult> Update(int id, CustomerForUpdateVM viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _response = await _customers.Update(id, viewModel);
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
                _response = await _customers.Delete(id);
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
