﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.Contracts.ShoppingCard.ShoppingCard.DTOs
{
    public class EditShoppingCardCommand
    {
        public long Id { get; set; }
        public long UserId { get; set; }
    }
}
