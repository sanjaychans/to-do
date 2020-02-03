using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using ToDo.Models;

namespace ToDo.DAL.Test.Data
{
    /// <summary>
    /// Test data class for EntityRepository Add operation.
    /// </summary>
    class EntityRepository_Add_TestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            ToDoItem item = new ToDoItem
            {
                Id = 2,
                Subject = "Test Subject",
                StartDate = DateTime.Now.Date,
                DueDate = DateTime.Now.AddDays(10).Date,
                PercentageCompleted = 10,
                Priority = "M",
                Status = "STIP"
            };

            yield return new object[] { item };
            
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
