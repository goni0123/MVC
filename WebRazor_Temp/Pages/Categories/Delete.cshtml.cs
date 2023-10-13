using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MVC.Models;
using MVCPro.DataAccess.Data;

namespace WebRazor_Temp.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        public AppDBContext _db;
        public Category Category { get; set; }
        public DeleteModel(AppDBContext db)
        {
            _db = db;
        }
        public void OnGet(int? id)
        {
            if (id != null && id != 0)
            {
                Category = _db.categories.Find(id);
            }
        }
        public IActionResult OnPost()
        {
            Category? obj=_db.categories.Find(Category.Id);
            if (obj==null)
            {
                return NotFound();
            }
            _db.categories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Deleted successfully";
            return RedirectToPage("Index");
        }
    }
}
