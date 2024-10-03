namespace MyPublicAPI.Models
{
    public class Journal
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public required string VerificationNumber { get; set; }
        public Guid ItemId { get; set; }
        public required Guid CompanyId { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public int Account { get; set; }

    }
}