using ES.Application.Contracts.Users.Country.DTOs;
using ES.Application.Contracts.Users.Country.ViewModels;
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
        void Edit(EditCoutnryCommand command);
        CoutryViewModels GetdBy(long id);
        List<CoutryViewModels> GetAll();
        void Delete(long id);
    }
}
