using ES.Application.Contracts.Country.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.Contracts.Country
{
    public interface ICountryApplication
    {
        void Add(CreateCountryCommand command);
    }
}
