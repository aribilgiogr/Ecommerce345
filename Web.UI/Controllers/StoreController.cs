using Core.Abstracts.IServices;
using Core.Concretes.DTOs.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Web.UI.Controllers
{
    [Authorize]
    public class StoreController : Controller
    {
        private readonly IStoreProductService service;

        public StoreController(IStoreProductService service)
        {
            this.service = service;
        }

        private async Task<int> getCurrentStoreId()
        {
            string? user_id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (user_id != null)
            {
                return await service.GetCurrentStoreIdAsync(user_id);
            }
            return 0;
        }

        public async Task<IActionResult> Index()
        {
            var storeId = await getCurrentStoreId();
            if (storeId == 0) return Forbid();

            return View(await service.GetStoreProductsAsync(storeId));
        }

        public async Task<IActionResult> CreateProduct()
        {
            var storeId = await getCurrentStoreId();
            if (storeId == 0) return Forbid();
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProduct(CreateProductDto model)
        {
            if (ModelState.IsValid)
            {
                var storeId = await getCurrentStoreId();
                if (storeId == 0) return Forbid();

                if (await service.CreateProductAsync(model, storeId))
                    return RedirectToAction("index");

                ModelState.AddModelError(string.Empty, "Ürün kayıt işlemi sırasında bir hata oluştu!");
            }
            return View(model);
        }
    }
}
