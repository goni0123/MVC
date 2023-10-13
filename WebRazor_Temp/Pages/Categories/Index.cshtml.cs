using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MVC.Models;
using MVCPro.DataAccess.Data;

namespace WebRazor_Temp.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly AppDBContext _db;
        public List<Category> CategoryList { get; set; }
        public IndexModel(AppDBContext db)
        {
            _db = db;            
        }
        public void OnGet()
        {
            CategoryList=_db.categories.ToList();
        }
    }
}
