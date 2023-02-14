using ES.Application.Contracts.Users.User;
using ES.Application.Contracts.Users.User.DTOs;
using ES.Application.Contracts.Users.User.DTOs.Login;
using ES.Application.Contracts.Users.User.DTOs.Register;
using ES.Application.Contracts.Users.User.ViewModels;
using ES.Domain.Entities.Users.User;
using ES.Infructructure.EfCore.Services.Users;
using ES.Presentation.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;


namespace ES.Presentation.Controllers.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserApplication userApplication;
        private readonly IConfiguration configuration;
        private readonly IJwtUtils jwtUtils;

        public AuthController(IUserApplication userApplication, IConfiguration configuration, IJwtUtils jwtUtils)
        {
            this.userApplication = userApplication;
            this.configuration = configuration;
            this.jwtUtils = jwtUtils;
        }

        [HttpGet("{id}")]
        public async Task<UserViewModel> Get(long id)
        {
            return await userApplication.GetBy(id);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
        {
            await userApplication.Add(command);
            return Ok();
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
            var result = await userApplication.Login(command);
            if (result)
            {
                var user = await userApplication.FindByEmail(command.EmailAddress);
                return Ok( new LoginViewModel
                {
                    User = user,
                    Token = jwtUtils.GenerateToken(user)
                });
            }
            return BadRequest("Incorrect user credentials");
            
        }
        [HttpPost("setAdmin")]
        [Authorize(Roles = "owner")]
        public async Task<IActionResult> QualifyToAdmin(long id)
        {
            await userApplication.EditRole(id, "admin");
            return Ok();
        }
        [HttpPost("setOwner")]
        [Authorize(Roles = "owner")]
        public async Task<IActionResult> QualifyToOwner(long id)
        {
            await userApplication.EditRole(id, "owner");
            return Ok();
        }
        [HttpGet("Test")]
        [Authorize(Roles = "admin")]
        public async Task<UserViewModel> getUser()
        {
            var userIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid).Value;
            var id = long.Parse(userIdClaim);
            return await userApplication.GetBy(id);
        }

    }
}
