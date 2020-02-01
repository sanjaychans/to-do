using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using ToDo.Core;
using ToDo.Models;
using ToDo.Web.Controllers;
using ToDo.Web.Tests.Data;
using Xunit;

namespace ToDo.Web.Tests
{
    public class ToDoController_Tests
    {
        [Theory]
        [ClassData(typeof(ToDoController_Create_TestData))]
        public async Task CreateorUpdate_Success(ToDoItem item)
        {
            //arrange
            Mock<IToDoService> mockService = new Mock<IToDoService>();
            mockService.Setup(x => x.CreateOrUpdate(It.IsAny<ToDoItem>())).Returns(Task.FromResult(1));
            var controller = new ToDoController(mockService.Object);

            //act
            var returnVal = await controller.CreateOrUpdate(item);
            var result = returnVal as OkObjectResult;

            //assert
            mockService.Verify(x => x.CreateOrUpdate(It.IsAny<ToDoItem>()), Times.Exactly(1));
            Assert.NotNull(result);
            Assert.NotEqual<int>(item.Id, (int)result.Value);

        }

        [Fact]
        public async Task CreateorUpdate_Failure()
        {
            //arrange
            ToDoItem item = null;
            Mock<IToDoService> mockService = new Mock<IToDoService>();
            mockService.Setup(x => x.CreateOrUpdate(It.IsAny<ToDoItem>())).Returns(Task.FromResult(1));
            var controller = new ToDoController(mockService.Object);

            //act
            var returnVal = await controller.CreateOrUpdate(item);

            //assert
            mockService.Verify(x => x.CreateOrUpdate(It.IsAny<ToDoItem>()), Times.Never);
            
        }
    }
}
