using ECommerce.Entity.Category;
using ECommerce.Entity.Product;
using ECommerce.Interfaces.IBAL;
using ECommerce.Interfaces.IRepository;

namespace ECommerce.BAL
{
    public class CategoryBAL : ICategoryBAL
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryBAL(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<CategoryResponse> CreateAsync(
            CategoryRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
            {
                return new CategoryResponse
                {
                    StatusCode = 400,
                    Message = "Category name is required",
                    Result = null
                };
            }

            var category = new Category
            {
                Name = request.Name,
                Description = request.Description,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            var createdCategory =
                await _categoryRepository.CreateAsync(category);

            return new CategoryResponse
            {
                StatusCode = 201,
                Message = "Category created successfully",
                Result = new CategoryResult
                {
                    CategoryId = createdCategory.CategoryId,
                    Name = createdCategory.Name,
                    Description = createdCategory.Description,
                    IsActive = createdCategory.IsActive,
                    CreatedAt = createdCategory.CreatedAt,
                    UpdatedAt = createdCategory.UpdatedAt
                }
            };
        }


        // GET ALL
        public async Task<CategoryListResponse> GetAllAsync()
        {
            var categories =
                await _categoryRepository.GetAllAsync();

            var result = categories.Select(c => new CategoryResult
            {
                CategoryId = c.CategoryId,
                Name = c.Name,
                Description = c.Description,
                IsActive = c.IsActive,
                CreatedAt = c.CreatedAt,
                UpdatedAt = c.UpdatedAt
            }).ToList();

            return new CategoryListResponse
            {
                StatusCode = 200,
                Message = "Categories retrieved successfully",
                Result = result
            };
        }


        // GET BY ID
        public async Task<CategoryResponse> GetByIdAsync(
            int categoryId)
        {
            var category =
                await _categoryRepository.GetByIdAsync(categoryId);

            if (category == null)
            {
                return new CategoryResponse
                {
                    StatusCode = 404,
                    Message = "Category not found",
                    Result = null
                };
            }

            return new CategoryResponse
            {
                StatusCode = 200,
                Message = "Category retrieved successfully",
                Result = new CategoryResult
                {
                    CategoryId = category.CategoryId,
                    Name = category.Name,
                    Description = category.Description,
                    IsActive = category.IsActive,
                    CreatedAt = category.CreatedAt,
                    UpdatedAt = category.UpdatedAt
                }
            };
        }


        // UPDATE
        public async Task<CategoryResponse> UpdateAsync(
            int categoryId,
            CategoryRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
            {
                return new CategoryResponse
                {
                    StatusCode = 400,
                    Message = "Category name is required",
                    Result = null
                };
            }

            var category =
                await _categoryRepository.GetByIdAsync(categoryId);

            if (category == null)
            {
                return new CategoryResponse
                {
                    StatusCode = 404,
                    Message = "Category not found",
                    Result = null
                };
            }

            category.Name = request.Name;
            category.Description = request.Description;
            category.UpdatedAt = DateTime.UtcNow;

            await _categoryRepository.UpdateAsync(category);

            return new CategoryResponse
            {
                StatusCode = 200,
                Message = "Category updated successfully",
                Result = new CategoryResult
                {
                    CategoryId = category.CategoryId,
                    Name = category.Name,
                    Description = category.Description,
                    IsActive = category.IsActive,
                    CreatedAt = category.CreatedAt,
                    UpdatedAt = category.UpdatedAt
                }
            };
        }


        // DELETE
        public async Task<CategoryResponse> DeleteAsync(
            int categoryId)
        {
            var category =
                await _categoryRepository.GetByIdAsync(categoryId);

            if (category == null)
            {
                return new CategoryResponse
                {
                    StatusCode = 404,
                    Message = "Category not found",
                    Result = null
                };
            }

            await _categoryRepository.DeleteAsync(categoryId);

            return new CategoryResponse
            {
                StatusCode = 200,
                Message = "Category deleted successfully",
                Result = null
            };
        }
        public async Task<CategoryWithProductsResponse> GetByIdWithProductsAsync(
    int categoryId)
        {
            var category =
                await _categoryRepository
                    .GetByIdWithProductsAsync(categoryId);

            if (category == null)
            {
                return new CategoryWithProductsResponse
                {
                    StatusCode = 404,
                    Message = "Category not found",
                    Result = null
                };
            }

            return new CategoryWithProductsResponse
            {
                StatusCode = 200,
                Message = "Category with products retrieved successfully",

                Result = new CategoryWithProductsResult
                {
                    CategoryId = category.CategoryId,
                    Name = category.Name,
                    Description = category.Description,
                    IsActive = category.IsActive,
                    CreatedAt = category.CreatedAt,
                    UpdatedAt = category.UpdatedAt,

                    Products = category.Products.Select(p =>
                        new ProductResult
                        {
                            ProductId = p.ProductId,
                            Name = p.Name,
                            Description = p.Description ?? string.Empty,
                            Price = p.Price,
                            StockQuantity = p.StockQuantity,
                            CategoryId = p.CategoryId,
                            IsActive = p.IsActive,
                            CreatedAt = p.CreatedAt,
                            UpdatedAt = p.UpdatedAt
                        }).ToList()
                }
            };
        }
        public async Task<CategoryWithProductsListResponse> GetAllWithProductsAsync()
        {
            var categories =
                await _categoryRepository.GetAllWithProductsAsync();

            var result = categories.Select(c =>
                new CategoryWithProductsResult
                {
                    CategoryId = c.CategoryId,
                    Name = c.Name,
                    Description = c.Description,
                    IsActive = c.IsActive,
                    CreatedAt = c.CreatedAt,
                    UpdatedAt = c.UpdatedAt,

                    Products = c.Products.Select(p =>
                        new ProductResult
                        {
                            ProductId = p.ProductId,
                            Name = p.Name,
                            Description = p.Description ?? string.Empty,
                            Price = p.Price,
                            StockQuantity = p.StockQuantity,
                            CategoryId = p.CategoryId,
                            IsActive = p.IsActive,
                            CreatedAt = p.CreatedAt,
                            UpdatedAt = p.UpdatedAt
                        }).ToList()
                }).ToList();

            return new CategoryWithProductsListResponse
            {
                StatusCode = 200,
                Message = "Categories with products retrieved successfully",
                Result = result
            };
        }
    }
}