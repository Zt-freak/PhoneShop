using Moq;
using PhoneShop.Models;
using PhoneShop.Repository.Interfaces;
using PhoneShop.Service;
using Xunit;

namespace PhoneShop.Tests.BrandServiceTests
{
    [Collection("Sequential")]
    public class Delete
    {
        [Fact]
        public void ItShould_DeleteABrand_FromId ()
        {
            Mock<IRepository<Brand>> brandRepo = new();
            BrandService brandService = new(brandRepo.Object);

            brandRepo.Setup(br => br.GetById(It.IsAny<int>())).Returns(new Brand());
            brandService.Delete(5);

            brandRepo.Verify(br => br.GetById(It.IsAny<object>()), Times.Once);
            brandRepo.Verify(br => br.Remove(It.IsAny<Brand>()), Times.Once);
            brandRepo.Verify(br => br.SaveChanges(), Times.Once);
        }

        [Fact]
        public void ItShould_DeleteABrand_FromObject()
        {
            Mock<IRepository<Brand>> brandRepo = new();
            BrandService brandService = new(brandRepo.Object);

            brandRepo.Setup(br => br.GetById(It.IsAny<int>())).Returns(new Brand());
            brandService.Delete(new Brand());

            brandRepo.Verify(br => br.Remove(It.IsAny<Brand>()), Times.Once);
            brandRepo.Verify(br => br.SaveChanges(), Times.Once);
        }
    }
}
