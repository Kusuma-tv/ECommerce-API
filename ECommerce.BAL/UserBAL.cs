using ECommerce.Entity.User;
using ECommerce.Entity.User.ECommerce.Entity.User;
using ECommerce.Interfaces.IBAL;
using ECommerce.Interfaces.IRepository;
using ECommerce.Interfaces;

namespace ECommerce.BAL
{
    public class UserBAL : IUserBAL
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;

        public UserBAL(
               IUserRepository userRepository,
               IJwtService jwtService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
        }

        public async Task<UserResponse> RegisterAsync(UserRequest request)
        {
            
            // 1. Validate name
            if (string.IsNullOrWhiteSpace(request.Name))
            {
                return new UserResponse
                {
                    StatusCode = 400,
                    Message = "Name is required",
                    Result = null
                };
            }

            // 2. Validate email
            if (string.IsNullOrWhiteSpace(request.Email))
            {
                return new UserResponse
                {
                    StatusCode = 400,
                    Message = "Email is required",
                    Result = null
                };
            }

            // 3. Validate password
            if (string.IsNullOrWhiteSpace(request.Password))
            {
                return new UserResponse
                {
                    StatusCode = 400,
                    Message = "Password is required",
                    Result = null
                };
            }

            // 4. Check whether email already exists
            var existingUser =
                await _userRepository.GetByEmailAsync(request.Email);

            if (existingUser != null)
            {
                return new UserResponse
                {
                    StatusCode = 400,
                    Message = "Email is already registered",
                    Result = null
                };
            }

            // 5. Hash password
            var passwordHash =
                BCrypt.Net.BCrypt.HashPassword(request.Password);

            // 6. Create User entity
            var user = new User
            {
                Name = request.Name,
                Email = request.Email,
                PasswordHash = passwordHash,
                Role = "Customer",
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            // 7. Save user to database
            var createdUser =
                await _userRepository.CreateAsync(user);

            // 8. Return response
            return new UserResponse
            {
                StatusCode = 201,
                Message = "User registered successfully",
                Result = new UserResult
                {
                    UserId = createdUser.UserId,
                    Name = createdUser.Name,
                    Email = createdUser.Email,
                    Role = createdUser.Role,
                    IsActive = createdUser.IsActive,
                    CreatedAt = createdUser.CreatedAt,
                    UpdatedAt = createdUser.UpdatedAt
                }
            };
        }
        public async Task<LoginResponse> LoginAsync(LoginRequest request)
        {
            var user = await _userRepository.GetUserByEmailAsync(request.Email);

            if (user == null)
            {
                return new LoginResponse
                {
                    StatusCode = 401,
                    Message = "Invalid email or password"
                };
            }

            bool passwordValid = BCrypt.Net.BCrypt.Verify(
                request.Password,
                user.PasswordHash
            );

            if (!passwordValid)
            {
                return new LoginResponse
                {
                    StatusCode = 401,
                    Message = "Invalid email or password"
                };
            }

            var token = _jwtService.GenerateToken(
                         user.UserId,
                         user.Email,
                         user.Role
                         );

            return new LoginResponse
            {
                StatusCode = 200,
                Message = "Login successful",
                Token = token,
                UserId = user.UserId,
                Name = user.Name,
                Email = user.Email,
                Role = user.Role
            };
        }
    }
}