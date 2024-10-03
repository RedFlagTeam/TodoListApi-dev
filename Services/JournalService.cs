using MyPublicAPI.Data;
using MyPublicAPI.Models;
using MyPublicAPI.Exceptions;
namespace MyPublicAPI.Services
{
    public class JournalService(ApiContext context)
    {
        private readonly ApiContext _context = context;

        public IEnumerable<JournalDTO> GetJournals(Guid companyId)
        {

            EnsureCompanyExists(companyId);

            var journals = _context.Journals
                .Where(j => j.CompanyId == companyId)
                .ToList();

            var groupedJournals = journals
                .GroupBy(j => j.VerificationNumber)
                .Select(group => new JournalDTO
                {
                    VerificationNumber = group.Key,
                    Title = "Aggregated Journals",
                    Items = group.Select(j => new JournalDTO.JournalItem
                    {
                        ItemId = j.Id,
                        Debit = j.Debit,
                        Credit = j.Credit,
                        Account = j.Account
                    }).ToList()
                })
                .ToList();

            return groupedJournals;
        }

        public JournalDTO? GetJournal(Guid companyId, string verificationNumber)
        {
            EnsureCompanyExists(companyId);

            var journals = _context.Journals
                .Where(j => j.CompanyId == companyId && j.VerificationNumber == verificationNumber)
                .ToList();

            // Check if list is empty
            if (!journals.Any())
            {
                return null;
            }

            var responseDto = new JournalDTO
            {
                VerificationNumber = verificationNumber,
                Title = journals.First().Title,
                Items = journals.Select(j => new JournalDTO.JournalItem
                {
                    ItemId = j.Id,
                    Debit = j.Debit,
                    Credit = j.Credit,
                    Account = j.Account
                }).ToList()
            };

            return responseDto;
        }

        public JournalDTO? AddJournal(Guid companyId, JournalDTO journalRequest)
        {
            EnsureCompanyExists(companyId);
            Random random = new();
            string verificationNumber = "V" + random.Next(100, 1000);

            
            var journals = journalRequest.Items.Select(item => new Journal
            {
                Id = Guid.NewGuid(),
                CompanyId = companyId,
                Title = journalRequest.Title,
                VerificationNumber = verificationNumber,
                Debit = item.Debit,
                Credit = item.Credit,
                Account = item.Account,
                ItemId = new Guid()
                
                    
            }).ToList();

            _context.Journals.AddRange(journals);
            _context.SaveChanges();
            return GetJournal(companyId, verificationNumber);
        }

        // public bool UpdateJournal(Guid companyId, Guid id, JournalDTO journalRequest)
        // {
        //     var journal = _context.Journals
        //         .SingleOrDefault(j => j.CompanyId == companyId && j.Id == id);

        //     if (journal == null) return false;

        //     journal.Title = journalRequest.Title;
        //     journal.Debit = journalRequest.Debit;
        //     journal.Credit = journalRequest.Credit;
        //     journal.Account = journalRequest.Account;

        //     _context.SaveChanges();
        //     return true;
        // }

        public bool DeleteJournal(Guid companyId, string verificationNumber)
        {
            EnsureCompanyExists(companyId);
            var journal = _context.Journals
                .SingleOrDefault(j => j.CompanyId == companyId && j.VerificationNumber == verificationNumber);

            if (journal == null) return false;

            _context.Journals.Remove(journal);
            _context.SaveChanges();
            return true;
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