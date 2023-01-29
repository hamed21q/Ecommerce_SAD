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

        public async Task Add(CreateCountryCommand command)
        {
            var country = new Country(command.Name);
            await countryService.Add(country);
            await unitOfWork.Save();
        }

        public async Task Delete(long id)
        {
            var country = await countryService.GetBy(id);
            countryService.Delete(country);
            await unitOfWork.Save();
        }

        public async Task Edit(EditCoutnryCommand command)
        {
            var country = await countryService.GetBy(command.Id);
            country.Edit(command.Name);
            await unitOfWork.Save();
        }

        public async Task<List<CoutryViewModels>> GetAll()
        {
            var list = await countryService.GetAll();
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

        public async Task<CoutryViewModels> GetdBy(long id)
        {
            var country = await countryService.GetBy(id);
            return new CoutryViewModels
            {
                Id = country.Id,
                Name = country.Name,
                CreationDate = country.CreationDate.ToString(CultureInfo.InvariantCulture)
            };
        }
    }
}
