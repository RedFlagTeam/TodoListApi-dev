using System.Reflection.Metadata;

namespace MyPublicAPI.Models
{
    public class File
    {
        public Guid Id { get; set; }
        public required byte[] Blob { get; set; } 

        public required string Name { get; set; }

        public required double Size { get; set; }

        public required string Type { get; set; }
        public required string VerificationNumber { get; set; }

    }
}