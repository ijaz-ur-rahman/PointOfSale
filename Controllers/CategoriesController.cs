using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PointOfSale.DataService.Helpers;
using PointOfSale.DataService.IServices;
using PointOfSale.DataService.ViewModels;

namespace PointOfSale.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly ILookupService _lookupService;
        private ServiceResponse _response;
        public CategoriesController(ICategoryService categoryService, ILookupService lookupService)
        {
            _categoryService = categoryService;
            _lookupService = lookupService;
            _response = new ServiceResponse();
        }
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var response = await _categoryService.GetAll();
            return View(response.Data);
        }
        public async Task<IActionResult> CreateAsync()
        {
            ViewBag.CategoriesDrp = await _lookupService.CategoriesDrp("");
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(CategoryVM viewModel)
        {
            try
            {
                ViewBag.Status = "Create";
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
        [HttpGet("Edit/{id}")]
        public async Task<ActionResult> Edit(int id)
        {
            ViewBag.Status = "Update";
            var response = await _categoryService.GetById(id);
            return View("Create", response.Data);
        }
        // POST: UsersController/Edit/5
        [HttpPut]
        public async Task<ActionResult> Update(int id, CategoryVM viewModel)
        {
            try
            {                
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

    }
}
