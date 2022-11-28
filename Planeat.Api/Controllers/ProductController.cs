using Microsoft.AspNetCore.Mvc;
using Planeat.Core.Domain;
using Planeat.Infrastructure.Commands;
using Planeat.Infrastructure.Commands.Products;
using Planeat.Infrastructure.DTO;
using Planeat.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planeat.Api.Controllers
{
    public class ProductController : ApiControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService, ICommandDispatcher commandDispatcher) : base(commandDispatcher)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<ProductDto> products = await _productService.GetAllAsync();

            if (products == null)
            {
                return NotFound();
            }

            return Ok(products);
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            ProductDto product = await _productService.GetAsync(name);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateProduct command)
        {
            await CommandDispatcher.DispatchAsync(command);

            return Created($"product/{command.Name}", null);
        }
    }
}
