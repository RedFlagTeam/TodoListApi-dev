using System.Text.Json.Serialization;
namespace MyPublicAPI.Models
{
    public class JournalRequestDTO
    {
        [JsonPropertyName("VerificationNumber")]
        public required string VerificationNumber { get; set; }

        public required string Title { get; set; }
        public class JournalItem
        {
            public Guid Id { get; set; }
            public decimal Debit { get; set; }
            public decimal Credit { get; set; }
            public int Account { get; set; }
        }
    }
}