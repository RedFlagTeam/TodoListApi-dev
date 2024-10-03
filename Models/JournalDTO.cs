using System.Text.Json.Serialization;
namespace MyPublicAPI.Models
{
    public class JournalDTO
    {
        [JsonPropertyName("VerificationNumber")]
        public string? VerificationNumber { get; set; }

        public required string Title { get; set; }

        public required List<JournalItem> Items { get; set; }
        public class JournalItem
        {
            public Guid ItemId { get; set; }
            public decimal Debit { get; set; }
            public decimal Credit { get; set; }
            public int Account { get; set; }
        }
    }
}