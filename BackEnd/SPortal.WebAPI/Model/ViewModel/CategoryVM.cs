using System.ComponentModel.DataAnnotations;

namespace SPortal.WebAPI.Model.ViewModel
{
    public class CategoryVM
    {
        [Required(ErrorMessage ="Please enter category name.")]
        [RegularExpression("^[A-Z]{1}[a-zA-Z' ]*$",ErrorMessage ="Category name should include alphabets with single quotes and spaces")]
        public string CName{get;set;}
    }
}