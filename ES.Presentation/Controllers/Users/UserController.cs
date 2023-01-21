using ES.Application.Contracts.Users.User;
using ES.Application.Contracts.Users.User.DTOs;
using ES.Application.Contracts.Users.User.DTOs.Login;
using ES.Application.Contracts.Users.User.DTOs.Register;
using ES.Application.Contracts.Users.User.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;


namespace ES.Presentation.Controllers.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserApplication userApplication;
        private readonly IConfiguration configuration;

        public UserController(IUserApplication userApplication, IConfiguration configuration)
        {
            this.userApplication = userApplication;
            this.configuration = configuration;
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public UserViewModel Get(long id)
        {
            return userApplication.GetBy(id);
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] CreateUserCommand command)
        {
            userApplication.Add(command);
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginUserCommand command)
        {
            var result = userApplication.Login(command);
            if (result)
            {
                var user = userApplication.FindByEmail(command.EmailAddress);
                return Ok( new LoginViewModel
                {
                    User = user,
                    Token = CreateToken(user)
                });
            }
            return BadRequest("Incorrect user credentials");
            
        }

        private string CreateToken(UserViewModel user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.EmailAddress),
                new Claim(ClaimTypes.Role, user.Role)
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(configuration.GetSection("AppSettings:Token").Value));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: cred);
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

        [HttpPut]
        public void Put([FromBody] EditUserCommand command)
        {
            userApplication.Edit(command);
        }
        [HttpPost("setAdmin")]
        [Authorize(Roles = "owner")]
        public void QualifyToAdmin(long id)
        {
            userApplication.EditRole(id, "admin");
        }
        [HttpPost("setOwner")]
        [Authorize(Roles = "owner")]
        public void QualifyToOwner(long id)
        {
            userApplication.EditRole(id, "owner");
        }
    }
}
