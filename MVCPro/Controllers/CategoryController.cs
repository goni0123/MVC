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
    }
}
