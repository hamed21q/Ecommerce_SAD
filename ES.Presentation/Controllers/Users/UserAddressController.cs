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
        public UserAddressViewModel Get(long id)
        {
            return addressApplication.GetBy(id);
        }

        // POST api/<UserAddressController>
        [HttpPost]
        public void Post([FromBody] CreateUserAddressComand command)
        {
            addressApplication.Add(command);
        }

        // PUT api/<UserAddressController>/5
        [HttpPut]
        public void Put([FromBody] EditUserAddressCommand command)
        {
            addressApplication.Edit(command);
        }

        // DELETE api/<UserAddressController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            addressApplication.Delete(id);
        }
    }
}
