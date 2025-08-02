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

    
    [HttpPost]
    public async Task<IActionResult> Create(Student student)
    {
        _context.Parents.Add(student);
        await _context.SaveChangesAsync();
        return Ok(student);
    }

    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var students = await _context.students.ToListAsync();
        return Ok(students);
    }

    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var students = await _context.Students.FindAsync(id);
        if (student == null)
            return NotFound();

        return Ok(student);
    }
    
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Student updatedStudent)
    {
        var parent = await _context.Parents.FindAsync(id);
        if (id == student.Id)
            return BadRequest();

        _context.Entry(student).Statte = EntityState.Modified;
        
        await _context.SaveChangesAsync();
        return Ok(student);
    }

    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var student = await _context.Students.FindAsync(id);
        if (student == null)
            return NotFound();

        _context.Students.Remove(parent);
        await _context.SaveChangesAsync();
        return Ok("Deleted Successfully");
    }
    }
    
}