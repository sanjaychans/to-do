using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDo.Models;

namespace ToDo.Core
{
    /// <summary>
    /// To Do tsk service interface
    /// </summary>
    public interface IToDoService
    {
        Task<IList<ToDoItem>> GetAll();
        Task<ToDoItem> Get(int Id);
        Task<int> CreateOrUpdate(ToDoItem item);
        Task<int> Delete(int Id);

    }
}
