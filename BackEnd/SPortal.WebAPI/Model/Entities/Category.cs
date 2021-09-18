using System;
using System.Collections.Generic;

namespace SPortal.WebAPI.Model.Entities
{    
    /// <summary>
    /// The class deals with categories of product.
    /// </summary>
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

        /// <summary>
        /// The property gets and sets Category ID which will be Global Unique Identifier(Guid)
        /// </summary>
        /// <value>Auto-Generated Value</value>
        public Guid CID{get;set;}
        /// <summary>
        /// The property gets  and set Category name.
        /// </summary>
        /// <value>Name of Category</value>
        public string CName{get;set;}

        /// <summary>
        /// The navigation property which gets or sets list of Products for a particular Category.
        /// </summary>
        /// <value>Collection of Product.</value>
        public IEnumerable<Product> Products{get;set;}

        public override bool Equals(object obj)
        {
            if((obj ==null))
            {
                return false;
            }
            if(!(obj is Category))
            {
                return  false;
            }
            return this.CName.Equals((obj as Category).CName);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}