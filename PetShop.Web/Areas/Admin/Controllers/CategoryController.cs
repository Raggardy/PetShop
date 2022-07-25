using Microsoft.AspNetCore.Mvc;
using PetShop.DataAccess;
using PetShop.DataAccess.Repository.IRepository;
using PetShop.Models;

namespace PetShop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _db;

        public CategoryController(ICategoryRepository db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Category> categories = await _db.GetAll();
            return View(categories);
        }

        // GET
        public IActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _db.Add(category);
                _db.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            // Remember, Find() will only retrieve the PRIMARY key
            var category = await _db.GetEntityById(x => x.Id == id);

            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _db.Update(category);
                _db.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        public IActionResult Delete(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            var category = _db.GetEntityById(x => x.Id == id);

            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteObject(int? id)
        {
            var category = await _db.GetEntityById(x => x.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            _db.Delete(category);
            _db.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
