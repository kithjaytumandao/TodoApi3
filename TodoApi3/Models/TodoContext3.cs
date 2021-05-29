using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TodoApi3.Models
{
    public class TodoContext3 : DbContext
    {
        public TodoContext3(DbContextOptions<TodoContext3> options)
            : base(options)
        {
        }

        public DbSet<TodoItem3> TodoItems3 { get; set; }
    }
}
