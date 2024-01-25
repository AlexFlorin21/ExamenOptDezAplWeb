using Examen_scypt.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class ProduseController : ControllerBase
{
    private readonly ExamenContext _context;

    public ProduseController(ExamenContext context)
    {
        _context = context;
    }

    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Produs>>> GetProduse()
    {
        return await _context.Produse.ToListAsync();
    }

    
    [HttpPost]
    public async Task<ActionResult<Produs>> PostProdus(Produs produs)
    {
        _context.Produse.Add(produs);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetProdus", new { id = produs.ProdusId }, produs);
    }
}