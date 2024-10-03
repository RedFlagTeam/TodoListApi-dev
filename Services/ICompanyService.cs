using System.Threading.Tasks;

namespace MyPublicAPI.Services
{
    public interface ICompanyService
    {
        Task<bool> CompanyExistsAsync(Guid companyId);
        
    }
}