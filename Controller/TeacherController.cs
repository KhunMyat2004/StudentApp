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
        public async Task<ActionResult> GetById(int id)
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
        public async Task<ActionResult> Update(int id, Teacher teacher)
        {
            if (id != teacher.Id)
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
       
        
        [HttpGet("rooms-by-teacher")]
        public async Task<ActionResult> GetRoomsByTeacherName([FromQuery] string teacherName)
        {
            var teacher = await _context.Teachers
                .Include(t => t.RoomId)
                .FirstOrDefaultAsync(t => t.Name == teacherName);

            if (teacher == null)
                return NotFound("Teacher not found.");

            var rooms = teacher.Rooms.Select(r => r.RoomName).ToList();
            return Ok(rooms);
        }

       


  
        [HttpGet("teacher-by-room")]
        public async Task<ActionResult> GetTeacherByRoomName([FromQuery] string roomName)
        {
            var room = await _context.Rooms
                .Include(r => r.TeacherId)
                .FirstOrDefaultAsync(r => r.RoomName == roomName);

            if (room == null)
                return NotFound("Room not found.");

            return Ok(room.Teacher.Name);
        }
    }
}
        
        
 