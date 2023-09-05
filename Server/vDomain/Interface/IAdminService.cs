using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vDomain.Interface; 
public interface IAdminService
{
    Task<string> UploadImage(IFormFile file);
}
