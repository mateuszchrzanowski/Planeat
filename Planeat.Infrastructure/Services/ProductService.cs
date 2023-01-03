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
        private readonly IProductListRepository _productListRepository;

        public ProductService(IMapper mapper, IProductRepository productRepository, 
            IProductListRepository productListRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _productListRepository = productListRepository;
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

        public async Task<ProductDto> GetAsync(Guid id)
        {
            Product product = await _productRepository.GetAsync(id);
            return _mapper.Map<Product, ProductDto>(product);
        }

        public async Task CreateAsync(string name, decimal price, Guid productListId)
        {
            Product product = await _productRepository.GetAsync(name);

            if (product != null)
            {
                throw new Exception($"Prodcut with name {name} already exist.");
            }

            ProductList productsList = await _productListRepository.GetAsync(productListId);

            if (productsList == null)
            {
                throw new Exception($"Prodcut List doesn't exist.");
            }

            product = Product.Create(name, price, productsList);
            await _productRepository.AddAsync(product);
            await _productListRepository.UpdateAsync(productsList);
        }

        public async Task UpdateAsync(Guid id, string name, decimal price)
        {
            Product product = await _productRepository.GetAsync(name);

            if (product != null)
            {
                throw new Exception($"Product with name {name} already exist");
            }

            product = await _productRepository.GetAsync(id);

            if (product == null)
            {
                throw new Exception("Prodcut does not exits.");
            }

            product.SetName(name);
            product.SetPrice(price);

            await _productRepository.UpdateAsync(product);
        }

        public async Task DeleteAsync(Guid id)
        {
            Product product = await _productRepository.GetAsync(id);

            if (product == null)
            {
                throw new Exception("Prodcut does not exits.");
            }

            await _productRepository.RemoveAsync(product);
        }
    }
}
