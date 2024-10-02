using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPublicAPI.Data;
using MyPublicAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyPublicAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class JournalsController(ApiContext context) : ControllerBase
    {
        private readonly ApiContext _context = context;

        [HttpGet]
        public ActionResult<IEnumerable<Journal>> GetJournals()
        {
            return _context.Journals.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Journal> GetJournal(Guid id)
        {
            var Journal = _context.Journals.Find(id);

            if (Journal == null)
            {
                return NotFound();
            }

            return Journal;
        }

        [HttpPost]
        public ActionResult<Journal> PostJournal(Journal Journal)
        {
            _context.Journals.Add(Journal);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetJournal), new { id = Journal.Id }, Journal);
        }

        [HttpPut("{id}")]
        public IActionResult PutJournal(Guid id, Journal Journal)
        {
            if (id != Journal.Id)
            {
                return BadRequest();
            }

            _context.Entry(Journal).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteJournal(Guid id)
        {
            var Journal = _context.Journals.Find(id);
            if (Journal == null)
            {
                return NotFound();
            }

            _context.Journals.Remove(Journal);
            _context.SaveChanges();

            return NoContent();
        }
    }
}