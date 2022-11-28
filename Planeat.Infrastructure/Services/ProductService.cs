using AutoMapper;
using Planeat.Core.Domain;
using Planeat.Core.Repositories;
using Planeat.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planeat.Infrastructure.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public ProductService(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            IEnumerable<Product> products = await _productRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(products);
        }

        public async Task<ProductDto> GetAsync(string name)
        {
            Product product = await _productRepository.GetAsync(name);
            return _mapper.Map<Product, ProductDto>(product);
        }

        public async Task CreateAsync(string name, decimal price, Guid createdBy)
        {
            Product product = await _productRepository.GetAsync(name);

            if (product != null)
            {
                throw new Exception($"Prodcut with name {name} already exist.");
            }

            product = new Product(name, price, createdBy);
            await _productRepository.AddAsync(product);
        }
    }
}
