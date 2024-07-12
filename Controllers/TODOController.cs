using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoAPI.Model;

namespace TodoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TODOController : ControllerBase
    {
        private readonly TODODbContext _context;

        public TODOController(TODODbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TODOItem>>> GetAll() => await _context.Items.ToListAsync();

        [HttpGet("{Id}"), ActionName("GetTodo")]
        public async Task<ActionResult<TODOItem>> Get(int Id)
        {
            var item = await _context.Items.FindAsync(Id);

            if (item == null) {
                return NotFound();
            }

            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<TODOItem>> Add(TODOItem item)
        {
            if(item.DateCreated != DateTime.Now)
            {
                item.DateCreated = DateTime.Now;
                item.DateModified = DateTime.Now;
            }
            _context.Items.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTodo", new { Id = item.Id}, item);
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult<TODOItem>> Update(int Id, TODOItem item)
        {
            if (Id != item.Id)
            {
                return BadRequest();
            }

            item.DateModified = DateTime.Now;

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok("updated");
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<TODOItem>> Remove(int Id)
        {
            var item = await _context.Items.FindAsync(Id);
            if (item == null)
            {
                return NotFound();
            }

            _context.Items.Remove(item);
            await _context.SaveChangesAsync();

            return Ok("removed");
        }
    }
}
