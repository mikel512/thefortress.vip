using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using vApplication.Context;
using vApplication.Extensions;
using vDomain.Attributes;
using vDomain.Interface;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[NTypewriterIgnore]
public class AdminController : ControllerBase
{
    private readonly IAdminService _adminService;

    public AdminController(IAdminService adminService)
    {
        _adminService = adminService;
    }

    [HttpPost("[action]")]
    [Authorize(Roles = "Admin")]
    public async Task<string> UploadImage()
    {
        return await _adminService.UploadImage(Request.Form.Files.First());
    }
}