using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPublicAPI.Services;
using MyPublicAPI.Models;
using MyPublicAPI.Exceptions;

namespace MyPublicAPI.Controllers
{
    [Route("publicapi/companies/{companyId}/[controller]")]
    [ApiController]
    public class JournalsController : ControllerBase
    {
        private readonly JournalService _journalService;

        public JournalsController(JournalService journalService)
        {
            _journalService = journalService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<JournalDTO>>  GetJournals(Guid companyId)
        {
            var journals = _journalService.GetJournals(companyId);
            return Ok(journals);

        }

        [HttpGet("{verificationNumber}")]
        public ActionResult<JournalDTO> GetJournal(Guid companyId, String verificationNumber)
        {
            var journal = _journalService.GetJournal(companyId,verificationNumber);
        
            return Ok(journal);
        }

        [HttpPost]
        public ActionResult<JournalDTO> PostJournal(Guid companyId, JournalDTO journalRequest)
        {
            var journal  = _journalService.AddJournal(companyId, journalRequest);
            return Ok(journal);
        }

        // [HttpPut("{id}")]
        // public IActionResult PutJournal(Guid companyId, Guid id, Journal journal)
        // {

        // }

        [HttpDelete("{VerificationNumber}")]
        public IActionResult DeleteJournal(Guid companyId, string VerificationNumber)
        {

            var result = _journalService.DeleteJournal(companyId, VerificationNumber);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}