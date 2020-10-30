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
    public class UsersController : BaseController
    {
        private readonly IUserService _userService;
        private ServiceResponse _response;
        public UsersController(IUserService userService)
        {
            _userService = userService;
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
                _response.Data = ex.Message ?? ex.InnerException.ToString();
                return BadRequest(_response);

            }
        }

        public async Task<ActionResult> SignoutAsync()
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
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(UserForCreateVM collection)
        {
            try
            {
                ViewBag.Status = "Create";
                _response = await _userService.Create(collection);
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Data = ex.Message ?? ex.InnerException.ToString();
                return BadRequest(_response);
            }
        }

        [HttpGet("Edit/{id}")]
        public async Task<ActionResult> Edit(int id)
        {
            var response = await _userService.GetById(id);
            return View("Create", response.Data);
        }
        // POST: UsersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(int id, UserForUpdateVM collection)
        {
            try
            {
                ViewBag.Status = "Update";
                _response = await _userService.Update(id, collection);
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Data = ex.Message ?? ex.InnerException.ToString();
                return BadRequest(_response);
            }
        }


        // POST: UsersController/Delete/5
        [HttpDelete]
        [ValidateAntiForgeryToken]
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
                _response.Data = ex.Message ?? ex.InnerException.ToString();
                return BadRequest(_response);
            }
        }
    }
}
