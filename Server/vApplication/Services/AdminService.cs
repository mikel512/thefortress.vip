using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using vApplication.Context;
using vApplication.Extensions;
using vDomain.Interface;

namespace vApplication.Services;

public class AdminService : IAdminService
{
    UnitOfWork unitOfWork;
    IStorageService _storageService;

    public AdminService(TheFortressContext context, IStorageService storageService)
    {
        unitOfWork = new UnitOfWork(context);
        _storageService = storageService;
    }

    public async Task<string> UploadImage(IFormFile file)
    {
        if (!file.ValidateFileExtension("jpg", "png", "jpeg"))
        {
            throw new Exception("Invalid file type");
        }

        return  await _storageService.StoreImageFile(file); 
    }

}
