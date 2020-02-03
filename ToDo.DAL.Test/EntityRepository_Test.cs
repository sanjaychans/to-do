using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using ToDo.DAL.Test.Data;
using ToDo.Models;
using Xunit;

namespace ToDo.DAL.Test
{
    /// <summary>
    /// Test class for EntityRepository<ToDoItem>
    /// </summary>
    public class EntityRepository_Test
    {
        /// <summary>
        /// Add operation test stub
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [Theory]
        [ClassData(typeof(EntityRepository_Add_TestData))]
        public async Task Add_Success(ToDoItem item)
        {
            //arrange
            CancellationToken token = new CancellationToken();
            Mock<ToDoDbContext> mockContext = new Mock<ToDoDbContext>();
            mockContext.Setup(x => x.Add(It.IsAny<ToDoItem>())).Verifiable();
            mockContext.Setup(x => x.SaveChangesAsync(token)).Returns(() => Task.Run(() => { return 1; })).Verifiable();
            EntityRepository<ToDoItem> repo = new EntityRepository<ToDoItem>(mockContext.Object);

            //act
            await repo.Add(item);

            //assert
            mockContext.VerifyAll();
        }

        /// <summary>
        /// GetById operation test stub
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [Theory]
        [ClassData(typeof(EntityRepository_Add_TestData))]
        public async Task GetById_Success(ToDoItem item)
        {
            //arrange
            var Id = 2;
            Mock<ToDoDbContext> mockContext = new Mock<ToDoDbContext>();
            Mock<DbSet<ToDoItem>> setMock = new Mock<DbSet<ToDoItem>>();
            mockContext.Setup(x => x.Set<ToDoItem>()).Returns(setMock.Object);
            setMock.Setup(x => x.FindAsync(Id)).Returns(new ValueTask<ToDoItem>(item));
            EntityRepository<ToDoItem> repo = new EntityRepository<ToDoItem>(mockContext.Object);

            //act
            var todoItem = await repo.GetByID(Id);

            //assert
            Assert.NotNull(todoItem);
            Assert.Equal(2, todoItem.Id);
        }

        /// <summary>
        /// Save operation test stub
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [Theory]
        [ClassData(typeof(EntityRepository_Add_TestData))]
        public async Task Save_Success(ToDoItem item)
        {
            //arrange
            CancellationToken token = new CancellationToken();
            Mock<ToDoDbContext> mockContext = new Mock<ToDoDbContext>();
            mockContext.Setup(x => x.Update(It.IsAny<ToDoItem>())).Verifiable();
            mockContext.Setup(x => x.SaveChangesAsync(token)).Verifiable();

            EntityRepository<ToDoItem> repo = new EntityRepository<ToDoItem>(mockContext.Object);

            //act
            await repo.Save(item);

            //assert
            mockContext.Verify(x => x.Update(It.IsAny<ToDoItem>()), Times.Exactly(1));
            mockContext.Verify(x => x.SaveChangesAsync(token), Times.Exactly(1));


        }
    }
}
