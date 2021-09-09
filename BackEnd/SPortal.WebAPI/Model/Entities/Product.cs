using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SPortal.WebAPI.Model.Entities
{
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
        [Key]
        public Guid PID{get;set;}
        public string PName{get;set;}
        [ForeignKey("PCategory")]
        public Guid CatID{get;set;}
        public float Price{get;set;}
        public int AvailableQuantity{get;set;}   
        public Category PCategory{get;set;}
    }
}