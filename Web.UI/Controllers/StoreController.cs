using Core.Abstracts.IServices;
using Core.Concretes.DTOs.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using System.Security.Claims;

namespace Web.UI.Controllers
{
    [Authorize]
    public class StoreController : Controller
    {
        private readonly IStoreProductService service;
        private readonly ICategoryService categoryService;
        private readonly IBrandService brandService;
        public StoreController(IStoreProductService service, ICategoryService categoryService, IBrandService brandService)
        {
            this.service = service;
            this.categoryService = categoryService;
            this.brandService = brandService;
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

            ViewBag.Categories = new SelectList(await categoryService.GetCategoriesAsync(), "Id", "Name");
            ViewBag.Brands = new SelectList(await brandService.GetBrandsAsync(), "Id", "Name");

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
            ViewBag.Categories = new SelectList(await categoryService.GetCategoriesAsync(), "Id", "Name", model.CategoryId);
            ViewBag.Brands = new SelectList(await brandService.GetBrandsAsync(), "Id", "Name", model.BrandId);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var storeId = await getCurrentStoreId();
            if (storeId == 0) return Forbid();

            if (!await service.DeleteProductAsync(id, storeId))
            {
                TempData["ErrorMessage"] = "Silme işlemi sırasında bir problem oluştu.";
            }
            return RedirectToAction("index");
        }

        public async Task<IActionResult> ProductDetail(int id)
        {
            var storeId = await getCurrentStoreId();
            if (storeId == 0) return Forbid();

            var model = await service.GetStoreProductAsync(id);

            return View(model);
        }

        public async Task<IActionResult> EditProduct(int id)
        {
            var storeId = await getCurrentStoreId();
            if (storeId == 0) return Forbid();

            var product = await service.GetStoreProductForEditAsync(id, storeId);
            if (product == null) return NotFound();

            ViewBag.Categories = new SelectList(await categoryService.GetCategoriesAsync(), "Id", "Name", product.CategoryId);
            ViewBag.Brands = new SelectList(await brandService.GetBrandsAsync(), "Id", "Name", product.BrandId);
            return View(product);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProduct(int id, UpdateProductDto model)
        {
            if (ModelState.IsValid)
            {
                var storeId = await getCurrentStoreId();
                if (storeId == 0) return Forbid();

                if (await service.UpdateProductAsync(model, storeId))
                    return RedirectToAction("index");

                ModelState.AddModelError(string.Empty, "Ürün güncelleme işlemi sırasında bir hata oluştu!");
            }
            ViewBag.Categories = new SelectList(await categoryService.GetCategoriesAsync(), "Id", "Name", model.CategoryId);
            ViewBag.Brands = new SelectList(await brandService.GetBrandsAsync(), "Id", "Name", model.BrandId);
            return View(model);
        }
    }
}
