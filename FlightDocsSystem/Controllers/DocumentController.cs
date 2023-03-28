using AutoMapper;
using FlightDocsSystem.Data;
using FlightDocsSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightDocsSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly FDSContext _context;
        private readonly IMapper _mapper;

        public DocumentController(FDSContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Documents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DocumentVM>>> GetDocuments()
        {
            var documents = await _context.Documents.ToListAsync();
            var documentVMs = _mapper.Map<IEnumerable<DocumentVM>>(documents);
            return Ok(documentVMs);
        }

        // GET: api/Documents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DocumentVM>> GetDocument(int id)
        {
            var document = await _context.Documents.FindAsync(id);

            if (document == null)
            {
                return NotFound();
            }

            var documentVM = _mapper.Map<DocumentVM>(document);
            return Ok(documentVM);
        }

        // PUT: api/Documents/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDocument(int id, DocumentVM documentVM)
        {
            if (id != documentVM.document_id)
            {
                return BadRequest();
            }

            var document = _mapper.Map<Document>(documentVM);
            _context.Entry(document).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocumentExists(id))
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

        // POST: api/Documents
        [HttpPost]
        public async Task<ActionResult<DocumentVM>> PostDocument(DocumentVM documentVM)
        {
            var document = _mapper.Map<Document>(documentVM);
            _context.Documents.Add(document);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDocument", new { id = document.DocumentId }, _mapper.Map<DocumentVM>(document));
        }

        // DELETE: api/Documents/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DocumentVM>> DeleteDocument(int id)
        {
            var document = await _context.Documents.FindAsync(id);
            if (document == null)
            {
                return NotFound();
            }

            _context.Documents.Remove(document);
            await _context.SaveChangesAsync();

            var documentVM = _mapper.Map<DocumentVM>(document);
            return Ok(documentVM);
        }

        private bool DocumentExists(int id)
        {
            return _context.Documents.Any(e => e.DocumentId == id);
        }
    }
}
