using ChatApplication.Entity;
using ChatApplication.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ChatApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IUserRepository userRepository;

        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpGet("GetUserByEmail/{UserEmail}")]
        public User GetUserByEmail(string UserEmail)
        {
            return this.userRepository.GetUser(UserEmail);
        }

        [HttpPost("CreateUser")]
        public User CreateUser([FromBody] User User)
        {
            return this.userRepository.AddUser(User.UserName, User.UserEmail);
        }
    }
}