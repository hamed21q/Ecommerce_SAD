using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.Contracts.ProductCategory.DTOs
{
    public class RenameProductCategoryCommand
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public long Parent { get; set; }
    }
}
