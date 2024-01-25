using Examen_scypt.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
[Route("api/[controller]")]
[ApiController]
public class UtilizatoriController : ControllerBase
{
    private readonly ExamenContext _context;

    public UtilizatoriController(ExamenContext context)
    {
        _context = context;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<Utilizator>>> GetUtilizatori()
    {
        return await _context.Utilizators.ToListAsync();
    }

  
    [HttpPost]
    public async Task<ActionResult<Utilizator>> PostUtilizator(Utilizator utilizator)
    {
        _context.Utilizators.Add(utilizator);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetUtilizator", new { id = utilizator.UtilizatorId }, utilizator);
    }
}
