using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SPortal.WebAPI.Model.Entities
{
    /// <summary>
    /// This class deals with Products in the API
    /// </summary>
    public class Product
    {

        public Product()
        {
            PID = Guid.NewGuid();
            PName = "";
            Price = 0.0f;
            AvailableQuantity = 0;
            PCategory = new Category();
            CatID = PCategory.CID;
        }
        public Product(Product p)
        {
            PID = p.PID;
            PName = p.PName;
            Price = p.Price;
            AvailableQuantity = p.AvailableQuantity;
            PCategory = p.PCategory;
            CatID = p.CatID;
        }

        /// <summary>
        /// This property gets and sets Product ID which will be Global Unique Identifier(Guid)
        /// </summary>
        /// <value>Auto Generated</value>
        [Key]
        public Guid PID{get;set;}

        /// <summary>
        /// This property gets and sets Product Name.
        /// </summary>
        /// <value>Product Name</value>
        public string PName{get;set;}
        
        /// <summary>
        /// This property gets or sets Category ID of Category in which the product belongs
        /// </summary>
        /// <value>Linked with the existed category.</value>
        [ForeignKey("PCategory")]
        public Guid CatID{get;set;}

        /// <summary>
        /// This property gets ot sets Rate of the Product.
        /// </summary>
        /// <value>Rate of the product</value>
        public float Price{get;set;}

        /// <summary>
        /// This property gets or sets available stock of the product.
        /// </summary>
        /// <value>Available Stock</value>
        public int AvailableQuantity{get;set;} 

        /// <summary>
        /// This is navigation property that gets or sets Category information in which the product belongs.
        /// </summary>
        /// <value>Can be navigated to category information of product</value>  
        public Category PCategory{get;set;}

        public override bool Equals(object obj)
        {
            if(obj == null)
                return false;
            if(!(obj is Product))
                return false;
            return (this.PName.Equals((obj as Product).PName)) && (this.PCategory.Equals((obj as Product).PCategory));
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}