using ECommerce.Entity.Product;
using ECommerce.Interfaces.IBAL;
using ECommerce.Interfaces.IRepository;

namespace ECommerce.BAL
{
    public class ProductBAL : IProductBAL
    {
        private readonly IProductRepository _productRepository;

        public ProductBAL(
            IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // CREATE
        public async Task<ProductResponse> AddAsync(
            ProductRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
            {
                return new ProductResponse
                {
                    StatusCode = 400,
                    Message = "Product name is required",
                    Result = null
                };
            }

            if (request.Price <= 0)
            {
                return new ProductResponse
                {
                    StatusCode = 400,
                    Message = "Product price must be greater than zero",
                    Result = null
                };
            }

            if (request.StockQuantity < 0)
            {
                return new ProductResponse
                {
                    StatusCode = 400,
                    Message = "Stock quantity cannot be negative",
                    Result = null
                };
            }

            var categoryExists =
                await _productRepository
                    .CategoryExistsAsync(
                        request.CategoryId);

            if (!categoryExists)
            {
                return new ProductResponse
                {
                    StatusCode = 404,
                    Message = "Category not found",
                    Result = null
                };
            }

            var product = new Product
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                StockQuantity = request.StockQuantity,
                CategoryId = request.CategoryId,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            var createdProduct =
                await _productRepository
                    .CreateAsync(product);

            return new ProductResponse
            {
                StatusCode = 201,
                Message = "Product created successfully",
                Result = new ProductResult
                {
                    ProductId = createdProduct.ProductId,
                    Name = createdProduct.Name,
                    Description =
                        createdProduct.Description
                        ?? string.Empty,
                    Price = createdProduct.Price,
                    StockQuantity =
                        createdProduct.StockQuantity,
                    CategoryId =
                        createdProduct.CategoryId,
                    IsActive =
                        createdProduct.IsActive,
                    CreatedAt =
                        createdProduct.CreatedAt,
                    UpdatedAt =
                        createdProduct.UpdatedAt
                }
            };
        }


        // GET ALL
        public async Task<ProductListResponse> GetAllAsync()
        {
            var products =
                await _productRepository.GetAllAsync();

            var result = products.Select(p =>
                new ProductResult
                {
                    ProductId = p.ProductId,
                    Name = p.Name,
                    Description =
                        p.Description ?? string.Empty,
                    Price = p.Price,
                    StockQuantity =
                        p.StockQuantity,
                    CategoryId =
                        p.CategoryId,
                    IsActive =
                        p.IsActive,
                    CreatedAt =
                        p.CreatedAt,
                    UpdatedAt =
                        p.UpdatedAt
                }).ToList();

            return new ProductListResponse
            {
                StatusCode = 200,
                Message = "Products retrieved successfully",
                Result = result
            };
        }


        // GET BY ID
        public async Task<ProductResponse> GetByIdAsync(
            int productId)
        {
            var product =
                await _productRepository
                    .GetByIdAsync(productId);

            if (product == null)
            {
                return new ProductResponse
                {
                    StatusCode = 404,
                    Message = "Product not found",
                    Result = null
                };
            }

            return new ProductResponse
            {
                StatusCode = 200,
                Message = "Product retrieved successfully",
                Result = new ProductResult
                {
                    ProductId =
                        product.ProductId,
                    Name =
                        product.Name,
                    Description =
                        product.Description
                        ?? string.Empty,
                    Price =
                        product.Price,
                    StockQuantity =
                        product.StockQuantity,
                    CategoryId =
                        product.CategoryId,
                    IsActive =
                        product.IsActive,
                    CreatedAt =
                        product.CreatedAt,
                    UpdatedAt =
                        product.UpdatedAt
                }
            };
        }


        // UPDATE
        public async Task<ProductResponse> UpdateAsync(
            int productId,
            ProductRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
            {
                return new ProductResponse
                {
                    StatusCode = 400,
                    Message = "Product name is required",
                    Result = null
                };
            }

            if (request.Price <= 0)
            {
                return new ProductResponse
                {
                    StatusCode = 400,
                    Message = "Product price must be greater than zero",
                    Result = null
                };
            }

            if (request.StockQuantity < 0)
            {
                return new ProductResponse
                {
                    StatusCode = 400,
                    Message = "Stock quantity cannot be negative",
                    Result = null
                };
            }

            var product =
                await _productRepository
                    .GetByIdAsync(productId);

            if (product == null)
            {
                return new ProductResponse
                {
                    StatusCode = 404,
                    Message = "Product not found",
                    Result = null
                };
            }

            var categoryExists =
                await _productRepository
                    .CategoryExistsAsync(
                        request.CategoryId);

            if (!categoryExists)
            {
                return new ProductResponse
                {
                    StatusCode = 404,
                    Message = "Category not found",
                    Result = null
                };
            }

            product.Name = request.Name;
            product.Description = request.Description;
            product.Price = request.Price;
            product.StockQuantity =
                request.StockQuantity;
            product.CategoryId =
                request.CategoryId;
            product.UpdatedAt =
                DateTime.UtcNow;

            await _productRepository
                .UpdateAsync(product);

            return new ProductResponse
            {
                StatusCode = 200,
                Message = "Product updated successfully",
                Result = new ProductResult
                {
                    ProductId =
                        product.ProductId,
                    Name =
                        product.Name,
                    Description =
                        product.Description
                        ?? string.Empty,
                    Price =
                        product.Price,
                    StockQuantity =
                        product.StockQuantity,
                    CategoryId =
                        product.CategoryId,
                    IsActive =
                        product.IsActive,
                    CreatedAt =
                        product.CreatedAt,
                    UpdatedAt =
                        product.UpdatedAt
                }
            };
        }


        // DELETE
        public async Task<ProductResponse> DeleteAsync(
            int productId)
        {
            var product =
                await _productRepository
                    .GetByIdAsync(productId);

            if (product == null)
            {
                return new ProductResponse
                {
                    StatusCode = 404,
                    Message = "Product not found",
                    Result = null
                };
            }

            await _productRepository
                .DeleteAsync(productId);

            return new ProductResponse
            {
                StatusCode = 200,
                Message = "Product deleted successfully",
                Result = null
            };
        }
    }
}