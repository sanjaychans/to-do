using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ToDo.Models;

namespace ToDo.DAL
{
    public class ToDoDbContext : DbContext
    {
        public DbSet<ToDoItem> ToDoEntries { get; set; }
        public DbSet<LookupItem> Lookups { get; set; }

        public ToDoDbContext()
        {

        }
        public ToDoDbContext(DbContextOptions<ToDoDbContext> options) : base(options) { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ToDoDb;Trusted_Connection=True;");
        //}

    }
}
