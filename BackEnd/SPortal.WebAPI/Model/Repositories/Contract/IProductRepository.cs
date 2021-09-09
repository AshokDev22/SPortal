
using System;
using System.Collections.Generic;
using SPortal.WebAPI.Model.Entities;

namespace SPortal.WebAPI.Model.Repositories.Contract
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        IEnumerable<Product> GetProductsByName();
        IEnumerable<Product> GetProductsByCategory();
        IEnumerable<Product> GetProductsByCondition(Func<Product,bool> predicate);
        Product GetProductByID();

        void AddProduct(Product prd);

        bool EditProduct(Product prd);
        bool RemoveProduct(Product prd);

    }
}