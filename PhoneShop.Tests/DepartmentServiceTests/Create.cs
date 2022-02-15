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
    public class Create
    {
        [Fact]
        public void ItShould_CreateANewDepartment_FromNameString()
        {
            Mock<IRepository<Department>> departmentRepo = new();
            DepartmentService departmentService = new(departmentRepo.Object);

            Department newDepartment = departmentService.Create("test");

            departmentRepo.Verify(br => br.Insert(It.IsAny<Department>()), Times.Once);
            departmentRepo.Verify(br => br.SaveChanges(), Times.Once);
            Assert.Equal("test", newDepartment.Name);
        }

        [Fact]
        public void ItShould_CreateANewDepartment_FromObject()
        {
            Mock<IRepository<Department>> departmentRepo = new();
            DepartmentService departmentService = new(departmentRepo.Object);

            Department newDepartment = departmentService.Create(new Department() { Name = "test" });

            departmentRepo.Verify(br => br.Insert(It.IsAny<Department>()), Times.Once);
            departmentRepo.Verify(br => br.SaveChanges(), Times.Once);
            Assert.Equal("test", newDepartment.Name);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("   ")]
        [InlineData("\n")]
        [InlineData(null)]
        public void ItShould_ThrowArgumentNullException_WhenNameIsEmpty(string inputName)
        {
            Mock<IRepository<Department>> departmentRepo = new();
            DepartmentService departmentService = new(departmentRepo.Object);

            Assert.Throws<ArgumentNullException>(() => departmentService.Create(new Department() { Name = inputName }));
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("   ")]
        [InlineData("\n")]
        [InlineData(null)]
        public void ItShould_ThrowArgumentNullException_WhenNameIsEmptyWithStringInput(string inputName)
        {
            Mock<IRepository<Department>> departmentRepo = new();
            DepartmentService departmentService = new(departmentRepo.Object);

            Assert.Throws<ArgumentNullException>(() => departmentService.Create(inputName));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(12)]
        [InlineData(1312)]
        [InlineData(int.MaxValue)]
        public void ItShould_ThrowArgumentException_WhenIdIsSet(int inputId)
        {
            Mock<IRepository<Department>> departmentRepo = new();
            DepartmentService departmentService = new(departmentRepo.Object);

            Assert.Throws<ArgumentException>(() => departmentService.Create(new Department() { Id = inputId, Name = "test" }));
        }
    }
}
