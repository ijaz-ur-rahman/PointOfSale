﻿using Microsoft.AspNetCore.Mvc;
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
    public class PurchaseOrdersController : Controller
    {
        private readonly IPurchaseOrderService _baseService;
        private readonly ILookupService _lookupService;
        private ServiceResponse<object> _response;
        public PurchaseOrdersController(IPurchaseOrderService purchaseOrderService, ILookupService lookupService)
        {
            _baseService = purchaseOrderService;
            _lookupService = lookupService;
            _response = new ServiceResponse<object>();
        }
        public async Task<IActionResult> Index()
        {
            var responce = await _baseService.GetAll();
            return View(responce.Data);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Status = "Create";
            _response = await _lookupService.PurchaseOrderDrp("");
            ViewBag.CategoriesDrp = (SelectList)_response.Data;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(PurchaseOrderForCreateVM Vmodel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _response = await _baseService.Create(Vmodel);
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
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Status = "Update";
            var responce = await _baseService.GetById(id);
            _response = await _lookupService.PurchaseOrderDrp("");
            ViewBag.CategoriesDrp = (SelectList)_response.Data;
            return View("Create", responce.Data);

        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, PurchaseOrderForUpdateVM viewModel)
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
