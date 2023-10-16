using MVC.DataAccess.Repository.IRepository;
using MVC.Models;
using MVCPro.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly AppDBContext _db;
        public ProductRepository(AppDBContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Product obj)
        {
            _db.products.Update(obj);
        }
    }
}
