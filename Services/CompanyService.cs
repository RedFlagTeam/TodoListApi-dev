
using MyPublicAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace MyPublicAPI.Services
{
    public class CompanyService(ApiContext context) : ICompanyService
    {
        private readonly ApiContext _context = context;

        public async Task<bool> CompanyExistsAsync(Guid companyId)
        {
            return await _context.UserCompanies.AnyAsync(c => c.CompanyId == companyId);
        }
    }
}
