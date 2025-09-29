    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
using System.Runtime.CompilerServices;


namespace EPP_Backend.Controllers
{
    [ApiController]
    [Route("/solicitante")]
    public class SolicitanteController : ControllerBase
    {
        // Modelo simple para ejemplo
        public class Solicitante
        {

            public int Id { get; set; }
            public string? Nombre {get; set; }
    }

        // Simulación de datos en memoria
        private static List<Solicitante> solicitantes = new List<Solicitante>
            {
                new Solicitante { Id = 1, Nombre = "Juan Perez" },
                new Solicitante { Id = 2, Nombre = "Maria Gomez" }
            };

        // GET: api/solicitante/getAll
        [HttpGet]
        [Route("getAll")]
        public ActionResult<IEnumerable<Solicitante>> GetAll()
        {
            return Ok(solicitantes);
        }

        // GET: api/solicitante/1
        [HttpGet("{id}")]
        public ActionResult<Solicitante> GetById(int id)
        {
            var solicitante = solicitantes.Find(s => s.Id == id);
            if (solicitante == null)
                return NotFound();
            return Ok(solicitante);
        }

        // POST: /solicitante
        [HttpPost]
        public ActionResult<Solicitante> Create(Solicitante nuevo)
        {
            nuevo.Id = solicitantes.Count + 1;
            solicitantes.Add(nuevo);
            return CreatedAtAction(nameof(GetById), new { id = nuevo.Id }, nuevo);

        }
    }
}