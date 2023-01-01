using ES.Application.Contracts.Users.Country;
using ES.Application.Contracts.Users.Country.DTOs;
using ES.Application.Contracts.Users.Country.ViewModels;
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
        public CoutryViewModels Get(long id)
        {
            return countryApplication.GetdBy(id);
        }

        // POST api/<CountryController>
        [HttpPost]
        public void Post([FromBody] CreateCountryCommand command)
        {
            countryApplication.Add(command);
        }

        // PUT api/<CountryController>/5
        [HttpPut]
        public void Put([FromBody] EditCoutnryCommand command)
        {
            countryApplication.Edit(command);
        }

        // DELETE api/<CountryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            countryApplication.Delete(id);
        }
        [HttpGet]
        public List<CoutryViewModels> GetAll()
        {
            return countryApplication.GetAll();
        }
    }
}
