namespace EPP_Backend.Controllers;

using Microsoft.AspNetCore.Mvc;
using EPP_Backend.Data;
using EPP_Backend.Models;
[ApiController]
[Route("conceptosEpp")]
public class conceptosEppController : ControllerBase
{
    private readonly EppContext _context;
    /// <summary>
    /// Controller responsible for handling operations related to "Conceptos EPP".
    /// </summary>
    /// <param name="context">
    /// The <see cref="EppContext"/> instance used for accessing the database.
    /// </param>
    public conceptosEppController(EppContext context)
    {
        _context = context;
    }
    // GET: /conceptosEpp/listar-conceptos-epp
    [HttpGet]
    // [Route("/listar-conceptos-epp")]
    public ActionResult<IEnumerable<ConceptosEpp>> GetAll()
    {
        return Ok(_context.ConceptosEpp.ToList());
    }
    [HttpGet("{id}")]
    public ActionResult<ConceptosEpp> GetById(int id)
    {
        var concepto = _context.ConceptosEpp.Find(id);
        if (concepto == null)
        {
            return NotFound();
        }
        return Ok(concepto);
    }    
    }

