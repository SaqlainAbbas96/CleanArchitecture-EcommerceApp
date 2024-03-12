using Ecommerce.Core.Entities;
using Ecommerce.Core.Interfaces;
using Ecommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AppDbContext _db;

        public AccountRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<string> RegisterUser(User user)
        {
            _db.User.Add(user);
            await _db.SaveChangesAsync();

            return "success";
        }

        public async Task<User?> Checkuser(string email, string password)
        {
            var user = _db.User.FirstOrDefault(u => u.email == email);

            return user != null ? user : null;
        }

        public async Task<string?> GetRole(int userId)
        {
            int roleId = _db.UserRoles.Where(u => u.userId == userId).Select(u => u.roleId).FirstOrDefault();
            string role = _db.Role.Where(r => r.id == roleId).Select(r => r.rolename).FirstOrDefault();
            return role;
        }       
    }
}
