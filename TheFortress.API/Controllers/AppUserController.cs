using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheFortress.API.DAL;
using TheFortress.API.Data;
using TheFortress.API.Models;

namespace TheFortress.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private UnitOfWork unitOfWork;

        public AppUserController(TheFortressContext context)
        {
            unitOfWork = new UnitOfWork(context);
        }


        [HttpGet]
        public async Task<IEnumerable<AppUser>> Get()
        {
            return await unitOfWork.AppUserRepository.Get();
        }

        // GET /<ConcertController>/5
        [HttpGet("{id}")]
        public async Task<AppUser> GetById(int id)
        {
            return await unitOfWork.AppUserRepository.GetByID(id);
        }

        [HttpPost]
        public AppUser Post([FromBody] AppUser user)
        {
            AppUser item = new AppUser();
            item.Email = user.Email;
            item.DisplayName = user.DisplayName;
            item.DateAdded = DateTime.Now;

            unitOfWork.AppUserRepository.Insert(item);
            unitOfWork.Save();
            return item;
        }

        [HttpPut("{id}")]
        public AppUser Put(int id, [FromBody] AppUser user)
        {
            AppUser item = new AppUser();
            item.UserId = id;
            item.Email = user.Email;
            item.DisplayName = user.DisplayName;
            item.DateAdded = DateTime.Now;

            unitOfWork.AppUserRepository.Update(item);
            unitOfWork.Save();
            return item;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            unitOfWork.AppUserRepository.Delete(id);
        }
    }
}
