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
    public class ReceivablesController : Controller
    {
        private readonly IReceivableService _receivable;
        private readonly ILookupService _lookupservice;
        private ServiceResponse<object> _serviceresponce;
        public ReceivablesController(IReceivableService receivableService,ILookupService lookupService)
        {
            _receivable = receivableService;
            _lookupservice = lookupService;
            _serviceresponce = new ServiceResponse<object>();
        }
        public async Task<IActionResult> Index()
        {
            var responce = await _receivable.GetAll();
            return View(responce.Data);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Status = "Create";
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ReceivableForCreateVM Vmodel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _serviceresponce = await _receivable.Create(Vmodel);
                return Ok(_serviceresponce);
            }
            catch (Exception ex)
            {
                _serviceresponce.Success = false;
                _serviceresponce.Message = ex.Message ?? ex.InnerException.ToString();
                return BadRequest(_serviceresponce);
            }
        }
        [HttpGet]
        public async Task<IActionResult>Edit(int id)
        {
            ViewBag.Status = "Update";
            var responce = await _receivable.GetById(id);
            return View("Create", responce.Data);
        }
        [HttpPost]
        public async Task<IActionResult>Update(int id,ReceivableForUpdateVM viewmodel)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _serviceresponce = await _receivable.Update(id, viewmodel);
                return Ok(_serviceresponce);
            }
            catch (Exception ex)
            {

                _serviceresponce.Success = false;
                _serviceresponce.Message = ex.Message ?? ex.InnerException.ToString();
                return BadRequest(_serviceresponce);
            }
        }
        [HttpDelete]
        public async Task<IActionResult>Delete(int id)
        {
            try
            {
                _serviceresponce = await _receivable.Delete(id);
                return Ok(_serviceresponce);
            }
            catch (Exception ex)
            {

                _serviceresponce.Success = false;
                _serviceresponce.Message = ex.Message ?? ex.InnerException.ToString();
                return BadRequest(_serviceresponce);
            }
        }
    }
}
