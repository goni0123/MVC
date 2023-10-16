using Microsoft.AspNetCore.Mvc;
using MVC.DataAccess.Repository.IRepository;
using MVC.Models;

namespace MVCPro.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unit;
        public ProductController(IUnitOfWork unit)
        {
            _unit = unit;
        }
        public IActionResult Index()
        {
            List<Product> objCategoryList = _unit.Product.GetAll().ToList();
            return View(objCategoryList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product obj)
        {
            if (ModelState.IsValid)
            {
                _unit.Product.Add(obj);
                _unit.Save();
                TempData["success"] = "Product created successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Edit(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product ProductFromDb = _unit.Product.Get(u => u.Id == id);
            //Product? ProductFromDb1 = _db. Categories. FirstOrDefault (u=>u. Id==id);
            //Product? ProductFromDb2 = _db. Categories. Where (u=>u. Id==id). FirstOrDefault();k
            if (ProductFromDb == null)
            {
                return NotFound(id);
            }
            return View(ProductFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Product obj)
        {
            if (ModelState.IsValid)
            {
                _unit.Product.Update(obj);
                _unit.Save();
                TempData["success"] = "Product updated successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product ProductFromDb = _unit.Product.Get(u => u.Id == id);
            if (ProductFromDb == null)
            {
                return NotFound(id);
            }
            return View(ProductFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Product obj = _unit.Product.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unit.Product.Remove(obj);
            _unit.Save();
            TempData["success"] = "Product deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
