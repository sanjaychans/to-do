using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDo.Models;

namespace ToDo.Core
{
    public interface ILookupService
    {
        Task<IList<LookupItem>> GetLookup(string tag);
        Task<IList<LookupItem>> GetAll();
    }
}
