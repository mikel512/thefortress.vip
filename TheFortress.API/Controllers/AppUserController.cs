using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using TheFortress.API.Attributes;
using TheFortress.API.DAL;
using TheFortress.API.Data;
using TheFortress.API.Models;

namespace TheFortress.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [NTypewriterIgnore]
    public class AppUserController : ControllerBase
    {
        private UnitOfWork unitOfWork;
        private readonly IConfiguration _config;

        public AppUserController(TheFortressContext context, IConfiguration configuration)
        {
            unitOfWork = new UnitOfWork(context);
            _config = configuration;
        }

        //[HttpPut("{id}")]
        //public AppUser Put(int id, [FromBody] AppUser user)
        //{
        //    AppUser item = new AppUser();
        //    item.UserId = id;
        //    item.Email = user.Email;
        //    item.DisplayName = user.DisplayName;
        //    item.DateAdded = DateTime.Now;

        //    unitOfWork.AppUserRepository.Update(item);
        //    unitOfWork.Save();
        //    return item;
        //}


        [HttpPost("[action]")]
        public async Task<IActionResult> NewUserB2C()
        {
            try
            {
                if (Request.Headers.Authorization == 0)
                {
                    return BadRequest(BlockingResponse("No authorization headers in Request."));
                }

                string base64 = Request.Headers.Authorization[0].Replace("Basic ", "");

                byte[] data = Convert.FromBase64String(base64);
                string decodedString = Encoding.UTF8.GetString(data);
                Console.WriteLine(decodedString);
                string[] b2cVals = decodedString.Split(':');
                if (b2cVals[0] != _config.GetValue<string>("ApiConnectorUsername") || b2cVals[1] != _config.GetValue<string>("ApiConnectorPassword"))
                {
                    return BadRequest(BlockingResponse("Invalid authorization values."));
                }
                Console.WriteLine("Auth valid");

                // B2C request authenticated
                string json = "";
                Stream req = Request.Body;
                using (var reader = new StreamReader(req))
                {
                    json = await reader.ReadToEndAsync();
                }

                var userClaims = JsonConvert.DeserializeObject<dynamic>(json);

                AppUser user = new AppUser();
                user.Email = userClaims["email"];
                user.DisplayName = userClaims["displayName"];
                user.ObjectId = userClaims["objectId"];
                user.DateAdded = DateTime.UtcNow;
                user.DateModified = DateTime.UtcNow;

                unitOfWork.AppUserRepository.Insert(user);
                unitOfWork.Save();

                Console.WriteLine("OK response");
                return Ok(ContinueResponse());
            }
            catch (Exception ex)
            {
                return new JsonResult(BlockingResponse());
            }
        }

        private Object BlockingResponse()
        {
            var myData = new
            {
                version = "1.0.0",
                action = "ShowBlockPage",
                userMessage = "There was a problem with your request. You are not able to sign up at this time."
            };
            return myData;
        }
        private Object BlockingResponse(string userMessage)
        {
            var myData = new
            {
                version = "1.0.0",
                action = "ShowBlockPage",
                userMessage = $"{userMessage}"
            };
            return myData;
        }

        private Object ContinueResponse()
        {
            var myData = new
            {
                version = "1.0.0",
                action = "Continue"
            };
            return myData;
        }
    }
}
