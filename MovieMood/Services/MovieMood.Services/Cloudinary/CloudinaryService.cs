namespace MovieMood.Services.Cloudinary
{
    using System.Threading.Tasks;

    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;

    public class CloudinaryService : ICloudinaryService
    {
        private readonly Cloudinary cloudinary;

        public CloudinaryService(CloudinaryDotNet.Cloudinary cloudinary)
        {
            this.cloudinary = cloudinary;
        }

        public async Task UploadAsync(string path)
        {
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(@$"{path}"),
            };
            var uploadResult = await this.cloudinary.UploadAsync(uploadParams);
        }
    }
}
