using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPublicAPI.Data;
using MyPublicAPI.Models;
using MyPublicAPI.Exceptions;

namespace MyPublicAPI.Controllers
{
    [Route("publicapi/companies/{companyId}/[controller]")]
    [ApiController]
    public class JournalsController(ApiContext context) : ControllerBase
    {
        private readonly ApiContext _context = context;

        [HttpGet]
        public ActionResult<IEnumerable<Journal>> GetJournals(Guid companyId)
        {
            EnsureCompanyExists(companyId);
            var journals = _context.Journals.Where(j => j.CompanyId == companyId).ToList();
            return Ok(journals);
        }

        [HttpGet("{id}")]
        public ActionResult<Journal> GetJournal(Guid companyId, Guid id)
        {
            EnsureCompanyExists(companyId);
            var journal = _context.Journals.SingleOrDefault(j => j.CompanyId == companyId && j.Id == id);

            if (journal == null)
            {
                return NotFound();
            }

            return Ok(journal);
        }

        [HttpPost]
        public ActionResult<Journal> PostJournal(Guid companyId, Journal journal)
        {
            EnsureCompanyExists(companyId);
            journal.CompanyId = companyId;
            _context.Journals.Add(journal);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetJournal), new { companyId = companyId, id = journal.Id }, journal);
        }

        [HttpPut("{id}")]
        public IActionResult PutJournal(Guid companyId, Guid id, Journal journal)
        {
            EnsureCompanyExists(companyId);

            if (id != journal.Id || companyId != journal.CompanyId)
            {
                return BadRequest();
            }

            _context.Entry(journal).State = EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteJournal(Guid companyId, Guid id)
        {
            EnsureCompanyExists(companyId);
            var journal = _context.Journals.SingleOrDefault(j => j.CompanyId == companyId && j.Id == id);
            if (journal == null)
            {
                return NotFound();
            }

            _context.Journals.Remove(journal);
            _context.SaveChanges();
            return NoContent();
        }
        private void EnsureCompanyExists(Guid companyId)
        {
            if (!_context.UserCompanies.Any(uc => uc.CompanyId == companyId))
            {
                throw new CompanyNotFoundException(companyId);
            }
        }
    }
}