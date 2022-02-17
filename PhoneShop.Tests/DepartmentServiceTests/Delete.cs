using Moq;
using PhoneShop.Models;
using PhoneShop.Repository.Interfaces;
using PhoneShop.Service;
using Xunit;

namespace PhoneShop.Tests.DepartmentServiceTests
{
    [Collection("Sequential")]
    public class Delete
    {
        [Fact]
        public void ItShould_DeleteADepartment_FromId()
        {
            Mock<IRepository<Department>> departmentRepo = new();
            DepartmentService departmentService = new(departmentRepo.Object);

            departmentRepo.Setup(br => br.GetById(It.IsAny<int>())).Returns(new Department());
            departmentService.Delete(5);

            departmentRepo.Verify(br => br.GetById(It.IsAny<object>()), Times.Once);
            departmentRepo.Verify(br => br.Remove(It.IsAny<Department>()), Times.Once);
            departmentRepo.Verify(br => br.SaveChanges(), Times.Once);
        }

        [Fact]
        public void ItShould_DeleteADepartment_FromObject()
        {
            Mock<IRepository<Department>> departmentRepo = new();
            DepartmentService departmentService = new(departmentRepo.Object);

            departmentRepo.Setup(br => br.GetById(It.IsAny<int>())).Returns(new Department());
            departmentService.Delete(new Department());

            departmentRepo.Verify(br => br.Remove(It.IsAny<Department>()), Times.Once);
            departmentRepo.Verify(br => br.SaveChanges(), Times.Once);
        }
    }
}
