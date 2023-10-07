using Microsoft.AspNetCore.Mvc;
using MVCPro.Data;
using MVCPro.Models;

namespace MVCPro.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDBContext _db;
        public CategoryController(AppDBContext db) 
        { 
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.categories.ToList(); 
            return View(objCategoryList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {   
            if (!ModelState.IsValid)
            {
                _db.categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
