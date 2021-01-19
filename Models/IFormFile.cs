
// system need for File upload
using System.IO;
using Microsoft.AspNetCore.Http;

namespace FileUpload.Models
{
    public interface IFormFile
    {
        string ContentType { get; set; }
        string ContentDisposition { get; set; }
        IHeaderDictionary Headers { get; set; }
        long Length { get; set; }
        string Name { get; set; }
        string FileName { get; set; }
        Stream OpenReadStream();
        void CopyTo(Stream target);
        // Task CopyToAsync(Stream target, CancellationToken cancellationToken = null);



    }


}

