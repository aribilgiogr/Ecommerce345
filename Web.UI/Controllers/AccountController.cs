using Core.Abstracts.IServices;
using Core.Concretes.DTOs.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthService service;

        public AccountController(IAuthService service)
        {
            this.service = service;
        }

        // /account/index
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        // /account/login
        public IActionResult Login()
        {
            return View();
        }

        // /account/login
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginDto model)
        {
            if (ModelState.IsValid)
            {
                var response = await service.LoginAsync(model);
                if (response.IsSuccessful)
                {
                    return RedirectToAction("index");
                }
                foreach (var err in response.Errors!)
                {
                    ModelState.AddModelError(string.Empty, err);
                }
            }
            return View(model);
        }

        // /account/registercustomer
        public IActionResult RegisterCustomer()
        {
            return View();
        }

        // /account/registercustomer
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterCustomer(RegisterCustomerDto model)
        {
            if (ModelState.IsValid)
            {
                var response = await service.RegisterCustomerAsync(model);
                if (response.IsSuccessful)
                {
                    return RedirectToAction("index");
                }
                foreach (var err in response.Errors!)
                {
                    ModelState.AddModelError(string.Empty, err);
                }
            }
            return View(model);
        }

        // /account/registerstore
        public IActionResult RegisterStore()
        {
            return View();
        }

        // /account/registerstore
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterStore(RegisterStoreDto model)
        {
            if (ModelState.IsValid)
            {
                var response = await service.RegisterStoreAsync(model);
                if (response.IsSuccessful)
                {
                    return RedirectToAction("index");
                }
                foreach (var err in response.Errors!)
                {
                    ModelState.AddModelError(string.Empty, err);
                }
            }
            return View(model);
        }

        // /account/logout
        [HttpPost, Authorize]
        public async Task<IActionResult> Logout()
        {
            await service.LogoutAsync();
            return RedirectToAction("index", "home");
        }

        // /account/accessdenied
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
