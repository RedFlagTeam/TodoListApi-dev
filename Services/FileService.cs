using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MyPublicAPI.Data;
using File = MyPublicAPI.Models.File;
using FileInfo = MyPublicAPI.Models.FileInfo;
using MyPublicAPI.Exceptions;
namespace MyPublicAPI.Services
{

    public class FileService : IFileService
    {
        private readonly ApiContext _context;
        private readonly ICompanyService _companyService;

        public FileService(ApiContext context, ICompanyService companyService)
        {
            _context = context;
            _companyService = companyService;
        }

        public async Task<File> UploadFileAsync(Guid companyId, IFormFile file, string? journalVerificationNumber)
        {
            var companyExists = await _companyService.CompanyExistsAsync(companyId);

            if (!companyExists)
            {
                throw new ArgumentException("The specified company does not exist.");
            }
            if (file == null || file.Length == 0)
            {
                throw new ArgumentException("No file uploaded.");
            }

            // Read the file into a byte array
            byte[] fileData;
            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                fileData = memoryStream.ToArray();
            }

            // Create a new FileInfo object and save it to the database
            var fileInfo = new File
            {
                Id = Guid.NewGuid(), // Generate a new GUID
                CompanyId = companyId,
                Name = file.FileName,
                Size = file.Length,
                Type = file.ContentType,
                Blob = fileData,
                VerificationNumber = journalVerificationNumber ?? string.Empty
            };

            _context.Files.Add(fileInfo);
            await _context.SaveChangesAsync();

            return fileInfo; // Return the created file info
        }

        public async Task<List<FileInfo>> GetFilesByCompanyIdAsync(Guid companyId, string? journalVerificationNumber)
        {
            var companyExists = await _companyService.CompanyExistsAsync(companyId);

            if (!companyExists)
            {
                throw new CompanyNotFoundException(companyId);
            }
            var filesInfo = await _context.Files
                                      .Where(f => f.CompanyId == companyId)
                                      .Select(f => new FileInfo
                                      {
                                          CompanyId = f.CompanyId,
                                          Name = f.Name,
                                          Size = f.Size,
                                          Type = f.Type,
                                          VerificationNumber = f.VerificationNumber
                                      })
                                      .ToListAsync();

            return filesInfo;
        }
        public async Task<File> DownloadFileByFileName(Guid companyId, string fileName, string? journalVerificationNumber)
        {
            var companyExists = await _companyService.CompanyExistsAsync(companyId);

            if (!companyExists)
            {
                throw new CompanyNotFoundException(companyId);
            }

            File? file;
            if (string.IsNullOrEmpty(journalVerificationNumber))
            {
                file = await _context.Files
                                     .FirstOrDefaultAsync(f => f.CompanyId == companyId && f.Name == fileName);
            }
            else
            {
                file = await _context.Files
                                     .FirstOrDefaultAsync(f => f.CompanyId == companyId && f.Name == fileName && f.VerificationNumber == journalVerificationNumber);
            }

            if (file == null)
            {
                throw new Exceptions.FileNotFoundException(fileName, companyId);
            }

            return file;
        }


    }
}