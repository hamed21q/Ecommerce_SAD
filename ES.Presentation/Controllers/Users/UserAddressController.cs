using ES.Application.Contracts.Users.UserAddress;
using ES.Application.Contracts.Users.UserAddress.DTOs;
using ES.Application.Contracts.Users.UserAddress.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ES.Presentation.Controllers.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAddressController : ControllerBase
    {
        private readonly IUserAddressApplication addressApplication;

        public UserAddressController(IUserAddressApplication addressApplication)
        {
            this.addressApplication = addressApplication;
        }

        // GET api/<UserAddressController>/5
        [HttpGet("{id}")]
        public async Task<UserAddressViewModel> Get(long id)
        {
            return await addressApplication.GetBy(id);
        }

        // POST api/<UserAddressController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserAddressComand command)
        {
            await addressApplication.Add(command);
            return Ok();
        }

        // PUT api/<UserAddressController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] EditUserAddressCommand command)
        {
            await addressApplication.Edit(command);
            return Ok();
        }

        // DELETE api/<UserAddressController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await addressApplication.Delete(id);
            return Ok();
        }
    }
}
