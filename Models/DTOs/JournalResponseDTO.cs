using System.Text.Json.Serialization;
namespace MyPublicAPI.Models
{
    public class JournalResponseDTO
    {
        
        public Guid Id { get; set; }
        public required string Title {get; set; }
        
        [JsonPropertyName("VerificationNumber")]
        public required string VerificationNumber { get; set; }
        public decimal Price { get; set; }
    }
}