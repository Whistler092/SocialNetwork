using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.Models;

namespace SocialNetwork.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PublicationsController : ControllerBase
    {
        private readonly ModelContext _context;

        public PublicationsController(ModelContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtener todas las publicaciones
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Publication> GetPublications()
        {
            return _context.Publications;
        }

        // GET: api/Publications/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPublication([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var publication = await _context.Publications.FindAsync(id);

            if (publication == null)
            {
                return NotFound();
            }

            return Ok(publication);
        }

        // PUT: api/Publications/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPublication([FromRoute] int id, [FromBody] Publication publication)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != publication.PublicationId)
            {
                return BadRequest();
            }

            _context.Entry(publication).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PublicationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        /// <summary>
        /// Crea una nueva publicación
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST api/publications
        ///     {
        ///          "title": "Nuevo Estado",
        ///          "content": "Descripción de un nuevo estado",
        ///          "profileId": 2
        ///     }
        /// </remarks>
        /// <param name="publication"></param>
        /// <returns>Un objeto nuevo creado de Publication</returns>
        /// <response code="201">Retorna el nuevo item creado</response>
        /// <response code="400">Retorna si el item está Null</response>
        [HttpPost]
        public async Task<IActionResult> PostPublication([FromBody] Publication publication)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Publications.Add(publication);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPublication", new { id = publication.PublicationId }, publication);
        }

        // DELETE: api/Publications/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePublication([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var publication = await _context.Publications.FindAsync(id);
            if (publication == null)
            {
                return NotFound();
            }

            _context.Publications.Remove(publication);
            await _context.SaveChangesAsync();

            return Ok(publication);
        }

        private bool PublicationExists(int id)
        {
            return _context.Publications.Any(e => e.PublicationId == id);
        }
    }
}