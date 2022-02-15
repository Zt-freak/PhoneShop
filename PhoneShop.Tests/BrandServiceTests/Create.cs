using Moq;
using PhoneShop.Models;
using PhoneShop.Repository.Interfaces;
using PhoneShop.Service;
using System;
using Xunit;

namespace PhoneShop.Tests.BrandServiceTests
{
    [Collection("Sequential")]
    public class Create
    {
        [Fact]
        public void ItShould_CreateANewBrand_FromNameString()
        {
            Mock<IRepository<Brand>> brandRepo = new();
            BrandService brandService = new(brandRepo.Object);

            Brand newBrand = brandService.Create("test");

            brandRepo.Verify(br => br.Insert(It.IsAny<Brand>()), Times.Once);
            brandRepo.Verify(br => br.SaveChanges(), Times.Once);
            Assert.Equal("test", newBrand.Name);
        }

        [Fact]
        public void ItShould_CreateANewBrand_FromBrandObject()
        {
            Mock<IRepository<Brand>> brandRepo = new();
            BrandService brandService = new(brandRepo.Object);

            Brand newBrand = brandService.Create(new Brand() { Name = "test" });

            brandRepo.Verify(br => br.Insert(It.IsAny<Brand>()), Times.Once);
            brandRepo.Verify(br => br.SaveChanges(), Times.Once);
            Assert.Equal("test", newBrand.Name);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("   ")]
        [InlineData("\n")]
        [InlineData(null)]
        public void ItShould_ThrowArgumentNullException_WhenNameIsEmpty(string inputName)
        {
            Mock<IRepository<Brand>> brandRepo = new();
            BrandService brandService = new(brandRepo.Object);

            Assert.Throws<ArgumentNullException>(() => brandService.Create(new Brand() { Name = inputName }));
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("   ")]
        [InlineData("\n")]
        [InlineData(null)]
        public void ItShould_ThrowArgumentNullException_WhenNameIsEmptyWithStringInput(string inputName)
        {
            Mock<IRepository<Brand>> brandRepo = new();
            BrandService brandService = new(brandRepo.Object);

            Assert.Throws<ArgumentNullException>(() => brandService.Create(inputName));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(12)]
        [InlineData(1312)]
        [InlineData(int.MaxValue)]
        public void ItShould_ThrowArgumentException_WhenIdIsSet(int inputId)
        {
            Mock<IRepository<Brand>> brandRepo = new();
            BrandService brandService = new(brandRepo.Object);

            Assert.Throws<ArgumentException>(() => brandService.Create(new Brand() { Id = inputId, Name = "test" }));
        }
    }
}
