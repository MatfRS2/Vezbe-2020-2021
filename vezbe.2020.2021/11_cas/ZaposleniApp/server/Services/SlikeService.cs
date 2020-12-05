using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using server.Helpers;
using server.Interfaces;

namespace server.Services
{
    public class SlikeService : ISlikeService
    {
        private readonly Cloudinary _cloudinary;
        public SlikeService(IOptions<ClodinaryOpcije> config)
        {
            var acc = new Account 
            (
                config.Value.CloudName,
                config.Value.ApiKey,
                config.Value.ApiSecret
            );

            _cloudinary = new Cloudinary(acc);
        }

        public async Task<ImageUploadResult> DodajSlikuAsync(IFormFile file)
        {
           var rezultatDodavanje = new ImageUploadResult();

            if (file.Length > 0)
            {
                using var stream = file.OpenReadStream();
                var dodavanjeParametri = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    Transformation = new Transformation().Height(500).Width(500).Crop("fill").Gravity("face")
                };
                rezultatDodavanje = await _cloudinary.UploadAsync(dodavanjeParametri);
            }

           return rezultatDodavanje;
        }

        public async Task<DeletionResult> ObrisiSlikuAsync(string publicId)
        {
           var brisanjeParametri = new DeletionParams(publicId);

           var rezultat = await _cloudinary.DestroyAsync(brisanjeParametri);

           return rezultat;
        }
    }
}