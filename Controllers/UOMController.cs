using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PointOfSale.DataService.Helpers;
using PointOfSale.DataService.IServices;
using PointOfSale.DataService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointOfSale.Controllers
{
    public class UOMController : Controller
    {
        private readonly IUOMService _uomservice;
        private readonly ILookupService _lookupService;
        private ServiceResponse<object> _response;
        public UOMController(IUOMService uomservice, ILookupService lookupservice)
        {
            _uomservice = uomservice;
            _lookupService = lookupservice;
            _response = new ServiceResponse<object>();
        }
        public async Task<IActionResult> Index()
        {
            var response = await _uomservice.GetAll();
            return View(response.Data);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Status = "Create";
            _response = await _lookupService.UOMDrp("");
            ViewBag.UOMDrp = (SelectList)_response.Data;
            return View();
        }
        public async Task<ActionResult> Create(UOMForCreateVM viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _response = await _uomservice.Create(viewModel);
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Message = ex.Message ?? ex.InnerException.ToString();
                return BadRequest(_response);
            }
        }
        public async Task<ActionResult> Edit(int id)
        {
            ViewBag.Status = "Update";
            var response = await _uomservice.GetById(id);
            _response = await _lookupService.UOMDrp(response.Data.Id);
            ViewBag.UOMDrp = (SelectList)_response.Data;
            return View("Create", response.Data);
        }
        public async Task<ActionResult> Update(int id, UOMForUpdateVM viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _response = await _uomservice.Update(id, viewModel);
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
                _response = await _uomservice.Delete(id);
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
