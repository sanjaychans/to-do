using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ToDo.Models;

namespace ToDo.DAL
{
    /// <summary>
    /// DbContext for the entities in the system.
    /// Created using code-first approach
    /// </summary>
    public class ToDoDbContext : DbContext
    {
        public DbSet<ToDoItem> ToDoEntries { get; set; }
        public DbSet<LookupItem> Lookups { get; set; }
        public ToDoDbContext() { }
        public ToDoDbContext(DbContextOptions<ToDoDbContext> options) : base(options) { }

    }
}
