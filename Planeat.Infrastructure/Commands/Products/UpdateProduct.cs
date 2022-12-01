﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planeat.Infrastructure.Commands.Products
{
    public class UpdateProduct : ICommand
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
