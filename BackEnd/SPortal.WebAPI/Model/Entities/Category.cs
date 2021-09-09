using System;
using System.Collections.Generic;

namespace SPortal.WebAPI.Model.Entities
{
    public class Category
    {

        public Category()
        {
            this.CID = Guid.NewGuid();
            this.CName = "";
            this.Products = new List<Product>();
        }
        public Category(Category c)
        {
            this.CID = c.CID;
            this.CName = c.CName;
            this.Products = ((List<Product>)c.Products).ConvertAll(x=> new Product(x));
        }
        public Guid CID{get;set;}
        public string CName{get;set;}
        public IEnumerable<Product> Products{get;set;}


    }
}