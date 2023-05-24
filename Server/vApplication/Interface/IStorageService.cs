using Microsoft.AspNetCore.Http;

namespace vApplication.Interface;

public interface IStorageService
{
    Task<string> StoreImageFile(IFormFile image);
    Task<List<string>> GetAllImgsFromBlob();
}