using Moq;
using PhoneShop.Models;
using PhoneShop.Repository.Interfaces;
using PhoneShop.Service;
using System;
using System.Collections.Generic;
using Xunit;

namespace PhoneShop.Tests.DepartmentServiceTests
{
    [Collection("Sequential")]
    public class Update
    {
        [Fact]
        public void ItShould_UpdateABrand_FromIdAndNameString()
        {
            Mock<IRepository<Department>> departmentRepo = new();
            DepartmentService departmentService = new(departmentRepo.Object);
            departmentRepo.Setup(m => m.GetById(It.IsAny<int>())).Returns(new Department() { Id = 5, Name = "unchanged" });
            departmentRepo.Setup(m => m.Update(It.IsAny<Department>())).Returns((Department input) => input);

            Department result = departmentService.Update(5, "changed");

            Assert.Equal("changed", result.Name);
        }

        [Fact]
        public void ItShould_UpdateABrand_FromObject()
        {
            Mock<IRepository<Department>> departmentRepo = new();
            DepartmentService departmentService = new(departmentRepo.Object);
            departmentRepo.Setup(m => m.Update(It.IsAny<Department>())).Returns((Department input) => input);

            Department result = departmentService.Update(new Department()
            {
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
            Mock<IRepository<Department>> departmentRepo = new();
            DepartmentService departmentService = new(departmentRepo.Object);

            Assert.Throws<ArgumentException>(() => departmentService.Update(inputId, "changed"));
        }

        [Fact]
        public void ItShould_ThrowException_WhenDepartmentNotFound()
        {
            Mock<IRepository<Department>> departmentRepo = new();
            DepartmentService departmentService = new(departmentRepo.Object);

            departmentRepo.Setup(br => br.GetById(It.IsAny<int>())).Returns(() => null);

            Assert.Throws<KeyNotFoundException>(() => departmentService.Update(5, "changed"));

        }
    }
}
