namespace MovieMood.Services.Cloudinary
{
    using System.Threading.Tasks;

    public interface ICloudinaryService
    {
        Task UploadAsync(string path);
    }
}
