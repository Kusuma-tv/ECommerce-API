using ECommerce.Entity.User;

namespace ECommerce.Interfaces.IRepository
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAsync(string email);

        Task<User> CreateAsync(User user);
        Task<User?> GetUserByEmailAsync(string email);
    }
}