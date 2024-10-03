
namespace MyPublicAPI.Exceptions
{
    public class FileNotFoundException(string fileName, Guid companyId) : Exception($"File with Name '{fileName}' was not found for the Company with companyId '{companyId}'.")
    {
    }
}