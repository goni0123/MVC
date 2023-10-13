﻿using MVC.Models;
using MVCPro.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MVC.DataAccess.Repository.IRepository;

namespace MVC.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly AppDBContext _db;

        public CategoryRepository(AppDBContext db) : base(db)
        {
            _db = db;
        }


        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Category obj)
        {
            _db.categories.Update(obj);
        }
    }
}
