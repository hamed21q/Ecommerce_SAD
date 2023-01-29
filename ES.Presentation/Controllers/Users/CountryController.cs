using ES.Application.Contracts.Users.Country;
using ES.Application.Contracts.Users.Country.DTOs;
using ES.Application.Contracts.Users.Country.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace ES.Presentation.Controllers.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryApplication countryApplication;

        public CountryController(ICountryApplication countryApplication)
        {
            this.countryApplication = countryApplication;
        }

        // GET api/<CountryController>/5
        [HttpGet("{id}")]
        public async Task<CoutryViewModels> Get(long id)
        {
            return await countryApplication.GetdBy(id);
        }

        // POST api/<CountryController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCountryCommand command)
        {
            await countryApplication.Add(command);
            return Ok();
        }

        // PUT api/<CountryController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] EditCoutnryCommand command)
        {
            await countryApplication.Edit(command);
            return Ok();

        }

        // DELETE api/<CountryController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await countryApplication.Delete(id);
            return Ok();
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<List<CoutryViewModels>> GetAll()
        {
            return await countryApplication.GetAll();
        }
    }
}
