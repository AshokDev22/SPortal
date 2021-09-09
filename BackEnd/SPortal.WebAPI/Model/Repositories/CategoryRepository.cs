using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SPortal.WebAPI.Model.Context;
using SPortal.WebAPI.Model.Entities;
using SPortal.WebAPI.Model.Repositories.Contract;

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
            throw new System.NotImplementedException();
        }

        public bool EditCategory(Category cat)
        {
            throw new System.NotImplementedException();
        }

        public virtual IEnumerable<Category> GetCategories()
        {
            if(_context.Categories.Count()<= 0)
                return Array.Empty<Category>();
            else
                return _context.Categories.AsEnumerable();
        }

        public IEnumerable<Category> GetCategoriesByName()
        {
            throw new System.NotImplementedException();
        }

        public Category GetCategoryByID()
        {
            throw new System.NotImplementedException();
        }

        public bool RemoveCategory(Category cat)
        {
            throw new System.NotImplementedException();
        }
    }
}