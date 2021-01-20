using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IdentityDemo.Controllers
{
    public class UserDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;

        public UserController(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> RegisterUser(UserDto userDto)
        {
            var user = new IdentityUser(userDto.UserName);
            await userManager.CreateAsync(user, userDto.Password);

            return this.Ok(userDto);
        }
    }
}
