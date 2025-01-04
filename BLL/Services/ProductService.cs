using BLL.DTOs;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Repositories.Interfaces;

namespace BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            };
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllAsync();
            var productDTOs = new List<ProductDto>();
            foreach (var product in products)
            {
                productDTOs.Add(new ProductDto
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price
                });
            }
            return productDTOs;
        }

        public async Task AddProductAsync(ProductDto productDTO)
        {
            var product = new Product
            {
                Name = productDTO.Name,
                Price = productDTO.Price
            };
            await _productRepository.AddAsync(product);
        }

        public async Task UpdateProductAsync(ProductDto productDTO)
        {
            var product = await _productRepository.GetByIdAsync(productDTO.Id);
            if (product != null)
            {
                product.Name = productDTO.Name;
                product.Price = productDTO.Price;
                await _productRepository.UpdateAsync(product);
            }
        }

        public async Task DeleteProductAsync(int id)
        {
            await _productRepository.DeleteAsync(id);
        }
    }
}

