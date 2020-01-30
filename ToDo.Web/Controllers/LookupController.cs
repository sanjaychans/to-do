using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDo.Core;
using ToDo.Models;

namespace ToDo.Web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LookupController : ControllerBase
    {
        private readonly ILookupService _lookupService;

        public LookupController(ILookupService lookupService)
        {
            _lookupService = lookupService;
        }

        [HttpGet]
        [Route("{tag}")]
        public async Task<IList<LookupItem>> GetLookupByTag(string tag)
        {
            IList<LookupItem> lookups = null;
            if (!string.IsNullOrWhiteSpace(tag))
                lookups = await _lookupService.GetLookup(tag);

            return lookups;
        }
    }


}