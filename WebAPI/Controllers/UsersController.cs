using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly WebAPIDbContext dbContext;

        public UsersController(WebAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await dbContext.Users.ToListAsync());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetUser([FromRoute] Guid id)
        {
            var user = await dbContext.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> AddUsers(AddUserRequest addUserRequest)
        {
            var user = new User()
            {
                Id = Guid.NewGuid(),
                Username = addUserRequest.Username,
                Password = addUserRequest.Password,
                Name = addUserRequest.Name,
                Surname = addUserRequest.Surname,
                Email = addUserRequest.Email,
                PhoneNumber = addUserRequest.PhoneNumber,
                Country = addUserRequest.Country,
                City = addUserRequest.City,
                Street = addUserRequest.Street,
                ZipCode = addUserRequest.ZipCode
            };

            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();

            return Ok(user);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateUser([FromRoute] Guid id, UpdateUserRequest updateUserRequest)
        {
            var user = await dbContext.Users.FindAsync(id);

            if (user != null)
            {
                user.Username = updateUserRequest.Username;
                user.Password = updateUserRequest.Password;
                user.Name = updateUserRequest.Name;
                user.Surname = updateUserRequest.Surname;
                user.Email = updateUserRequest.Email;
                user.PhoneNumber = updateUserRequest.PhoneNumber;
                user.Country = updateUserRequest.Country;
                user.City = updateUserRequest.City;
                user.Street = updateUserRequest.Street;
                user.ZipCode = updateUserRequest.ZipCode;

                await dbContext.SaveChangesAsync();

                return Ok(user);
            }

            return NotFound();
        }
    
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteContact([FromRoute] Guid id)
        {
            var user = await dbContext.Users.FindAsync(id);

            if (user != null)
            {
                dbContext.Remove(user);
                await dbContext.SaveChangesAsync();
                return Ok(user);
            }

            return NotFound();
        }

    }

}

