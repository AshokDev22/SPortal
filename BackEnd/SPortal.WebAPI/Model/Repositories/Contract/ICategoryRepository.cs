
using System.Collections.Generic;
using SPortal.WebAPI.Model.Entities;

namespace SPortal.WebAPI.Model.Repositories.Contract
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetCategories();
        IEnumerable<Category> GetCategoriesByName();
        Category GetCategoryByID();

        void AddCategory(Category cat);

        bool EditCategory(Category  cat);
        bool RemoveCategory(Category cat);

    }
}