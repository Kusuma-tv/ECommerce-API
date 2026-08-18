using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(int userId, string email, string role);
    }
}
