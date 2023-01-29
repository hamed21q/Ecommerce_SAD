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
        Task Add(CreateCountryCommand command);
        Task Edit(EditCoutnryCommand command);
        Task<CoutryViewModels> GetdBy(long id);
        Task<List<CoutryViewModels>> GetAll();
        Task Delete(long id);
    }
}
