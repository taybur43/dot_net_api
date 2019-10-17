using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.test;

namespace TodoApi.Controllers
{
 
    [Route("api/Todoitemseconds")]
    [ApiController]
    public class TodoitemsecondsController : BaseController
    {
        private readonly TodoContext _context;

        public TodoitemsecondsController(TodoContext context)
        {
            _context = context;
        }

        // Todoitemseconds is from here ................................

        // GET: api/Todoitemseconds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Todoitemsecond>>> GetTodoitemseconds()
        {
            return await _context.Todoitemseconds.ToListAsync();
        }

        // GET: api/Todoitemseconds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Todoitemsecond>> GetTodoitemsecond(long id)
        {
            var todoItem = await _context.Todoitemseconds.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }

        // PUT: api/Todoitemseconds/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoitemseconds(long id, Todoitemsecond todoitemsecond)
        {
            if (id != todoitemsecond.Id)
            {
                return BadRequest();
            }

            _context.Entry(todoitemsecond).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoitemsecondExists(id))
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

        // POST: api/TodoItems
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Todoitemsecond>> PostTodoitemsecond(Todoitemsecond Todoitemsecond)
        {
            _context.Todoitemseconds.Add(Todoitemsecond);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTodoitemsecond), new { id = Todoitemsecond.Id }, Todoitemsecond);
        }

        // DELETE: api/TodoItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Todoitemsecond>> DeleteTodoitemsecond(long id)
        {
            var Todoitemsecond = await _context.Todoitemseconds.FindAsync(id);
            if (Todoitemsecond == null)
            {
                return NotFound();
            }

            _context.Todoitemseconds.Remove(Todoitemsecond);
            await _context.SaveChangesAsync();

            return Todoitemsecond;
        }
        private bool TodoitemsecondExists(long id)
        {
            return _context.Todoitemseconds.Any(e => e.Id == id);
        }
    }
}
