using ContactsAPI.Entities;
using ContactsAPI.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace ContactsAPI.Controllers
{
    [Route("api/contato")]
    [ApiController]

    public class ContatoController : Controller
    {
        private readonly ContatoDbContext _context;

        public ContatoController(ContatoDbContext context)
        {
            _context = context;
        }

        [HttpGet]

        public IActionResult GetAll()
        {
            var contato = _context.Contatos.Where(u => !u.IsDeleted).ToList();
            return Ok(contato);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(Guid id)
        {
            var contato = _context.Contatos.SingleOrDefault(u => u.Id == id);
            if (contato == null)
            {
                NotFound();
            }

            return Ok(contato);
        }

        [HttpPost]

        public IActionResult Post(Contato contato)
        {
            _context.Contatos.Add(contato);
            return CreatedAtAction(nameof(GetById), new { id = contato.Id }, contato);
        }

        [HttpPut("{id}")]

        public IActionResult Update(Guid id, Contato input)
        {
            var contato = _context.Contatos.SingleOrDefault(u => u.Id == id);
            if (contato == null)
            {
                NotFound();
            }
            contato.Update(input.Nome, input.Email, input.Celular, input.StarDate);
            return NoContent();
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(Guid id)
        {
            var contato = _context.Contatos.SingleOrDefault(u => u.Id == id);
            if (contato == null)
            {
                NotFound();
            }
            contato.Delete();
            return NoContent();
        }
    }
}