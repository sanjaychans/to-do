using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDo.DAL;
using ToDo.Models;

namespace ToDo.Core
{
    /// <summary>
    /// Service implementation of lookup
    /// </summary>
    public class LookupService : ILookupService
    {
        private readonly IRepository<LookupItem> _lookupRepo;

        public LookupService(IRepository<LookupItem> lookupRepo)
        {
            _lookupRepo = lookupRepo;
        }

        /// <summary>
        /// Fetches all the lookup in the system
        /// </summary>
        /// <returns></returns>
        public async Task<IList<LookupItem>> GetAll()
        {
            return await _lookupRepo.GetAll();
        }

        /// <summary>
        /// Fetches a specific lookup based on the tag.
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public async Task<IList<LookupItem>> GetLookup(string tag)
        {
            if (!string.IsNullOrWhiteSpace(tag))
                return await _lookupRepo.Get<short>(x => x.Tag.Equals(tag), n => n.SortIndex);
            else
                return await _lookupRepo.GetAll();
        }
    }
}
