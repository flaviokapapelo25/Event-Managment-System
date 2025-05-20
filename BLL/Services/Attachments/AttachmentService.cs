using Microsoft.AspNetCore.Http;


namespace Services.Attachments
{
    public class AttachmentService : IAttachmentService
    {
        private List<string> _allowedExtensions = [".png", ".jpg", ".jpeg"];
        private const int _allowedMaxSize = 10_485_760;
        public  async Task<string?> UploadAsync(IFormFile file, string folderName)
        {
            // The name of the file with the extension , return the extension with the dot.
            var extension = Path.GetExtension(file.FileName);

            if (!_allowedExtensions.Contains(extension.ToLower()))
                return null;

            if (file.Length > _allowedMaxSize)
                return null;

            // var folderPath = $"{Directory.GetCurrentDirectory()}\\wwwroot\\Assets\\{folderName}";
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", folderName);

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);


            var fileName =$"{Guid.NewGuid()}{extension}";
            var filePath = Path.Combine(folderPath, fileName);


            // Streaming : Date Per time

            using var fileStream = new FileStream(filePath, FileMode.Create);
            // = fileStram = File.Create(filePath);

            await file.CopyToAsync(fileStream);
            return $"/{folderName}/{fileName}";
        }

        public bool Delete(string filePath)
        {
            if(File.Exists(filePath))
            {
                File.Delete(filePath);
                return true;
            }
            return false;
        }

    }
}
