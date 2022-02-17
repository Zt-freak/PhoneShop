using Moq;
using PhoneShop.Models;
using PhoneShop.Repository.Interfaces;
using PhoneShop.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PhoneShop.Tests.DepartmentServiceTests
{
    [Collection("Sequential")]
    public class Get
    {
        [Fact]
        public void ItShould_GetABrand_ById()
        {
            Mock<IRepository<Department>> departmentRepo = new();
            DepartmentService departmentService = new(departmentRepo.Object);
            departmentRepo.Setup(br => br.GetById(It.IsAny<int>())).Returns(new Department() { Id = 5 });

            Department result = departmentService.Get(5);

            departmentRepo.Verify(br => br.GetById(It.IsAny<int>()), Times.Once);
            Assert.Equal(5, result.Id);
        }

        [Fact]
        public void ItShould_GetAllBrands()
        {
            Mock<IRepository<Department>> departmentRepo = new();
            DepartmentService departmentService = new(departmentRepo.Object);
            departmentRepo.Setup(br => br.GetAll()).Returns(new List<Department>() { new Department(), new Department(), new Department() }.AsQueryable());

            List<Department> result = departmentService.GetAll().ToList();

            departmentRepo.Verify(br => br.GetAll(), Times.Once);
            Assert.Equal(3, result.Count);
        }

        [Theory]
        [InlineData(int.MinValue)]
        [InlineData(-2)]
        [InlineData(0)]
        public void ItShould_ThrowArgumentException_WhenIdIsInValid(int inputId)
        {
            Mock<IRepository<Department>> departmentRepo = new();
            DepartmentService departmentService = new(departmentRepo.Object);

            Assert.Throws<ArgumentException>(() => departmentService.Get((int)inputId));
        }

        [Fact]
        public void ItShould_ThrowException_WhenBrandNotFound()
        {
            Mock<IRepository<Department>> departmentRepo = new();
            DepartmentService departmentService = new(departmentRepo.Object);

            departmentRepo.Setup(br => br.GetById(It.IsAny<int>())).Returns(() => null);

            Assert.Throws<KeyNotFoundException>(() => departmentService.Get(5));

        }
    }
}
