namespace EPP_Backend.Controllers;
using EPP_Backend.Data;
using EPP_Backend.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/usuarios")]
public class UsuariosController : ControllerBase
{
    private readonly EppContext _context;
    public UsuariosController(EppContext context)
    {
        _context = context;
    }
    // GET: /usuarios
    [HttpGet]
    public ActionResult<IEnumerable<Usuarios>> GetAll()
    {
        return Ok(_context.Usuarios.ToList());
    }  
}
