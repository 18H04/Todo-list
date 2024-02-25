using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using todo_server.Data;
using todo_server.Model;

[ApiController]
[Route("[controller]")]
public class TodoController : ControllerBase
{
    private readonly TodoListContext _context;

    public TodoController(TodoListContext context)
    {
        _context = context;
    }

    // GET: /todo/tasks
    [HttpGet("tasks")]
    public async Task<ActionResult<IEnumerable<todo_server.Model.Task>>> GetTasks()
    {
        return await _context.Tasks.ToListAsync();
    }

    // GET: /todo/categories
    [HttpGet("categories")]
    public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
    {
        return await _context.Categories.ToListAsync();
    }

    // POST: /todo/task
    [HttpPost("task")]
    public async Task<ActionResult<todo_server.Model.Task>> CreateTask(todo_server.Model.Task task)
    {
        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
    }

    // GET: /todo/task/{id}
    [HttpGet("task/{id}")]
    public async Task<ActionResult<todo_server.Model.Task>> GetTask(int id)
    {
        var task = await _context.Tasks.FindAsync(id);

        if (task == null)
        {
            return NotFound();
        }

        return task;
    }

    // PUT: /todo/task/{id}
    [HttpPut("task/{id}")]
    public async Task<IActionResult> UpdateTask(int id, todo_server.Model.Task task)
    {
        if (id != task.Id)
        {
            return BadRequest();
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

    // DELETE: /todo/task/{id}
    [HttpDelete("task/{id}")]
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

    private bool TaskExists(int id)
    {
        return _context.Tasks.Any(e => e.Id == id);
    }
}
