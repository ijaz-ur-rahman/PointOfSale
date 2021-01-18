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
    //[Route("[controller]")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly ILookupService _lookupService;
        private ServiceResponse<object> _response;
        public CategoriesController(ICategoryService categoryService, ILookupService lookupService)
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
            HeadingModel.SetHeading("Create Category");
            ViewBag.Heading = "Create Category";
            _response = await _lookupService.CategoriesDrp("");
            ViewBag.CategoriesDrp = (SelectList)_response.Data;
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(CategoryForCreateVM viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
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
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            HeadingModel.Heading = "Update Category";
            ViewBag.Status = "Update";
            var response = await _categoryService.GetById(id);
            _response = await _lookupService.CategoriesDrp(response.Data.ParentCategoryId);
            ViewBag.CategoriesDrp = (SelectList)_response.Data;
            return View("Create", response.Data);
        }
        [HttpPut]
        public async Task<ActionResult> Update(int id, CategoryForUpdateVM viewModel)
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

    }
}
