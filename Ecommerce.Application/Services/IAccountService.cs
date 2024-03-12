using Ecommerce.Application.DTOs;

namespace Ecommerce.Application.Services
{
    public interface IAccountService
    {
        Task<string> Register(UserDTO dto);
        Task<string> Authenticate(LoginDTO dto);
        Task<string> LogoutUser();
    }
}
