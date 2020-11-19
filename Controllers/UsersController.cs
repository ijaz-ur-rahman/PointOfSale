using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using DatabaseService;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PointOfSale.DataService.Helpers;
using PointOfSale.DataService.IServices;
using PointOfSale.DataService.ViewModels;

namespace PointOfSale.Controllers
{
    [ValidateAntiForgeryToken]
    public class UsersController : BaseController
    {
        private readonly IUserService _userService;
        private readonly ILookupService _lookupService;
        private ServiceResponse _response;
        public UsersController(IUserService userService, ILookupService lookupService)
        {
            _userService = userService;
            _lookupService = lookupService;
            _response = new ServiceResponse();
        }
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var response = await _userService.GetAll();            
            return View(response.Data);
        }

        public ActionResult Login()
        {
            return View();
        }
        [AllowAnonymous, HttpPost]
        public async Task<ActionResult> Login(LoginVM loginVM)
        {
            try
            {
                dynamic response = await _userService.Login(loginVM);
                var claims = new List<Claim>
                {
                    new Claim("UserName", loginVM.UserName.ToLower()),
                    new Claim("UserId", response.Data.Id.ToString()),
                    new Claim("RoleId", response.Data.RoleId.ToString()),
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.UtcNow.AddHours(8)
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Message = ex.Message ?? ex.InnerException.ToString();
                return BadRequest(_response);

            }
        }

        public async Task<ActionResult> Signout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok(true);
        }

        // GET: UsersController/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: UsersController/Create
        [HttpPost]
        public async Task<ActionResult> Create(UserForCreateVM viewModel)
        {
            try
            {
                ViewBag.Status = "Create";
                _response = await _userService.Create(viewModel);
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
            var response = await _userService.GetById(id);
            return View("Create", response.Data);
        }
        // POST: UsersController/Edit/5
        [HttpPut]
        public async Task<ActionResult> Update(int id, UserForUpdateVM collection)
        {
            try
            {
                _response = await _userService.Update(id, collection);
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Message = ex.Message ?? ex.InnerException.ToString();
                return BadRequest(_response);
            }
        }


        // POST: UsersController/Delete/5
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                _response = await _userService.Delete(id);

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
