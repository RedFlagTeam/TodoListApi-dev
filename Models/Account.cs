namespace MyPublicAPI.Models
{
    public class Account
    {
        public Guid Id { get; set; }
        public required int AccountNumber{ get; set; }
        public string? AccountName { get; set; }
        public string? AccountType{ get; set; }

    }
}