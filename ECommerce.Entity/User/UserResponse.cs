using System;

namespace ECommerce.Entity.User
{
    public class UserResponse
    {
        public int StatusCode { get; set; }

        public string Message { get; set; } = string.Empty;

        public UserResult? Result { get; set; }
    }

    public class UserResult
    {
        public int UserId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Role { get; set; } = string.Empty;

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
    public class LoginResponse
    {
        public int StatusCode { get; set; }

        public string Message { get; set; } = string.Empty;

        public string Token { get; set; } = string.Empty;

        public int UserId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Role { get; set; } = string.Empty;
    }
}