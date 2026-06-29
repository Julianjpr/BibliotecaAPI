using BibliotecaAPI.Data;
using BibliotecaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        private readonly BibliotecaContext _context;

        public LibrosController(BibliotecaContext context)
        {
            _context = context;
        }

        // GET: api/libros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Libro>>> GetLibros()
        {
            return await _context.Libros.ToListAsync();
        }

        // GET: api/libros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Libro>> GetLibro(int id)
        {
            var libro = await _context.Libros.FindAsync(id);

            if (libro == null)
                return NotFound();

            return libro;
        }

        // POST: api/libros
        [HttpPost]
        public async Task<ActionResult<Libro>> PostLibro(Libro libro)
        {
            _context.Libros.Add(libro);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetLibro), new { id = libro.Id }, libro);
        }

        // PUT: api/libros/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLibro(int id, Libro libro)
        {
            if (id != libro.Id)
                return BadRequest();

            var existe = await _context.Libros.AnyAsync(x => x.Id == id);

            if (!existe)
                return NotFound();

            _context.Entry(libro).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/libros/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLibro(int id)
        {
            var libro = await _context.Libros.FindAsync(id);

            if (libro == null)
                return NotFound();

            _context.Libros.Remove(libro);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
