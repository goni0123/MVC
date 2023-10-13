using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MVC.Models;
using MVCPro.DataAccess.Data;

namespace WebRazor_Temp.Pages.Categories
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly AppDBContext _db;
        public Category Category { get; set; }
        public CreateModel(AppDBContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            
        }
        public IActionResult OnPost()
        {
            _db.categories.Add(Category);
            _db.SaveChanges(); 
            TempData["success"] = "Created successfully";
            return RedirectToPage("Index");
        }
    }
}
