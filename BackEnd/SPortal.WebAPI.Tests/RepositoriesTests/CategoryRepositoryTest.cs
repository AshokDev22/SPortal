using System;
using Xunit;
using SPortal.WebAPI.Model.Context;
using SPortal.WebAPI.Model.Repositories.Contract;
using Moq;
using SPortal.WebAPI.Model.Repositories;
using SPortal.WebAPI.Model.Entities;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Collections.Generic;

namespace SPortal.WebAPI.Tests.RepositoriesTests
{
    
    public class CategoryRepositoryTest
    {
        private ICategoryRepository catRep = null;
        private Mock<SPortalContext> contextMock = null;

        public CategoryRepositoryTest()
        {
            DbContextOptionsBuilder<SPortalContext> optionsBuilder = new DbContextOptionsBuilder<SPortalContext>();
            optionsBuilder.UseSqlServer("server=.;database=SPortal;user id=sa;pwd=sa");
            contextMock = new Mock<SPortalContext>(optionsBuilder.Options);
            
            catRep = new CategoryRepository(contextMock.Object);
        }
        
        [Fact]
        public void GetCategories_Should_ReturnEmpty()
        {
            //Arrange
            List<Category> catList = Enumerable.Empty<Category>().ToList();
            contextMock.Setup(x=>x.Categories).Returns(DbContextMock.GetQueryableMockDbSet<Category>(catList));
            //Act
            var result = catRep.GetCategories();

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
        
            contextMock.Setup(x=>x.Categories).Returns(DbContextMock.GetQueryableMockDbSet<Category>(catList));
            //Act
            var result = catRep.GetCategories();
            //cList[1].CName = "LMN";// = new Category{CID=Guid.NewGuid(),CName = "LMN"};//.Add(new Category{CID=Guid.NewGuid(),CName = "LMN"});
            //Assert
            result.Should().NotBeEmpty();
            
            result.Should().BeEquivalentTo(cList,options => options.ComparingByMembers<Category>());
        }
    }
}