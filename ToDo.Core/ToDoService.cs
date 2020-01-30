using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDo.DAL;
using ToDo.Models;

namespace ToDo.Core
{
    public class ToDoService : IToDoService
    {
        private readonly IRepository<ToDoItem> _todoRepo;

        public ToDoService(IRepository<ToDoItem> todoRepo)
        {
            _todoRepo = todoRepo;
        }

        public async Task<int> CreateOrUpdate(ToDoItem item)
        {
            var todoItem = _todoRepo.GetByID(item.Id);
            if (todoItem == null)
                await _todoRepo.Add(item);
            else
                await _todoRepo.Save(item);

            return item.Id;
        }

        public async Task<int> Delete(int Id)
        {
            await _todoRepo.Delete(Id);
            return Id;
        }

        public async Task<ToDoItem> Get(int Id)
        {
            return await _todoRepo.GetByID(Id);
        }

        public async Task<IList<ToDoItem>> GetAll()
        {
            return await _todoRepo.GetAll();
        }
    }
}
