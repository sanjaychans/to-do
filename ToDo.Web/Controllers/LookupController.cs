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
    /// <summary>
    /// Lookup API controller
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class LookupController : ControllerBase
    {
        private readonly ILookupService _lookupService;

        public LookupController(ILookupService lookupService)
        {
            _lookupService = lookupService;
        }

        /// <summary>
        /// Fetches lookup data by tag
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{tag}")]
        [ResponseCache(VaryByQueryKeys = new[] { "tag" }, Duration = 300)]
        public async Task<IActionResult> GetLookupByTag(string tag)
        {
            IList<LookupItem> lookups = null;
            if (!string.IsNullOrWhiteSpace(tag))
                lookups = await _lookupService.GetLookup(tag);

            return Ok(lookups);
        }

        /// <summary>
        /// Fetches all lookup data
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ResponseCache(Duration = 300)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _lookupService.GetAll());
        }
    }


}