using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ToDo.Models;

namespace ToDo.DAL
{
    /// <summary>
    /// Entity repository interface for db access
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : Entity
    {
        Task<List<T>> GetAll();
        Task<T> GetByID(int Id);
        Task<List<T>> Get<T2>(Expression<Func<T, bool>> predicate, Expression<Func<T, T2>> order);
        Task Save(T Item);
        Task<int> Add(T Item);
        Task SaveAll(IEnumerable<T> Items);
        Task AddAll(IEnumerable<T> Items);
        Task Delete(int Id);

    }
}
