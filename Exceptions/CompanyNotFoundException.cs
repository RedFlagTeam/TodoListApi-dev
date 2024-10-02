using System;

namespace MyPublicAPI.Exceptions
{
    public class CompanyNotFoundException(Guid companyId) : Exception($"Company with ID '{companyId}' was not found.")
    {
    }
}