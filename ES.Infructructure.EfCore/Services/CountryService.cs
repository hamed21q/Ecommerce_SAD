﻿using ES.Domain.Entities.Users.Country;
using ES.Infructructure.EfCore.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Infructructure.EfCore.Services
{
    public class CountryService : Repository<long, Country>, ICountryService
    {
        public CountryService(EcommerceContext context) : base(context)
        {

        }
    }
}
