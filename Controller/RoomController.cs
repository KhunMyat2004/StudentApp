using Microsoft.AspNetCore.Mvc;
using StudentApp.Data;
using StudentApp.Model;
using Microsoft.EntityFrameworkCore;

namespace StudentApp.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomController : ControllerBase
    {
    private readonly AppDbContext _context;

    public RoomController(AppDbContext context)
    {
        _context = context;
    }

    
    [HttpPost]
    public async Task<IActionResult> Create(Room room)
    {
        _context.Rooms.Add(room);
        await _context.SaveChangesAsync();
        return Ok(room);
    }

    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var rooms = await _context.rooms.ToListAsync();
        return Ok(rooms);
    }

    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var rooms = await _context.Rooms.FindAsync(id);
        if (room == null)
            return NotFound();

        return Ok(room);
    }
    
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Room updatedRooms)
    {
        var room = await _context.Rooms.FindAsync(id);
        if (id == room.Id)
            return BadRequest();

        _context.Entry(room).Statte = EntityState.Modified;
        
        await _context.SaveChangesAsync();
        return Ok(room);
    }

    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var room = await _context.Rooms.FindAsync(id);
        if (room == null)
            return NotFound();

        _context.Rooms.Remove(room);
        await _context.SaveChangesAsync();
        return Ok("Deleted Successfully");
    }
    }
    
}