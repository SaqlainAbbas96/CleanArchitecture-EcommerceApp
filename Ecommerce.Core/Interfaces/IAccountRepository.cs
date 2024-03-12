using Ecommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Interfaces
{
    public interface IAccountRepository
    {
        Task<string> RegisterUser(User user);
        Task<User?> Checkuser(string email, string password);
        Task<string> GetRole(int userId);
    }
}
