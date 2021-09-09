using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SPortal.WebAPI.Model.Entities;
using SPortal.WebAPI.Model.Repositories;
using SPortal.WebAPI.Model.Repositories.Contract;

namespace SPortal.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController:ControllerBase
    {
        private ICategoryRepository _crepository = null;
        
        public CategoryController(ICategoryRepository crepository)
        {
            _crepository = crepository;
        }

        [HttpGet]
        public IEnumerable<Category> GetCategories(){
            return _crepository.GetCategories();
        }
    }
}