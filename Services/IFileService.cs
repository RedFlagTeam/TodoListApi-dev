using Microsoft.AspNetCore.Http;
using System.Reflection.Metadata;
using System.Threading.Tasks;

using File = MyPublicAPI.Models.File;
using FileInfo = MyPublicAPI.Models.FileInfo;

namespace MyPublicAPI.Services
{

    public interface IFileService
    {
        Task<File> UploadFileAsync(Guid companyId, IFormFile file, string? journalVerificationNumber);
        Task<List<FileInfo>> GetFilesByCompanyIdAsync(Guid companyId, string? journalVerificationNumber);
        Task<File> DownloadFileByFileName(Guid companyId, string fileName, string? journalVerificationNumber);

    }

}