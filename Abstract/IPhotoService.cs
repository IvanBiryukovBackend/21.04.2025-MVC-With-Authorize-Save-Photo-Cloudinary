using CloudinaryDotNet.Actions;

namespace ASPNETCoreMVCWithAuthAndPhotoCloud.Abstract
{
    public interface IPhotoService
    {
        Task<ImageUploadResult> AddPhotoAsync(IFormFile file);
        Task<DeletionResult> DeletePhotoAsync(string publicId);
    }
}
