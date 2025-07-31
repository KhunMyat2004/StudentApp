using Microsoft.AspNetCore.Mvc;
using StudentApp.Data;
using StudentApp.Model;
using Microsoft.EntityFrameworkCore;

namespace StudentApp.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StudentController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetStudent")]
        public async Task<ActionResult> Get()
        {
            var students = await _context.Students.ToListAsync();
            return Ok(students);
        }

        [HttpGet("GetByParentId")]
        public async Task<IActionResult> GetSByParentId(int id)
        {
            var student = await _context.Students.Where(s => s.ParentId == id).FirstOrDefaultAsync();
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
                return NotFound();

            return Ok(student);
        }

        [HttpGet("GetByName")]
        public async Task<ActionResult> GetByName(string name)
        {
            var student = await _context.Students.Where(s => s.Name == name).FirstOrDefaultAsync();
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return Ok(student);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Student student)
        {
            if (id != student.Id)
                return BadRequest();

            _context.Entry(student).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(student);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
                return NotFound();

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return Ok("Deleted");
        }

        [HttpGet("GetStudentListByRoom")]
        public async Task<ActionResult> GetStudentListByRoom(int id)
        {
            var students = await _context.Students.Where(s => s.RoomId == id).ToListAsync();
            return Ok(students);
        }
    }
}
