using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SPortal.WebAPI.Model.Context;
using SPortal.WebAPI.Model.Entities;
using SPortal.WebAPI.Model.Repositories.Contract;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace SPortal.WebAPI.Model.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private SPortalContext _context = null;

        public CategoryRepository(SPortalContext context)
        {
            _context = context;
        }

        public void AddCategory(Category cat)
        {
            _context.Categories.Add(cat);
            _context.SaveChanges();
        }

        public bool EditCategory(Category cat)
        {
            _context.Categories.Update(cat);
            _context.SaveChanges();
            return true;
        }

        public virtual IEnumerable<Category> GetCategories()
        {
            if(_context.Categories.Count()<= 0)
                return Array.Empty<Category>();
            else
                return _context.Categories.AsNoTracking().AsEnumerable();
        }

        public IEnumerable<Category> GetCategoriesByName(string cname)
        {
            return _context.Categories.Where(x=>x.CName.StartsWith(cname)).AsNoTracking().AsEnumerable();
        }

        public Category GetCategoryByID(Guid cid)
        {
            return _context.Categories.AsNoTracking().Single(x=>x.CID == cid);
        }

        public Category GetCategoryByName(string cname)
        {
            Category c = _context.Categories.AsNoTracking().Single(x=>x.CName.Equals(cname));
            return c;
        }

        public bool RemoveCategory(Category cat)
        {
            throw new System.NotImplementedException();
        }
    }
}