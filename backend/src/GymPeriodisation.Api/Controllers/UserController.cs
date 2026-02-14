using GymPeriodisation.Application.Interfaces;
using GymPeriodisation.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GymPeriodisation.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userRepository.GetAllAsync();
            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            await _userRepository.AddAsync(user);
            return Ok(user);
        }
    }
}
