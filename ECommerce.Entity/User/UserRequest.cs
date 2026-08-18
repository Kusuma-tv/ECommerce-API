using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Entity.User
{
    public class UserRequest
    {
        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
    }
    namespace ECommerce.Entity.User
    {
        public class LoginRequest
        {
            public string Email { get; set; } = string.Empty;

            public string Password { get; set; } = string.Empty;
        }
    }
}
