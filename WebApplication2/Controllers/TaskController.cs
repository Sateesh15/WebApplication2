using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly MyDbContext _context;

        public TaskController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/Task
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoTask>>> GetTasks()
        {
            var tasks = await _context.Tasks.ToListAsync();
            Response.Headers.Add("X-Total-Count", tasks.Count.ToString()); // Include the count in response headers
            return Ok(tasks);
        }

        // GET: api/Task/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoTask>> GetTask(int id)
        {
            var task = await _context.Tasks.FindAsync(id);

            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }

        // PUT: api/Task/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTask(int id, TodoTask task)
        {
            if (id != task.Id)
            {
                return BadRequest("Invalid ID");
            }

            _context.Entry(task).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskExists(id))
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

        // POST: api/Task
        [HttpPost]
        public async Task<ActionResult<TodoTask>> PostTask(TodoTask task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
        }

        // DELETE: api/Task/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // PATCH: api/Task/5/complete
        [HttpPatch("{id}/complete")]
        public async Task<ActionResult<TodoTask>> CompleteTask(int id)
        {
            var todoTask = await _context.Tasks.FindAsync(id);

            if (todoTask == null)
            {
                return NotFound();
            }

            todoTask.Completed = true;
            await _context.SaveChangesAsync();

            return todoTask;
        }

        // PATCH: api/Task/5/incomplete
        [HttpPatch("{id}/incomplete")]
        public async Task<ActionResult<TodoTask>> IncompleteTask(int id)
        {
            var todoTask = await _context.Tasks.FindAsync(id);

            if (todoTask == null)
            {
                return NotFound();
            }

            todoTask.Completed = false;
            await _context.SaveChangesAsync();

            return todoTask;
        }

        private bool TaskExists(int id)
        {
            return _context.Tasks.Any(e => e.Id == id);
        }
    }
}
