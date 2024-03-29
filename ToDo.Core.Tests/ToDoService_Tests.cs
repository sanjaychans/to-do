﻿using Moq;
using System;
using System.Threading.Tasks;
using ToDo.Core.Tests.Data;
using ToDo.DAL;
using ToDo.Models;
using Xunit;

namespace ToDo.Core.Tests
{
    /// <summary>
    /// ToDoService test class
    /// </summary>
    public class ToDoService_Tests
    {

        /// <summary>
        /// Tests the create flow on the CreateOrUpdate operation
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [Theory]
        [ClassData(typeof(ToDoService_Create_TestData))]
        public async Task CreateOrUpdate_Create_Success(ToDoItem item)
        {
            //arrange
            Mock<IRepository<ToDoItem>> mockRepo = new Mock<IRepository<ToDoItem>>();
            mockRepo.Setup(x => x.GetByID(It.IsAny<int>())).Returns(Task.FromResult((ToDoItem)null));
            mockRepo.Setup(x => x.Add(item)).Returns(Task.FromResult(1));
            var service = new ToDoService(mockRepo.Object);

            //act
            var newId = await service.CreateOrUpdate(item);

            //assert
            mockRepo.Verify(x => x.GetByID(It.IsAny<int>()), Times.Exactly(1));
            mockRepo.Verify(x => x.Add(item), Times.Exactly(1));
            mockRepo.Verify(x => x.Save(It.IsAny<ToDoItem>()), Times.Never);
            Assert.NotEqual(item.Id, newId);

        }

        /// <summary>
        /// Tests the update flow on the CreateOrUpdate operation
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [Theory]
        [ClassData(typeof(ToDoService_Update_TestData))]
        public async Task CreateOrUpdate_Update_Success(ToDoItem item)
        {
            //arrange
            ToDoItem existingItem = new ToDoItem { Id = 2 };
            Mock<IRepository<ToDoItem>> mockRepo = new Mock<IRepository<ToDoItem>>();
            mockRepo.Setup(x => x.GetByID(It.IsAny<int>())).Returns(Task.FromResult(existingItem));
            mockRepo.Setup(x => x.Save(It.IsAny<ToDoItem>())).Verifiable();
            var service = new ToDoService(mockRepo.Object);

            //act
            var newId = await service.CreateOrUpdate(item);

            //assert
            mockRepo.Verify(x => x.GetByID(It.IsAny<int>()), Times.Exactly(1));
            mockRepo.Verify(x => x.Save(It.IsAny<ToDoItem>()), Times.Exactly(1));
            mockRepo.Verify(x => x.Add(item), Times.Never);
            Assert.Equal(item.Id, newId);

        }

    }
}
