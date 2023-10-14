using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using MVC.DataAccess.Repository;
using System.Text.RegularExpressions;
using MVC.DataAccess.Repository.IRepository;

namespace MVCPro.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unit;
        public CategoryController(IUnitOfWork unit)
        {
            _unit = unit;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _unit.Category.GetAll().ToList();
            return View(objCategoryList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "The DisplayOrder cannot exactly match the Name");
            }
            if (ModelState.IsValid)
            {
                _unit.Category.Add(obj);
                _unit.Save();
                TempData["success"] = "Category created successfully";
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
            Category categoryFromDb = _unit.Category.Get(u => u.Id == id);
            //Category? categoryFromDb1 = _db. Categories. FirstOrDefault (u=>u. Id==id);
            //Category? categoryFromDb2 = _db. Categories. Where (u=>u. Id==id). FirstOrDefault();k
            if (categoryFromDb == null)
            {
                return NotFound(id);
            }
            return View(categoryFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _unit.Category.Update(obj);
                _unit.Save();
                TempData["success"] = "Category updated successfully";
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
            Category categoryFromDb = _unit.Category.Get(u => u.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound(id);
            }
            return View(categoryFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Category obj = _unit.Category.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unit.Category.Remove(obj);
            _unit.Save();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
