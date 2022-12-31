using ES.Application.Contracts.Country;
using ES.Application.Contracts.Country.DTOs;
using ES.Domain.Entities.Users.Country;

namespace ES.Application
{
    public class CountryApplication : ICountryApplication
    {
        private readonly ICountryService countryService;
        public void Add(CreateCountryCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
