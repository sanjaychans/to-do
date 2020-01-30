﻿using System;
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
    public class ToDoController : ControllerBase
    {
        private readonly IToDoService _todoService;

        public ToDoController(IToDoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IList<ToDoItem>> GetAll()
        {
            return await _todoService.GetAll();
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<ToDoItem> Get(int Id)
        {
            return await _todoService.Get(Id);
        }

        [HttpPost]
        public async Task<int> CreateOrUpdate(ToDoItem item)
        {
            int returnId = -1;
            if (item != null)
                returnId = await _todoService.CreateOrUpdate(item);

            return returnId;
        }

    }
}