using Core.Abstracts.IServices;
using Core.Concretes.DTOs.Product;
using Microsoft.AspNetCore.Mvc;

namespace Web.UI.Areas.AdminDashboard.Controllers
{
    [Area("AdminDashboard")]
    public class BrandController(IBrandService service) : Controller
    {
        // GET: BrandController
        public async Task<ActionResult> Index()
        {
            return View(await service.GetBrandsAsync());
        }

        // GET: BrandController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BrandController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateBrandDto model)
        {
            if (ModelState.IsValid)
            {
                var result = await service.CreateBrandAsync(model);
                if (result)
                {
                    return RedirectToAction("index");
                }
                ModelState.AddModelError(string.Empty, "Marka eklenemedi!");
            }
            return View(model);
        }

        // GET: BrandController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var brand = await service.GetBrandByIdAsync(id);
            if (brand == null) return NotFound();
            return View(brand);
        }

        // POST: BrandController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, UpdateBrandDto model)
        {
            if (ModelState.IsValid)
            {
                var result = await service.UpdateBrandAsync(model);
                if (result)
                {
                    return RedirectToAction("index");
                }
                ModelState.AddModelError(string.Empty, "Marka güncellenemedi!");
            }
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await service.DeleteBrandAsync(id);
            return RedirectToAction("index");
        }
    }
}
