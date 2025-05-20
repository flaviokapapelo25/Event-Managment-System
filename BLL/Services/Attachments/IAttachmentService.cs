using Microsoft.AspNetCore.Http;

namespace Services.Attachments
{
    public interface IAttachmentService
    {
        Task<string> UploadAsync(IFormFile file, string folderName);
        bool Delete(string filePath);
    }
}
