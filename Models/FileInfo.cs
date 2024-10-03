namespace MyPublicAPI.Models
{
    public class FileInfo
    {
        public required string Name { get; set; }
        public required double Size { get; set; }
        public required string Type { get; set; }
        public string VerificationNumber { get; set; }
        public required Guid CompanyId { get; set; }
    }
}