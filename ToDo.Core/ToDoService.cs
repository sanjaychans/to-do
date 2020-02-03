using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDo.DAL;
using ToDo.Models;

namespace ToDo.Core
{
    /// <summary>
    /// Service implementation of the To Do Service functionality
    /// </summary>
    public class ToDoService : IToDoService
    {
        private readonly IRepository<ToDoItem> _todoRepo;

        public ToDoService(IRepository<ToDoItem> todoRepo)
        {
            _todoRepo = todoRepo;
        }

        /// <summary>
        /// Upserts the task based on the presense of the id
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<int> CreateOrUpdate(ToDoItem item)
        {
            //try fetching the task by id
            var todoItem = await _todoRepo.GetByID(item.Id);
            int returnId;

            if (todoItem == null)
                //no task found - inserting
                returnId = await _todoRepo.Add(item);
            else
            {
                //task exists - copying data to tracked entity and updating.
                var config = new MapperConfiguration(m => m.CreateMap<ToDoItem, ToDoItem>());
                var mapper = config.CreateMapper();
                mapper.Map<ToDoItem, ToDoItem>(item, todoItem);
                await _todoRepo.Save(todoItem);
                returnId = item.Id;
            }
            return returnId;
        }

        /// <summary>
        /// Delete the task from the system
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<int> Delete(int Id)
        {
            await _todoRepo.Delete(Id);
            return Id;
        }

        /// <summary>
        /// Fetches task by id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<ToDoItem> Get(int Id)
        {
            return await _todoRepo.GetByID(Id);
        }

        /// <summary>
        /// Fetches all the tasks in the system.
        /// </summary>
        /// <returns></returns>
        public async Task<IList<ToDoItem>> GetAll()
        {
            return await _todoRepo.GetAll();
        }
    }
}
