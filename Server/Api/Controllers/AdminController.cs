using Api.Data;
using Api.Extensions;
using Common.Attributes;
using DataAccessLibrary.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [NTypewriterIgnore]
    public class AdminController : ControllerBase
    {
        UnitOfWork unitOfWork;
        IStorageService _storageService;

        public AdminController(TheFortressContext context, IStorageService storageService)
        {
            unitOfWork = new UnitOfWork(context);
            _storageService = storageService;
        }

        [HttpPost("[action]")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UploadImage()
        {
            try
            {
                var formRequest = Request.Form;
                IFormFile file = formRequest.Files.First();

                if (!file.ValidateFileExtension("jpg", "png", "jpeg"))
                {
                    return StatusCode(StatusCodes.Status415UnsupportedMediaType);
                }

                string imageUrl = await _storageService.StoreImageFile(file);

                return new ObjectResult(imageUrl);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
