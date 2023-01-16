using ES.Application.Contracts.Users.User;
using ES.Application.Contracts.Users.User.DTOs;
using ES.Application.Contracts.Users.User.DTOs.Login;
using ES.Application.Contracts.Users.User.DTOs.Register;
using ES.Application.Contracts.Users.User.Validations;
using ES.Application.Contracts.Users.User.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text.Unicode;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
            var dto = new RegisterDTO
            {
                EmailAddress = command.EmailAddress,
                PhoneNumber = command.PhoneNumber,
                Password = CreateHash(command.Password),
                address = command.address
            };
            userApplication.Add(dto);
        }
        [HttpGet("test")]
        public bool test()
        {
            var s1 = "hamed";
            byte[] b1 = CreateHash(s1);
            //var s2 = "hamed";
            byte[] b2 = CreateHash(s1);

            return b1.SequenceEqual(b2);
        }
        private byte[] CreateHash(string password)
        {
            using(var hmac = new HMACSHA256())
            {
                return hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginUserCommand command)
        {
            var dto = new LoginDTO
            {
                EmailAddress = command.EmailAddress,
                Password = CreateHash(command.Password)
            };
            var result = userApplication.Login(dto);
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
                new Claim(ClaimTypes.Email, user.EmailAddress)
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

        // PUT api/<UserController>/5
        [HttpPut]
        public void Put([FromBody] EditUserCommand command)
        {
            userApplication.Edit(command);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            userApplication.Delete(id);
        }
    }
}
