using System;
using SPortal.WebAPI.Controllers;
using SPortal.WebAPI.Model.Entities;
using SPortal.WebAPI.Model.Repositories;
using SPortal.WebAPI.Model.Repositories.Contract;
using SPortal.WebAPI.Model.Context;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;

namespace SPortal.WebAPI.Tests.ControllersTests
{
    public class CategoryControllersTests
    {
        private readonly Mock<CategoryRepository> cmrepository = null;
        public CategoryControllersTests()
        {
            DbContextOptionsBuilder<SPortalContext> optionsBuilder = new DbContextOptionsBuilder<SPortalContext>();
            optionsBuilder.UseSqlServer("server=.;database=SPortal;user id=sa;pwd=sa");
            var ctx = new Mock<SPortalContext>(optionsBuilder.Options);
            cmrepository = new Mock<CategoryRepository>(ctx.Object);
        }

        [Fact]
        public void GetCategories_Should_ReturnEmpty()
        {
            //Arrange
            cmrepository.Setup(x=>x.GetCategories()).Returns(Enumerable.Empty<Category>());
            var controller = new CategoryController(cmrepository.Object);
            //Act
            var result = controller.GetCategories();

            //Assert
            result.Should().BeEmpty();
        }

        [Fact]
        public void GetCategories_Should_ReturnAllCategory()
        {

            //Arrange
            List<Category> catList = new List<Category>{
                new Category{CID = Guid.NewGuid(),CName = "ABC",Products = new List<Product>()},
                new Category{CID = Guid.NewGuid(),CName = "DEF",Products = new List<Product>()},
                new Category{CID = Guid.NewGuid(),CName = "XYZ",Products = new List<Product>()}
            };
            List<Category> cList = catList.ConvertAll(x=>new Category(x));

            cmrepository.Setup(x=>x.GetCategories()).Returns(catList.AsEnumerable<Category>());
            var controller = new CategoryController(cmrepository.Object);
            //Act
            var result = controller.GetCategories();

            //cList[1].CName = "LMN";
            //Assert
            result.Should().NotBeEmpty();
            result.Should().BeEquivalentTo(cList,options=>options.ComparingByMembers<Category>());
        }
    }
}