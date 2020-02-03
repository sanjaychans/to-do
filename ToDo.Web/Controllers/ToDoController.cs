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
    /// To-Do API controller
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoService _todoService;

        public ToDoController(IToDoService todoService)
        {
            _todoService = todoService;
        }

        /// <summary>
        /// Fetches all to-do entries
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _todoService.GetAll());
        }

        //Fetches a to-do entry by Id
        [HttpGet]
        [Route("{Id}")]
        public async Task<ToDoItem> Get(int Id)
        {
            return await _todoService.Get(Id);
        }

        /// <summary>
        /// Creates or updates a to-do entry
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateOrUpdate(ToDoItem item)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            int returnId = -1;
            if (item != null)
                returnId = await _todoService.CreateOrUpdate(item);

            return Ok(returnId);
        }

    }
}