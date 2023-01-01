using ES.Domain.Entities.Users.Country;
using ES.Infructructure.EfCore.Base;


namespace ES.Infructructure.EfCore.Services.Users
{
    public class CountryService : Repository<long, Country>, ICountryService
    {
        public CountryService(EcommerceContext context) : base(context)
        {

        }
    }
}
