using Ecommerce.Application.DTOs;
using Ecommerce.Core.Entities;
using Ecommerce.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Cryptography;

namespace Ecommerce.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAccountRepository _accountRepository;
        private readonly IJwtAuthenticationService _jwtAuthenticationService;

        public AccountService(IHttpContextAccessor httpContextAccessor, IAccountRepository accountRepository, IJwtAuthenticationService jwtAuthenticationService)
        {
            _httpContextAccessor = httpContextAccessor;
            _accountRepository = accountRepository;
            _jwtAuthenticationService = jwtAuthenticationService;
        }

        public async Task<string> Register(UserDTO dto)
        {
            User user = new User();

            PasswordHash(dto.password, out byte[] passwordHash, out byte[] passwordSalt);

            user.email = dto.email;
            user.passwordHash = passwordHash;
            user.passwordSalt = passwordSalt;

            var res = await _accountRepository.RegisterUser(user);
            return res;
        }

        public async Task<string> Authenticate(LoginDTO dto)
        {
            var user = await _accountRepository.Checkuser(dto.email, dto.password);

            if (user is not null)
            {
                Global.userId = user.id;
                var userRole = await _accountRepository.GetRole(user.id);

                bool isPasswordCorrect = VerifyHashPassword(dto.password, user.passwordHash, user.passwordSalt);

                if (isPasswordCorrect)
                {
                    var res = _jwtAuthenticationService.GenerateToken(dto.email, userRole);
                    var session = _httpContextAccessor.HttpContext.Session;
                    session.SetString("Email", dto.email);
                    session.SetString("Role", userRole);
                    return res;
                }
                else
                    return "Invalid Password";
            }
            else
                return "Invalid Credentials";
        }

        public async Task<string> LogoutUser()
        {
            var session = _httpContextAccessor.HttpContext.Session;

            // Clear session data related to authentication
            session.Remove("Email");
            session.Remove("Role");
            session.Remove("CartCounter");
            session.Remove("UserCart");
            session.Remove("total");

            return "Logout Successfully";
        }

        public void PasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var h = new HMACSHA512())
            {
                passwordSalt = h.Key;
                passwordHash = h.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        public bool VerifyHashPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var h = new HMACSHA512(passwordSalt))
            {
                var hash = h.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return hash.SequenceEqual(passwordHash);
            }
        }
    }
}
