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
        public async Task<UserRoleViewModel> Get(long id)
        {
            return await userRoleApplication.GetBy(id);
        }

        // POST api/<UserRoleController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserRoleCommand command)
        {
            await userRoleApplication.Add(command);
            return Ok();
        }

        // PUT api/<UserRoleController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] EditUserRoleCommand command)
        {
            await userRoleApplication.Edit(command);
            return Ok();
        }

        // DELETE api/<UserRoleController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await userRoleApplication.Delete(id);
            return Ok();
        }
        [HttpGet]
        public async Task<List<UserRoleViewModel>> GetAll()
        {
            return await userRoleApplication.GetAll();
        }
    }
}
