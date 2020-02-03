using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ToDo.Models;

namespace ToDo.DAL
{
    /// <summary>
    /// Generic repository implementation for entity of type T.
    /// This is not for specific features or implementations
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EntityRepository<T> : IRepository<T> where T : Entity
    {
        protected ToDoDbContext _context;

        public EntityRepository(ToDoDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Insert entity into the system and returns the new id
        /// </summary>
        /// <param name="Item"></param>
        /// <returns></returns>
        public virtual async Task<int> Add(T Item)
        {
            _context.Add(Item);
            await _context.SaveChangesAsync();
            return Item.Id;
        }

        /// <summary>
        /// Inserts a range of objects and returns their ids
        /// </summary>
        /// <param name="Items"></param>
        /// <returns></returns>
        public virtual async Task AddAll(IEnumerable<T> Items)
        {
            _context.AddRange(Items);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes an entity from the system.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public virtual async Task Delete(int Id)
        {
            _context.Remove(await GetByID(Id));
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Fetches an entity based on a specific filter and sort field
        /// </summary>
        /// <typeparam name="T2"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public virtual async Task<List<T>> Get<T2>(Expression<Func<T, bool>> predicate, Expression<Func<T, T2>> order)
        {
            return await _context.Set<T>().AsNoTracking().Where(predicate).OrderBy(order).ToListAsync();

        }

        /// <summary>
        /// Fetches all the entities in the system of type T
        /// </summary>
        /// <returns></returns>
        public virtual async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }


        /// <summary>
        /// Fetches an entity of type T based on the id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public virtual async Task<T> GetByID(int Id)
        {
            return await _context.Set<T>().FindAsync(Id);
        }

        /// <summary>
        /// Updates an entity of type T
        /// </summary>
        /// <param name="Item"></param>
        /// <returns></returns>
        public virtual async Task Save(T Item)
        {
            _context.Update(Item);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Updates a range of entities of type T
        /// </summary>
        /// <param name="Items"></param>
        /// <returns></returns>
        public virtual async Task SaveAll(IEnumerable<T> Items)
        {
            _context.UpdateRange(Items);
            await _context.SaveChangesAsync();
        }
    }
}
