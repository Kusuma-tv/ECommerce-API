using ECommerce.DataAccess;
using ECommerce.Entity.Product;
using ECommerce.Interfaces.IRepository;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        // CREATE
        public async Task<Product> CreateAsync(Product product)
        {
            await _context.Products.AddAsync(product);

            await _context.SaveChangesAsync();

            return product;
        }

        // CHECK CATEGORY
        public async Task<bool> CategoryExistsAsync(
            int categoryId)
        {
            return await _context.Categories
                .AnyAsync(c => c.CategoryId == categoryId);
        }

        // GET ALL
        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products
                .AsNoTracking()
                .ToListAsync();
        }

        // GET BY ID
        public async Task<Product?> GetByIdAsync(
            int productId)
        {
            return await _context.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(
                    p => p.ProductId == productId);
        }

        // UPDATE
        public async Task<bool> UpdateAsync(
            Product product)
        {
            _context.Products.Update(product);

            await _context.SaveChangesAsync();

            return true;
        }

        // DELETE
        public async Task<bool> DeleteAsync(
            int productId)
        {
            var product =
                await _context.Products
                    .FirstOrDefaultAsync(
                        p => p.ProductId == productId);

            if (product == null)
            {
                return false;
            }

            _context.Products.Remove(product);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}