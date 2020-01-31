using AutoMapper;
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
            var todoItem = await _todoRepo.GetByID(item.Id);
            int returnId;
            if (todoItem == null)
                returnId = await _todoRepo.Add(item);
            else
            {
                var config = new MapperConfiguration(m => m.CreateMap<ToDoItem, ToDoItem>());
                var mapper = config.CreateMapper();
                mapper.Map<ToDoItem, ToDoItem>(item, todoItem);
                await _todoRepo.Save(todoItem);
                returnId = item.Id;
            }
            return returnId;
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
