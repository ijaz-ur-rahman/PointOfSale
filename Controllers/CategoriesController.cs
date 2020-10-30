using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PointOfSale.DataService.ViewModels;

namespace PointOfSale.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }       
        public IActionResult Craete()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Craete(CategoryVM viewModel)
        {
            return View();
        }
    }
}
