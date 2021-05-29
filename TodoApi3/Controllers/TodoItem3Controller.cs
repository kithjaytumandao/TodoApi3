using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi3.Models;

namespace TodoApi3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItem3Controller : ControllerBase
    {
        private readonly TodoContext3 _context;

        public TodoItem3Controller(TodoContext3 context)
        {
            _context = context;
        }

        // GET: api/TodoItem3
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItem3>>> GetTodoItems()
        {
            return await _context.TodoItems3.ToListAsync();
        }

        // GET: api/TodoItem3/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem3>> GetTodoItem3(long id)
        {
            var todoItem3 = await _context.TodoItems3.FindAsync(id);

            if (todoItem3 == null)
            {
                return NotFound();
            }

            return todoItem3;
        }

        // PUT: api/TodoItem3/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem3(long id, TodoItem3 todoItem3)
        {
            if (id != todoItem3.Id)
            {
                return BadRequest();
            }

            _context.Entry(todoItem3).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoItem3Exists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TodoItem3
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TodoItem3>> PostTodoItem3(TodoItem3 todoItem3)
        {
            _context.TodoItems3.Add(todoItem3);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTodoItem3), new { id = todoItem3.Id }, todoItem3);
        }

        // DELETE: api/TodoItem3/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem3(long id)
        {
            var todoItem3 = await _context.TodoItems3.FindAsync(id);
            if (todoItem3 == null)
            {
                return NotFound();
            }

            _context.TodoItems3.Remove(todoItem3);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TodoItem3Exists(long id)
        {
            return _context.TodoItems3.Any(e => e.Id == id);
        }
    }
}
