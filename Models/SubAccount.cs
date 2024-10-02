namespace MyPublicAPI.Models
{
    public class SubAccount
    {
        public Guid Id { get; set; }
        public required int SubAccountNumber{ get; set; }
        public required int AccountNumber{ get; set; }
        public string? AccountName { get; set; }

    }
}