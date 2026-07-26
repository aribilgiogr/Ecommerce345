using Core.Abstracts.IServices;
using Core.Concretes.DTOs;
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

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

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

        public IActionResult RegisterCustomer()
        {
            return View();
        }

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

        public IActionResult RegisterStore()
        {
            return View();
        }

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

        [HttpPost, Authorize]
        public async Task<IActionResult> Logout()
        {
            await service.LogoutAsync();
            return RedirectToAction("index","home");
        }
    }
}
