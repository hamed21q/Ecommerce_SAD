using ES.Application.Contracts.Users.Country.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.Contracts.Users.Country
{
    public interface ICountryApplication
    {
        void Add(CreateCountryCommand command);
    }
}
