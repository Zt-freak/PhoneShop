using Moq;
using PhoneShop.Models;
using PhoneShop.Repository.Interfaces;
using PhoneShop.Service;
using System;
using System.Collections.Generic;
using Xunit;

namespace PhoneShop.Tests.BrandServiceTests
{
    [Collection("Sequential")]
    public class Update
    {
        [Fact]
        public void ItShould_UpdateABrand_FromIdAndNameString()
        {
            Mock<IRepository<Brand>> brandRepo = new();
            BrandService brandService = new(brandRepo.Object);
            brandRepo.Setup(m => m.GetById(It.IsAny<int>())).Returns(new Brand() { Id = 5, Name = "unchanged" });
            brandRepo.Setup(m => m.Update(It.IsAny<Brand>())).Returns((Brand input) => input);

            Brand result = brandService.Update(5, "changed");

            Assert.Equal("changed", result.Name);
        }

        [Fact]
        public void ItShould_UpdateABrand_FromObject()
        {
            Mock<IRepository<Brand>> brandRepo = new();
            BrandService brandService = new(brandRepo.Object);
            brandRepo.Setup(m => m.Update(It.IsAny<Brand>())).Returns((Brand input) => input);

            Brand result = brandService.Update(new Brand(){
                Id = 5,
                Name = "changed"
            });

            Assert.Equal("changed", result.Name);
        }

        [Theory]
        [InlineData(int.MinValue)]
        [InlineData(-2)]
        [InlineData(0)]
        public void ItShould_ThrowArgumentException_WhenIdIsInValid(int inputId)
        {
            Mock<IRepository<Brand>> brandRepo = new();
            BrandService brandService = new(brandRepo.Object);

            Assert.Throws<ArgumentException>(() => brandService.Update(inputId, "changed"));
        }

        [Fact]
        public void ItShould_ThrowException_WhenBrandNotFound()
        {
            Mock<IRepository<Brand>> brandRepo = new();
            BrandService brandService = new(brandRepo.Object);

            brandRepo.Setup(br => br.GetById(It.IsAny<int>())).Returns(() => null);

            Assert.Throws<KeyNotFoundException>(() => brandService.Update(5, "changed"));

        }
    }
}
