using Examen_scypt.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class ComenziController : ControllerBase
{
    private readonly ExamenContext _context;

    public ComenziController(ExamenContext context)
    {
        _context = context;
    }

  
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Comenzi>>> GetComenzii()
    {
        return await _context.Comenzii.Include(c => c.ComenziProdus).ToListAsync();
    }


    [HttpPost]
    public async Task<ActionResult<Comenzi>> PostComenzi(Comenzi comenzi)
    {
        _context.Comenzii.Add(comenzi);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetComenzi", new { id = comenzi.ComenziId }, comenzi);
    }
}
