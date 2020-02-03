using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ToDo.Models
{
    /// <summary>
    /// Entity base class
    /// </summary>
    public abstract class Entity
    {
        [Key]
        public int Id { get; set; }
    }
}
