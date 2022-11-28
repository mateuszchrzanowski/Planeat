using Planeat.Infrastructure.Commands;
using Planeat.Infrastructure.Commands.Products;
using Planeat.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planeat.Infrastructure.Handlers.Products
{
    public class CreateProductHandler : ICommandHandler<CreateProduct>
    {
        private readonly IProductService _productService;

        public CreateProductHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task HandleAsync(CreateProduct command)
        {
            await _productService.CreateAsync(command.Name, command.Price, command.CreatedBy);
        }
    }
}
