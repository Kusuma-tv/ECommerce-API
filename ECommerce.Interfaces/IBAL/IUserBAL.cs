using ECommerce.Entity.User;
using ECommerce.Entity.User.ECommerce.Entity.User;

namespace ECommerce.Interfaces.IBAL
{
    public interface IUserBAL
    {
        Task<UserResponse> RegisterAsync(UserRequest request);
        Task<LoginResponse> LoginAsync(LoginRequest request);
    }
}