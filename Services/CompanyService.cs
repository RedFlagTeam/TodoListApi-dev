using System;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyPublicAPI.Data;
using MyPublicAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MyPublicAPI.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ApiContext _context;

        public CompanyService(ApiContext context)
        {
            _context = context;
        }

        public async Task<bool> CompanyExistsAsync(Guid companyId)
        {
            return await _context.UserCompanies.AnyAsync(c => c.CompanyId == companyId);
        }
    }
}
