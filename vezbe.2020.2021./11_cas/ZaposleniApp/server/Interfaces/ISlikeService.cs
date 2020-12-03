using System.Threading.Tasks;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace server.Interfaces
{
    public interface ISlikeService
    {
        Task<ImageUploadResult> DodajSlikuAsync(IFormFile file);
        Task<DeletionResult> ObrisiSlikuAsync(string publicId);
    }
}