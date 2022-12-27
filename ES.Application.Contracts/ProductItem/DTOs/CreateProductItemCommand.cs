using ES.Application.Contracts.ProductConfiguration.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.Contracts.ProductItem.DTOs
{
    public class CreateProductItemCommand
    {
        public long ProductId { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public List<long> configurations { get; set; }
    }
}