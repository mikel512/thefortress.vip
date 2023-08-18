using Microsoft.AspNetCore.Http;

namespace vDomain.Interface;

public interface IStorageService
{
    Task<string> StoreImageFile(IFormFile image);
    Task<List<string>> GetAllImgsFromBlob();
}