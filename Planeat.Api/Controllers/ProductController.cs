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

        public ProductController(ICommandDispatcher commandDispatcher, 
            IProductService productService) : base(commandDispatcher)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<ProductDto> products = await _productService.GetAllAsync();

            return Ok(products);
        }

        //[HttpGet]
        //public async Task<IActionResult> Get(Guid id)
        //{
        //    ProductDto product = await _productService.GetAsync(id);

        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(product);
        //}

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
        public async Task<IActionResult> Create(CreateProduct command)
        {
            await CommandDispatcher.DispatchAsync(command);

            return Created($"product/{command.Name}", null);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateProduct command)
        {
            await _productService.UpdateAsync(id, command.Name, command.Price);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _productService.DeleteAsync(id);

            return NoContent();
        }
    }
}
