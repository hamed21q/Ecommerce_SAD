using ES.Application.Contracts.Users.Role;
using ES.Application.Contracts.Users.Role.DTOs;
using ES.Application.Contracts.Users.Role.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ES.Presentation.Controllers.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        private readonly IUserRoleApplication userRoleApplication;

        public UserRoleController(IUserRoleApplication userRoleApplication)
        {
            this.userRoleApplication = userRoleApplication;
        }

        // GET api/<UserRoleController>/5
        [HttpGet("{id}")]
        public UserRoleViewModel Get(long id)
        {
            return userRoleApplication.GetBy(id);
        }

        // POST api/<UserRoleController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateUserRoleCommand command)
        {
            userRoleApplication.Add(command);
            return Ok();
        }

        // PUT api/<UserRoleController>/5
        [HttpPut]
        public IActionResult Put([FromBody] EditUserRoleCommand command)
        {
            userRoleApplication.Edit(command);
            return Ok();
        }

        // DELETE api/<UserRoleController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            userRoleApplication.Delete(id);
        }
        [HttpGet]
        public List<UserRoleViewModel> GetAll()
        {
            return userRoleApplication.GetAll();
        }
    }
}
