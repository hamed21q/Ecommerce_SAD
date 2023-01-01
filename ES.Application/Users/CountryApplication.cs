using ES.Application.Contracts.Users.Country;
using ES.Application.Contracts.Users.Country.DTOs;
using ES.Application.Contracts.Users.Country.ViewModels;
using ES.Domain.DomainService;
using ES.Domain.Entities.Users.Country;
using System.Globalization;

namespace ES.Application.Users
{
    public class CountryApplication : ICountryApplication
    {
        private readonly ICountryService countryService;
        private readonly IUnitOfWork unitOfWork;

        public CountryApplication(ICountryService countryService, IUnitOfWork unitOfWork)
        {
            this.countryService = countryService;
            this.unitOfWork = unitOfWork;
        }

        public void Add(CreateCountryCommand command)
        {
            var country = new Country(command.Name);
            countryService.Add(country);
            unitOfWork.Save();
        }

        public void Delete(long id)
        {
            var country = countryService.GetBy(id);
            countryService.Delete(country);
            unitOfWork.Save();
        }

        public void Edit(EditCoutnryCommand command)
        {
            var country = countryService.GetBy(command.Id);
            country.Edit(command.Name);
            unitOfWork.Save();
        }

        public List<CoutryViewModels> GetAll()
        {
            var list = countryService.GetAll();
            var views = new List<CoutryViewModels>();
            foreach (var country in list)
            {
                views.Add(new CoutryViewModels
                {
                    Id = country.Id,
                    Name = country.Name,
                    CreationDate = country.CreationDate.ToString(CultureInfo.InvariantCulture)
                });
            }
            return views;
        }

        public CoutryViewModels GetdBy(long id)
        {
            var country = countryService.GetBy(id);
            return new CoutryViewModels
            {
                Id = country.Id,
                Name = country.Name,
                CreationDate = country.CreationDate.ToString(CultureInfo.InvariantCulture)
            };
        }
    }
}
