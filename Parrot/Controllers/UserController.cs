using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Parrot.Model;
using Parrot.Repositories.Interfaces;

namespace Parrot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> GetAllUsers()
        {
            List<UserModel> users = await _userRepository.GetAllUsers();
            return Ok(users);
        }

        [HttpPost]
        public async Task<ActionResult<UserModel>> CreateUser([FromBody] UserModel userModel)
        {
            UserModel user = await _userRepository.CreateUser(userModel);
            return Ok(user);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> FindUserById(int id)
        {
            UserModel user = await _userRepository.GetUserById(id);
            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserModel>> UpdateUser(int id, [FromBody] UserModel userModel)
        {
            UserModel user = await _userRepository.UpdateUser(id, userModel);
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteUser(int id)
        {
            bool userDeleted = await _userRepository.DeleteUser(id);
            return Ok(userDeleted);
        }
    }
}
