namespace EPP_Backend.Controllers;

using Microsoft.AspNetCore.Mvc;
using EPP_Backend.Data;
using EPP_Backend.Models;
[ApiController]
[Route("/conceptosEpp")]
public class conceptosEppController : ControllerBase
{
    private readonly EppContext _context;
    public conceptosEppController(EppContext context)
    {
        _context = context;
    }
    // GET: /conceptosEpp
    [HttpGet]
    public ActionResult<IEnumerable<ConceptosEpp>> GetAll()
    {
        return Ok(_context.ConceptosEpp.ToList());
    }
}
