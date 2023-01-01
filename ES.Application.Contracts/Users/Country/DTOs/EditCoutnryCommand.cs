using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.Contracts.Users.Country.DTOs
{
    public class EditCoutnryCommand : CreateCountryCommand
    {
        public long Id { get; set; }
    }
}
