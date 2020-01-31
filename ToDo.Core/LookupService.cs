using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDo.DAL;
using ToDo.Models;

namespace ToDo.Core
{
    public class LookupService : ILookupService
    {
        private readonly IRepository<LookupItem> _lookupRepo;

        public LookupService(IRepository<LookupItem> lookupRepo)
        {
            _lookupRepo = lookupRepo;
        }

        public async Task<IList<LookupItem>> GetAll()
        {
            return await _lookupRepo.GetAll();
        }

        public async Task<IList<LookupItem>> GetLookup(string tag)
        {
            if (!string.IsNullOrWhiteSpace(tag))
                return await _lookupRepo.Get<short>(x => x.Tag.Equals(tag), n => n.SortIndex);
            else
                return await _lookupRepo.GetAll();
        }
    }
}
