using Core.Abstracts.IServices;
using Core.Concretes.DTOs.Product;
using Microsoft.AspNetCore.Mvc;

namespace Web.UI.Areas.AdminDashboard.Controllers
{
    [Area("AdminDashboard")]
    public class CategoryController(ICategoryService service) : Controller
    {
        // GET: CategoryController
        public async Task<ActionResult> Index()
        {
            return View(await service.GetCategoriesAsync());
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateCategoryDto model)
        {
            if (ModelState.IsValid)
            {
                var result = await service.CreateCategoryAsync(model);
                if (result)
                {
                    return RedirectToAction("index");
                }
                ModelState.AddModelError(string.Empty, "Kategori eklenemedi!");
            }
            return View(model);
        }

        // GET: CategoryController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var category = await service.GetCategoryByIdAsync(id);
            if (category == null) return NotFound();
            return View(category);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, UpdateCategoryDto  model)
        {
            if (ModelState.IsValid)
            {
                var result = await service.UpdateCategoryAsync(model);
                if (result)
                {
                    return RedirectToAction("index");
                }
                ModelState.AddModelError(string.Empty, "Kategori güncellenemedi!");
            }
            return View(model);
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await service.DeleteCategoryAsync(id);
            return RedirectToAction("index");
        }
    }
}
