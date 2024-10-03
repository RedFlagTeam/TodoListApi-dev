using Microsoft.AspNetCore.Mvc;
using MyPublicAPI.Services;
namespace MyPublicAPI.Controllers
{
    [Route("publicapi/companies/{companyId}/[controller]")]
    [ApiController]
    public class FilesController(IFileService fileService) : ControllerBase
    {
        private readonly IFileService _fileService = fileService;

        [HttpGet("getFilesInfo")]
        public async Task<IActionResult> GetFilesByCompanyId(Guid companyId, string? journalVerificationNumber = null)
        {
            var files = await _fileService.GetFilesByCompanyIdAsync(companyId, journalVerificationNumber);
            return Ok(files);

        }

        [HttpPost("uploadFile")]
        public async Task<IActionResult> UploadFile(Guid companyId, IFormFile file, string? journalVerificationNumber = null)
        {
            var fileInfo = await _fileService.UploadFileAsync(companyId, file, journalVerificationNumber);
            return Ok(new { fileInfo.Id, fileInfo.Name, fileInfo.Size, fileInfo.Type, fileInfo.VerificationNumber });

        }
        [HttpGet("downloadFile")]
        public async Task<IActionResult> DownloadFile(Guid companyId, string fileName, string? journalVerificationNumber = null)
        {
            var fileInfo = await _fileService.DownloadFileByFileName(companyId, fileName, journalVerificationNumber);
            return Ok(new { fileInfo.Blob });

        }

    }
}