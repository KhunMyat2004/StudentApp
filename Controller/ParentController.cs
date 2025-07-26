using Microsoft.AspNetCore.Mvc;
using StudentApp.Data;
using StudentApp.Model;
using Microsoft.EntityFrameworkCore;

namespace StudentApp.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParentController : ControllerBase
    {
         private readonly AppDbContext _context;

    public ParentController(AppDbContext context)
    {
        _context = context;
    }

    
    [HttpPost]
    public async Task<IActionResult> Create(Parent parent)
    {
        _context.Parents.Add(parent);
        await _context.SaveChangesAsync();
        return Ok(parent);
    }

    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var parents = await _context.Parents.ToListAsync();
        return Ok(parents);
    }

    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var parent = await _context.Parents.FindAsync(id);
        if (parent == null)
            return NotFound();

        return Ok(parent);
    }

    
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Parent updatedParent)
    {
        var parent = await _context.Parents.FindAsync(id);
        if (parent == null)
            return NotFound();

        parent.Name = updatedParent.Name;
        
        await _context.SaveChangesAsync();
        return Ok(parent);
    }

    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var parent = await _context.Parents.FindAsync(id);
        if (parent == null)
            return NotFound();

        _context.Parents.Remove(parent);
        await _context.SaveChangesAsync();
        return Ok("Deleted Successfully");
    }
    }
}