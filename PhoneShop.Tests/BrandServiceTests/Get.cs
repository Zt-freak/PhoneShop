using Moq;
using PhoneShop.Models;
using PhoneShop.Repository.Interfaces;
using PhoneShop.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PhoneShop.Tests.BrandServiceTests
{
    [Collection("Sequential")]
    public class Get
    {
        [Fact]
        public void ItShould_GetABrand_ById()
        {
            Mock<IRepository<Brand>> brandRepo = new();
            BrandService brandService = new(brandRepo.Object);
            brandRepo.Setup(br => br.GetById(It.IsAny<int>())).Returns(new Brand() { Id = 5});

            Brand result = brandService.Get(5);

            brandRepo.Verify(br => br.GetById(It.IsAny<int>()), Times.Once);
            Assert.Equal(5, result.Id);
        }

        [Fact]
        public void ItShould_GetAllBrands()
        {
            Mock<IRepository<Brand>> brandRepo = new();
            BrandService brandService = new(brandRepo.Object);
            brandRepo.Setup(br => br.GetAll()).Returns(new List<Brand>() { new Brand(), new Brand(), new Brand() }.AsQueryable());

            List<Brand> result = brandService.GetAll().ToList();

            brandRepo.Verify(br => br.GetAll(), Times.Once);
            Assert.Equal(3, result.Count);
        }

        [Theory]
        [InlineData(int.MinValue)]
        [InlineData(-2)]
        [InlineData(0)]
        public void ItShould_ThrowArgumentException_WhenIdIsInValid(int inputId)
        {
            Mock<IRepository<Brand>> brandRepo = new();
            BrandService brandService = new(brandRepo.Object);

            Assert.Throws<ArgumentException>(() => brandService.Get((int)inputId));
        }

        [Fact]
        public void ItShould_ThrowException_WhenBrandNotFound()
        {
            Mock<IRepository<Brand>> brandRepo = new();
            BrandService brandService = new(brandRepo.Object);

            brandRepo.Setup(br => br.GetById(It.IsAny<int>())).Returns(() => null);

            Assert.Throws<KeyNotFoundException>(() => brandService.Get(5));

        }
    }
}
