using Microsoft.AspNetCore.Mvc;
using StudentApp.Data;
using StudentApp.Model;
using Microsoft.EntityFrameworkCore;

namespace TeacherApp.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeacherController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TeacherController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var teachers = await _context.Students.ToListAsync();
            return Ok(teachers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult>GetById(int id)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null)
            return NotFound();

            return Ok(teacher);
        }
        [HttpGet("GetByName")]
        public async Task<ActionResult> GetByName(string name)
        {
            var teacher = await _context.Teachers.Where(s => s.Name == name).FirstOrDefaultAsync();
            if (teacher == null)
            {
                return NotFound();
            }
            return Ok(teacher);
        }

        [HttpPost]
        public async Task<ActionResult> Update(int id ,Teacher teacher)
        {
            if(id != teacher.Id)
            return BadRequest();

            _context.Entry(teacher).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(teacher);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var teacher = await _context.Teachers.FindAsync(id);
        if (teacher == null)
        return NotFound();
        _context.Teachers.Remove(teacher);
        await _context.SaveChangesAsync();

        return Ok("Deleted");
    }
}
}