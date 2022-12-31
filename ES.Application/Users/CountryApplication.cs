using ES.Application.Contracts.Users.Country;
using ES.Application.Contracts.Users.Country.DTOs;
using ES.Domain.Entities.Country;

namespace ES.Application.Users
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
