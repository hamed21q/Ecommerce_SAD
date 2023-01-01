using ES.Application.Contracts.Users.User;
using ES.Application.Contracts.Users.User.DTOs;
using ES.Application.Contracts.Users.User.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ES.Presentation.Controllers.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserApplication userApplication;

        public UserController(IUserApplication userApplication)
        {
            this.userApplication = userApplication;
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
