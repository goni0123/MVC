using MVC.DataAccess.Repository.IRepository;
using MVCPro.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDBContext _db;
        public ICategoryRepository Category{ get; private set; }
        public UnitOfWork(AppDBContext db)
        {
            _db=db;
            Category = new CategoryRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
