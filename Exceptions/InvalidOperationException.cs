namespace MyPublicAPI.Exceptions
{
    public class TotalMisMatchException(decimal totalDebit, decimal totalCredit) : Exception($"The total debits {totalDebit} do not match the total credits {totalCredit}.' was not found.")
    {
    }
}