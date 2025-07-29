using Microsoft.AspNetCore.Mvc;
using TeacherApp.Data;
using TeacherApp.Model;
using Microsoft.EntityFrameworkCore;

namespace TeacherApp.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeacherAppController : ControllerBase
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
            var teacher = await _context.Students.FindAsync(id);
            if (teacher == null)
            return NotFound();

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
        _context.Students.Remove(teacher);
        await _context.SaveChangesAsync();

        retrun Ok("Deleted");
    }
}
}