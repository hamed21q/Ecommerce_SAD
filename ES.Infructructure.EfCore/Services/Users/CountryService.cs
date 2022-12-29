using ES.Domain.Entities.Country;
using ES.Infructructure.EfCore.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Infructructure.EfCore.Services.Users
{
    public class CountryService : Repository<long, Country>, ICountryService
    {
        public CountryService(EcommerceContext context) : base(context)
        {

        }
    }
}
